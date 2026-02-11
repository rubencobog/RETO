package com.example.retodam2rutas.views

import android.annotation.SuppressLint
import android.content.Context
import android.os.Looper
import android.util.Log
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.compose.runtime.snapshots.toInt
import androidx.core.content.ContextCompat
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.retodam2rutas.R
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.data.service.BaseServiceFactory
import com.example.retodam2rutas.data.service.RutaServiceImpl
import com.example.retodam2rutas.entities.CLASIFICACION
import com.example.retodam2rutas.entities.PuntoInteres
import com.example.retodam2rutas.entities.PuntoPeligro
import com.example.retodam2rutas.entities.PuntoRuta
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.maptemp.PuntoMapa
import com.example.retodam2rutas.entities.maptemp.RutaTemporal
import com.example.retodam2rutas.entities.maptemp.TipoPuntoMapa
import com.example.retodam2rutas.entities.maptemp.TrackPoint
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationCallback
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.location.LocationResult
import com.google.android.gms.location.Priority
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import org.osmdroid.util.GeoPoint
import org.osmdroid.views.MapView
import org.osmdroid.views.overlay.Marker
import java.io.File
import java.time.Duration
import java.time.LocalDateTime
import java.time.LocalTime
import java.time.Period
import java.time.format.DateTimeFormatter
import kotlin.math.atan2
import kotlin.math.cos
import kotlin.math.pow
import kotlin.math.sin
import kotlin.math.sqrt


