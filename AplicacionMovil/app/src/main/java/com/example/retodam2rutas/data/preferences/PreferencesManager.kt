package com.example.retodam2rutas.data.preferences

import android.content.Context
import androidx.datastore.preferences.core.booleanPreferencesKey
import androidx.datastore.preferences.core.edit
import androidx.datastore.preferences.core.emptyPreferences
import androidx.datastore.preferences.core.intPreferencesKey
import androidx.datastore.preferences.core.stringPreferencesKey
import androidx.datastore.preferences.preferencesDataStore
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.catch
import kotlinx.coroutines.flow.map
import java.io.IOException
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

// Extensión para DataStore. Nombre de archivo app_mis_preferencias
private val Context.dataStore by preferencesDataStore("app_mis_preferencias")

class PreferencesManager(context: Context) {
    // Instancia de DataStore
    private val dataStore = context.dataStore

    companion object {
        //preferencia de primera ejecución cuya key es primer_ejecucion
        val PRIMERA_EJECUCION_KEY =
            booleanPreferencesKey("primera_ejecucion")
        val FECHA_PRIMERA_EJECUCION_KEY =
            stringPreferencesKey("fecha_primera_ejecucion")
        val CONTADOR_EJECUCIONES_KEY =
            intPreferencesKey("contador_ejecuciones")
    }

    // Flow para observar si es la primera ejecución
    val isFirstExecution: Flow<Boolean> = dataStore.data //lee losdatos de preferencias
        .catch { exception ->
            if (exception is IOException) {
                emit(emptyPreferences()) // Si no se puede leer, emite valores vacíos
            } else {
                throw exception
            }
        }
        .map { preferences ->
            //si no existe la key devuelve true
            preferences[PRIMERA_EJECUCION_KEY] ?: true
        }


    val firstExecutionDate: Flow<String?> = dataStore.data
        .catch { exception ->
            if (exception is IOException) {
                emit(emptyPreferences())
            } else {
                throw exception
            }
        }
        .map { preferences ->
            preferences[FECHA_PRIMERA_EJECUCION_KEY]
        }

    // Flow para observar el contador de ejecuciones
    val executionCount: Flow<Int> = dataStore.data
        .catch { exception ->
            if (exception is IOException) {
                emit(emptyPreferences())
            } else {
                throw exception
            }
        }
        .map { preferences ->
            preferences[CONTADOR_EJECUCIONES_KEY] ?: 0
        }

    // Función para incrementar el contador de ejecuciones
    suspend fun incrementContadorEjecuciones() {
        dataStore.edit { preferences ->
            val currentCount = preferences[CONTADOR_EJECUCIONES_KEY] ?: 0
            preferences[CONTADOR_EJECUCIONES_KEY] = currentCount + 1
        }
    }

    // Función para registrar la fecha de la primera ejecución
    suspend fun setFirstExecution(value: Boolean) {
        dataStore.edit { preferences ->
            preferences[PRIMERA_EJECUCION_KEY] = value
            if (value) {
                val currentDate = LocalDateTime.now()
                val formatter = DateTimeFormatter.ofPattern(
                    "yyyy-MM-dd HH:mm:ss")
                preferences[FECHA_PRIMERA_EJECUCION_KEY] =
                    currentDate.format(formatter)
            }
        }
    }
}