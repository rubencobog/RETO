package com.example.retodam2rutas.views

import android.annotation.SuppressLint
import android.os.Looper
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationCallback
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.location.LocationResult
import com.google.android.gms.location.Priority
import org.osmdroid.util.GeoPoint

class MapViewModel(
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
            lastGeoPoint = GeoPoint(location.latitude, location.longitude)
        }
    }

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
}