class MapViewModel(
    private val appDatabase: AppDatabase,
    private val fusedLocationClient: FusedLocationProviderClient
) : ViewModel() {
    val rutaServiceImpl = RutaServiceImpl(BaseServiceFactory.createService(), appDatabase.rutaDao())

    var lastGeoPoint by mutableStateOf<GeoPoint?>(null)
        private set

    private val locationRequest = LocationRequest.Builder(
        Priority.PRIORITY_HIGH_ACCURACY,
        5000L
    ).setMinUpdateIntervalMillis(3000L)
        .build()

    private val locationCallback = object : LocationCallback() {
        override fun onLocationResult(result: LocationResult) {
            val location = result.lastLocation ?: return
            lastGeoPoint = GeoPoint(location.latitude+iterador, location.longitude)
            iterador+=0.001//sumar iterador a latitud o longitud para moverse en el emulador
        }
    }
    private var iterador by mutableStateOf(0.001)
    @SuppressLint("MissingPermission")
    fun startLocationUpdates() {
        fusedLocationClient.requestLocationUpdates(
            locationRequest,
            locationCallback,
            Looper.getMainLooper()
        )
    }

    override fun onCleared() {
        fusedLocationClient.removeLocationUpdates(locationCallback)
    }

    //==================== Generacion de rutas en tiempo real =======================

    var rutaEnCreacion by mutableStateOf<RutaTemporal?>(null)

    fun iniciarRuta(nombre: String, ubicacionActual: GeoPoint) {
        rutaEnCreacion = RutaTemporal(nombre).apply {
            trackPoints.add(TrackPoint(ubicacionActual.latitude, ubicacionActual.longitude))
        }
    }

    fun actualizarRuta(ubicacionActual: GeoPoint) {
        rutaEnCreacion?.trackPoints?.add(
            TrackPoint(ubicacionActual.latitude, ubicacionActual.longitude)
        )
    }

    fun terminarRuta(ubicacionActual: GeoPoint) {
        rutaEnCreacion?.trackPoints?.add(
            TrackPoint(ubicacionActual.latitude, ubicacionActual.longitude)
        )
    }

    fun exportarGPX(ruta: RutaTemporal): String {
        val formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd'T'HH:mm:ss'Z'")

        val inicio = ruta.trackPoints.first()
        val fin = ruta.trackPoints.last()

        val sb = StringBuilder()

        sb.append("""<?xml version="1.0" encoding="utf-8"?>""")
        sb.append(
            """
        <gpx version="1.1" creator="RetoDAM2Rutas"
             xmlns="http://www.topografix.com/GPX/1/1"
             xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
             xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
        """
        )

        // ---------- METADATA ----------
        sb.append(
            """
            <metadata>
                <name>${ruta.nombre}</name>
                <author>
                    <name>Saul</name>
                </author>
                <link href="http://www.rutas.es">
                    <text>Mi Web de Rutas</text>
                </link>
                <time>${LocalDateTime.now().format(formatter)}</time>
            </metadata>
        """
        )

        // ---------- WAYPOINT INICIO (WPT) ----------
        sb.append(
            """
            <wpt lat="${inicio.latitude}" lon="${inicio.longitude}">
                <ele>0</ele>
                <time>${inicio.timestamp.format(formatter)}</time>
                <name>Inicio</name>
                <desc>Punto de inicio</desc>
            </wpt>
        """
        )

        // ---------- WAYPOINT FIN (WPT) ----------
        sb.append(
            """
            <wpt lat="${fin.latitude}" lon="${fin.longitude}">
                <ele>0</ele>
                <time>${fin.timestamp.format(formatter)}</time>
                <name>Fin</name>
                <desc>Punto final</desc>
            </wpt>
        """
        )

        // ---------- TRACK (TRK) ----------
        sb.append("    <trk>\n")
        sb.append("        <name>${ruta.nombre}</name>\n")
        sb.append("        <trkseg>\n") // Inicia el segmento de track
        ruta.trackPoints.forEach { tp ->
            sb.append(
                """
                    <trkpt lat="${tp.latitude}" lon="${tp.longitude}">
                        <ele>0</ele> 
                        <time>${tp.timestamp.format(formatter)}</time>
                    </trkpt>
            """
            )
        }
        sb.append("        </trkseg>\n") // Cierra el segmento de track
        sb.append("    </trk>\n")
        sb.append("</gpx>")

        return sb.toString()
    }



    /**
     * En la sintaxis de kotlin esta funcion actua como si estuviese en la clase
     * de RutaTemporal aunque no este fisicamente creada alli
     * De esta manera puedo hacer que un objeto Ruta ruta y otro RutaTemporal temp hagan
     * ruta = temp.toRuta(1,"path")
     **/
    fun RutaTemporal.toRuta(
        usuarioId: Int,
        gpxPath: String,
        nombre: String,
        clasificacion: CLASIFICACION,
        nivelEsfuerzo: Byte?,
        nivelRiesgo: Byte?,
        tipoTerreno: Byte?,
        indicaciones: Byte?,
        temporadas: String?,
        accesibilidad: Boolean,
        rutaFamiliar: Boolean,
        recomendaciones: String?,
        zonaGeografica: String?
    ): Ruta {

        val inicio = trackPoints.first()
        val fin = trackPoints.last()

        return Ruta(
            id = 0,
            nombre = nombre,
            latitudInicial = inicio.latitude,
            longitudInicial = inicio.longitude,
            latitudFinal = fin.latitude,
            longitudFinal = fin.longitude,
            distancia = calcularDistancia(trackPoints),
            duracion = calcularDuracion(inicio.timestamp, fin.timestamp),
            desnivelPositivo = 0,
            desnivelNegativo = 0,
            desnivelAcumulado = 0,
            altitudMax = 0.0,
            altitudMin = 0.0,
            clasificacion = clasificacion,
            nivelEsfuerzo = nivelEsfuerzo,
            nivelRiesgo = nivelRiesgo,
            tipoTerreno = tipoTerreno,
            indicaciones = indicaciones,
            temporadas = temporadas,
            accesibilidad = accesibilidad,
            rutaFamiliar = rutaFamiliar,
            archivoGPX = gpxPath,
            recomendacionesEquipo = recomendaciones,
            zonaGeografica = zonaGeografica,
            usuarioId = usuarioId
        )
    }


    fun calcularDistancia(trackpoints: List<TrackPoint>): Double{
        var distanciaTotal = 0.0
        for (i in 0 until trackpoints.size - 1) {
            distanciaTotal += calcularDistanciaKm(trackpoints[i],trackpoints[i+1])
        }
        return distanciaTotal
    }

    fun calcularDuracion(iniTime: LocalDateTime, finTime: LocalDateTime): LocalTime{

        val period = Period.between(iniTime.toLocalDate(), finTime.toLocalDate())

        val fechaIntermedia = iniTime.plusYears(period.years.toLong())
            .plusMonths(period.months.toLong())
            .plusDays(period.days.toLong())

        val duration = Duration.between(fechaIntermedia, finTime)

        val horas = duration.toHours()
        val minutos = duration.toMinutes() % 60
        val segundos = duration.seconds % 60

        return LocalTime.of(horas.toInt(), minutos.toInt(), segundos.toInt())
    }

    private val RADIO_TIERRA_KM = 6371.0

    fun calcularDistanciaKm(p1: TrackPoint, p2: TrackPoint): Double {
        val lat1Rad = Math.toRadians(p1.latitude)
        val lon1Rad = Math.toRadians(p1.longitude)
        val lat2Rad = Math.toRadians(p2.latitude)
        val lon2Rad = Math.toRadians(p2.longitude)

        val difLat = lat2Rad - lat1Rad
        val difLon = lon2Rad - lon1Rad

        val a = sin(difLat / 2).pow(2.0) +
                cos(lat1Rad) * cos(lat2Rad) * sin(difLon / 2).pow(2.0)

        val c = 2 * atan2(sqrt(a), sqrt(1 - a))

        return RADIO_TIERRA_KM * c
    }

    fun RutaTemporal.toPuntosRuta(rutaId: Long): List<PuntoRuta> {
        return trackPoints.mapIndexed { index, tp ->
            PuntoRuta(
                id = index.toLong(),
                latitud = tp.latitude,
                longitud = tp.longitude,
                elevacion = tp.elevacion ?: 0,
                timeStamp = tp.timestamp,
                rutaId = rutaId
            )
        }
    }

    fun guardarPuntos(ruta: Ruta): List<PuntoRuta?>{
        var puntosRuta by mutableStateOf<List<PuntoRuta?>>(emptyList())

        viewModelScope.launch(Dispatchers.IO) {
            puntosRuta = appDatabase.puntoRutaDao().getByRuta(ruta.id)
        }

        return puntosRuta
    }

    fun guardarRuta(
        rutaTemporal: RutaTemporal,
        usuarioId: Int,
        context: Context,
        nombre: String,
        clasificacion: CLASIFICACION,
        nivelEsfuerzo: Byte,
        nivelRiesgo: Byte,
        tipoTerreno: Byte?,
        indicaciones: Byte?,
        temporadas: String?,
        accesibilidad: Boolean,
        rutaFamiliar: Boolean,
        recomendaciones: String?,
        zonaGeografica: String?
    ) {
        viewModelScope.launch(Dispatchers.IO) {
            try {
                val gpx = exportarGPX(rutaTemporal)
                val file = File(context.filesDir, "$nombre.gpx")
                file.writeText(gpx)

                val ruta = rutaTemporal.toRuta(
                    usuarioId = usuarioId,
                    gpxPath = file.absolutePath,
                    nombre = nombre,
                    clasificacion = clasificacion,
                    nivelEsfuerzo = nivelEsfuerzo,
                    nivelRiesgo = nivelRiesgo,
                    tipoTerreno = tipoTerreno,
                    indicaciones = indicaciones,
                    temporadas = temporadas,
                    accesibilidad = accesibilidad,
                    rutaFamiliar = rutaFamiliar,
                    recomendaciones = recomendaciones,
                    zonaGeografica = zonaGeografica
                )

                val rutaId = appDatabase.rutaDao().insertRuta(ruta)
                val puntos = rutaTemporal.toPuntosRuta(rutaId)
                appDatabase.puntoRutaDao().insertAll(puntos)

            } catch (e: Exception) {
                Log.e("GUARDAR_RUTA", "Error guardando la ruta", e)
            }
        }
    }



    //================ Puntos de interes y de peligro ================
    fun guardarPuntoInteres(
        geoPoint: GeoPoint,
        nombre: String,
        descripcion: String
    ) {
        viewModelScope.launch {
            val puntoRutaId = appDatabase.puntoRutaDao().insert(
                PuntoRuta(
                    latitud = geoPoint.latitude,
                    longitud = geoPoint.longitude,
                    elevacion = 0,
                    timeStamp = LocalDateTime.now()
                )
            )

            appDatabase.puntoInteresDao().insert(
                PuntoInteres(
                    nombre = nombre,
                    caracteristicasEspeciales = descripcion,
                    puntoRutaId = puntoRutaId
                )
            )

            añadirPuntoMapa(
                geoPoint = geoPoint,
                tipo = TipoPuntoMapa.INTERES
            )
        }
    }

    fun guardarPuntoPeligro(
        geoPoint: GeoPoint,
        kilometro: Double,
        gravedad: Byte,
        justificacion: String
    ) {
        viewModelScope.launch {
            val puntoRutaId = appDatabase.puntoRutaDao().insert(
                PuntoRuta(
                    latitud = geoPoint.latitude,
                    longitud = geoPoint.longitude,
                    elevacion = 0,
                    timeStamp = LocalDateTime.now()
                )
            )

            appDatabase.puntoPeligroDao().insert(
                PuntoPeligro(
                    kilometro = kilometro,
                    gravedad = gravedad,
                    justificacion = justificacion,
                    puntoRutaId = puntoRutaId
                )
            )

            añadirPuntoMapa(
                geoPoint = geoPoint,
                tipo = TipoPuntoMapa.PELIGRO
            )
        }
    }


    private val _puntosMapa = mutableStateListOf<PuntoMapa>()
    val puntosMapa: List<PuntoMapa> = _puntosMapa
    val markersMapa = mutableMapOf<Long, Marker>()

    fun añadirPuntoMapa(
        geoPoint: GeoPoint,
        tipo: TipoPuntoMapa
    ) {
        _puntosMapa.add(
            PuntoMapa(
                id = System.currentTimeMillis(),
                geoPoint = geoPoint,
                tipo = tipo
            )
        )
    }
    fun crearMarker(
        mapView: MapView,
        punto: PuntoMapa,
        context: Context
    ): Marker {
        return Marker(mapView).apply {
            position = punto.geoPoint
            setAnchor(Marker.ANCHOR_CENTER, Marker.ANCHOR_BOTTOM)
            title = when (punto.tipo) {
                TipoPuntoMapa.INTERES -> "Punto de interés"
                TipoPuntoMapa.PELIGRO -> "Punto de peligro"
            }
            icon = ContextCompat.getDrawable(
                context,
                when (punto.tipo) {
                    TipoPuntoMapa.INTERES -> R.drawable.punto_interes
                    TipoPuntoMapa.PELIGRO -> R.drawable.punto_peligro
                }
            )
        }
    }


    //================ Conexion api ================
    init{
        viewModelScope.launch {
            rutaServiceImpl.refreshRutas()
        }
    }
}