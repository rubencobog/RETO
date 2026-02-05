package com.example.retodam2rutas.views

import android.annotation.SuppressLint
import android.os.Looper
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.model.PuntoRuta
import com.example.retodam2rutas.model.Ruta
import com.example.retodam2rutas.model.maptemp.RutaTemporal
import com.example.retodam2rutas.model.maptemp.TrackPoint
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationCallback
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.location.LocationResult
import com.google.android.gms.location.Priority
import org.osmdroid.util.GeoPoint

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
        val sb = StringBuilder()
        sb.append("""<?xml version="1.0" encoding="UTF-8"?>""")
        sb.append("\n<gpx version=\"1.1\" creator=\"MiApp\">\n")
        sb.append("  <trk>\n")
        sb.append("    <name>${ruta.nombre}</name>\n")
        sb.append("    <trkseg>\n")

        ruta.trackPoints.forEach { tp ->
            sb.append("      <trkpt lat=\"${tp.latitude}\" lon=\"${tp.longitude}\">")
            sb.append("<time>${java.time.LocalDateTime.now()}</time>")
            sb.append("</trkpt>\n")
        }

        sb.append("    </trkseg>\n")
        sb.append("  </trk>\n")
        sb.append("</gpx>")
        return sb.toString()
    }

}
