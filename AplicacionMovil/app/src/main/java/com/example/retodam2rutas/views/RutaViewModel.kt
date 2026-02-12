package com.example.retodam2rutas.views

import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.data.preferences.PreferencesManager
import com.example.retodam2rutas.data.service.BaseServiceFactory
import com.example.retodam2rutas.data.service.RutaServiceImpl
import com.example.retodam2rutas.data.service.UsuarioServiceImpl
import com.example.retodam2rutas.entities.Ruta
import kotlinx.coroutines.flow.SharingStarted
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.first
import kotlinx.coroutines.flow.stateIn
import kotlinx.coroutines.launch

class RutaViewModel(
    private val appDatabase: AppDatabase,
    private val preferencesManager: PreferencesManager
) : ViewModel() {

    val rutaServiceImpl = RutaServiceImpl(BaseServiceFactory.createService(), appDatabase.rutaDao())

    //================ Pedir lista de Rutas =================
    var rutas by mutableStateOf<List<Ruta>>(emptyList())
        private set

    fun cargarRutas() {
        viewModelScope.launch {
            rutas = appDatabase.rutaDao().getAllRutas()
        }
    }

    val rutasFlow: StateFlow<List<Ruta>> =
        appDatabase.rutaDao().getAll()
            .stateIn(
                scope = viewModelScope,
                started = SharingStarted.WhileSubscribed(5000),
                initialValue = emptyList()
            )

    //================ Pedir una Ruta por id =================
    var rutaSeleccionada by mutableStateOf<Ruta?>(null)
        private set

    fun cargarRuta(id: Int) {
        viewModelScope.launch {
            rutaSeleccionada = appDatabase.rutaDao().getRutaById(id)
        }
    }

    suspend fun getRuta(id: Int): Ruta? {
        return appDatabase.rutaDao().getRutaById(id)
    }

    fun iniciar() {
// Insertar en la base de datos usando corrutina
        viewModelScope.launch {
            appDatabase.rutaDao().getAllRutas().forEach { ruta ->
                appDatabase.rutaDao().insertRuta(ruta)
            }
        }
    }

    init{
        viewModelScope.launch {
            rutaServiceImpl.refreshRutas()
            cargarRutas()
            // Verificar si es la primera ejecución
            val isFirstExecution =
                preferencesManager.isFirstExecution.first()
            if (isFirstExecution) {
                iniciar()
                // Marcar como no primera ejecución
                preferencesManager.setFirstExecution(false)
            }
        }
    }
}
