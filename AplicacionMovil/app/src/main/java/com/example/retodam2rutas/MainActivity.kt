package com.example.retodam2rutas

import android.content.Context
import android.os.Bundle
import android.util.Log
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.runtime.Composable
import androidx.compose.ui.tooling.preview.Preview
import androidx.lifecycle.lifecycleScope
import androidx.navigation.compose.rememberNavController
import androidx.room.Room
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.data.preferences.PreferencesManager
import com.example.retodam2rutas.navigation.NavManager
import com.example.retodam2rutas.views.HomeView
import com.example.retodam2rutas.views.RutaViewModel
import kotlinx.coroutines.flow.first
import kotlinx.coroutines.launch

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        val prefs = PreferencesManager(applicationContext)
        val database = DatabaseProvider.getDatabase(this)
        val rutaViewModel= RutaViewModel(database, prefs)

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
            NavManager(rutaViewModel)
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