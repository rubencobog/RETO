package com.example.retodam2rutas.views

import android.annotation.SuppressLint
import android.content.Context
import android.os.Looper
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.entities.PuntoRuta
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.maptemp.RutaTemporal
import com.example.retodam2rutas.entities.maptemp.TrackPoint
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationCallback
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.location.LocationResult
import com.google.android.gms.location.Priority
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import org.osmdroid.util.GeoPoint
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
            iterador++
        }
    }
    private var iterador by mutableStateOf(0.000000000001)
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
        val formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss")

        val inicio = ruta.trackPoints.first()
        val fin = ruta.trackPoints.last()

        val sb = StringBuilder()

        sb.append("""<?xml version="1.0" encoding="utf-8"?>""")
        sb.append(
            """
            <gpx version="1.1" creator="ProyectoSpringBoot"
                 xmlns="http://www.topografix.com/GPX/1/1"
                 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                 xsi:schemaLocation="http://www.topografix.com/GPX/1/1 
                                     http://www.topografix.com/GPX/1/1/gpx.xsd">
            """
        )

        // ---------- METADATA ----------
        sb.append(
            """
                <metadata>
                    <tipoRegistro>InfoGeneral</tipoRegistro>
                    <nombreRuta>${ruta.nombre}</nombreRuta>
                    <enlaceWikiloc>www.rutas.es</enlaceWikiloc>
                    <author>saul@gmail.com</author>
                    <fechaCreacionGPX>${LocalDateTime.now().format(formatter)}</fechaCreacionGPX>
                </metadata>
            """
        )

        // ---------- WAYPOINT INICIO ----------
        sb.append(
            """
                <wpt latitud="${inicio.latitude}" longitud="${inicio.longitude}" elevacion="0">
                    <timeestamp>${inicio.timestamp.format(formatter)}</timeestamp>
                    <nombre>Inicio</nombre>
                    <descripcion>Punto de inicio</descripcion>
                </wpt>
            """
        )

        // ---------- WAYPOINT FIN ----------
        sb.append(
            """
                <wpt latitud="${fin.latitude}" longitud="${fin.longitude}" elevacion="0">
                    <timeestamp>${fin.timestamp.format(formatter)}</timeestamp>
                    <nombre>Fin</nombre>
                    <descripcion>Punto final</descripcion>
                </wpt>
            """
        )

        // ---------- TRACK ----------
        sb.append("    <trk>\n")
        ruta.trackPoints.forEach { tp ->
            sb.append(
                """
                    <trk latitud="${tp.latitude}" longitud="${tp.longitude}" elevacion="0">
                        <timeestamp>${tp.timestamp.format(formatter)}</timeestamp>
                    </trk>
                """
            )
        }
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
    fun RutaTemporal.toRuta(usuarioId: Int, gpxPath: String): Ruta {
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
            archivoGPX = gpxPath,
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

    fun RutaTemporal.toPuntosRuta(rutaId: Int): List<PuntoRuta> {
        return trackPoints.mapIndexed { index, tp ->
            PuntoRuta(
                id = index.toLong(),
                latitud = tp.latitude,
                longitud = tp.longitude,
                elevacion = tp.elevacion ?: 0,
                timeStamp = tp.timestamp
            )
        }
    }

    fun guardarRuta(rutaTemporal: RutaTemporal?, usuarioId: Int, context: Context) {
        viewModelScope.launch(Dispatchers.IO) {

            val gpx = rutaTemporal?.let { exportarGPX(it) }
            val file = File(context.filesDir, "${rutaTemporal?.nombre}.gpx")
            if (gpx != null) {
                file.writeText(gpx)
            }

            val ruta = rutaTemporal?.toRuta(usuarioId, file.absolutePath)
            val rutaId = ruta?.let { appDatabase.rutaDao().insertRuta(it) }

            val puntos = rutaId?.let { rutaTemporal.toPuntosRuta(it.toInt()) }
            if (puntos != null) {
                appDatabase.puntoRutaDao().insertAll(puntos)
            }
        }
    }

    fun guardarPuntos(ruta: Ruta): List<PuntoRuta?>{
        var puntosRuta by mutableStateOf<List<PuntoRuta?>>(emptyList())

        viewModelScope.launch(Dispatchers.IO) {
            puntosRuta = appDatabase.puntoRutaDao().getByRuta(ruta.id)
        }

        return puntosRuta
    }

}