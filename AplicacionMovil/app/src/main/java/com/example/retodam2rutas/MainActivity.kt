package com.example.retodam2rutas


import android.Manifest
import android.content.Context
import android.content.pm.PackageManager
import android.os.Bundle
import android.util.Log
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.core.content.ContextCompat
import androidx.lifecycle.lifecycleScope
import androidx.room.Room
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.data.preferences.PreferencesManager
import com.example.retodam2rutas.navigation.NavManager
import com.example.retodam2rutas.views.MapViewModel
import com.example.retodam2rutas.views.RutaViewModel
import com.example.retodam2rutas.views.LoginViewModel
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationServices
import kotlinx.coroutines.flow.first
import kotlinx.coroutines.launch
import org.osmdroid.config.Configuration

class MainActivity : ComponentActivity() {

    private lateinit var fusedLocationClient: FusedLocationProviderClient
    private lateinit var mapViewModel: MapViewModel

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        val prefs = PreferencesManager(applicationContext)
        val database = DatabaseProvider.getDatabase(this)
        val rutaViewModel = RutaViewModel(database, prefs)
        Configuration.getInstance().userAgentValue = packageName
        fusedLocationClient = LocationServices.getFusedLocationProviderClient(this)
        mapViewModel = MapViewModel(fusedLocationClient)
        val loginViewModel = LoginViewModel(database)

        requestLocationPermission()

        lifecycleScope.launch {
            // 1. Comprobar si es la primera ejecución
            val isFirst = prefs.isFirstExecution.first()

            if (isFirst) {
                prefs.setFirstExecution(true)
                Log.d("PREFERENCIAS", "Primera ejecución registrada")
            } else {
                val fecha = prefs.firstExecutionDate.first()
                Log.d("PREFERENCIAS", "Fecha de primera ejecución: $fecha")
            }

            // 2. Incrementar contador
            prefs.incrementContadorEjecuciones()

            val count = prefs.executionCount.first()
            Log.d("PREFERENCIAS", "Número de ejecuciones: $count")
        }

        enableEdgeToEdge()
        setContent {
            NavManager(rutaViewModel, mapViewModel, loginViewModel)
        }
    }

    // ================= Permisos =================
    private fun requestLocationPermission() {
        if (ContextCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_FINE_LOCATION
            ) != PackageManager.PERMISSION_GRANTED
        ) {
            locationPermissionLauncher.launch(
                arrayOf(
                    Manifest.permission.ACCESS_FINE_LOCATION,
                    Manifest.permission.ACCESS_COARSE_LOCATION
                )
            )
        } else {
            mapViewModel.startLocationUpdates()
        }
    }

    private val locationPermissionLauncher =
        registerForActivityResult(
            androidx.activity.result.contract.ActivityResultContracts.RequestMultiplePermissions()
        ) { permissions ->
            if (permissions[Manifest.permission.ACCESS_FINE_LOCATION] == true) {
                mapViewModel.startLocationUpdates()
            }
        }
}

object DatabaseProvider {
    private var INSTANCE: AppDatabase? = null
    fun getDatabase(context: Context): AppDatabase {
        return INSTANCE ?: synchronized(this) {
            val instance = Room.databaseBuilder(
                context.applicationContext,
                AppDatabase::class.java,
                "my_database.db" // Nombre a elegir
            ).build()
            INSTANCE = instance
            instance
        }
    }
}