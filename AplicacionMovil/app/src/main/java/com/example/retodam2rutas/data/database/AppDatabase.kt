package com.example.retodam2rutas.data.database

import android.content.Context
import androidx.room.Database
import androidx.room.TypeConverters
import com.example.retodam2rutas.components.TipoConverter
import com.example.retodam2rutas.data.daos.RutaDao
import com.example.retodam2rutas.model.PuntoRuta
import com.example.retodam2rutas.model.Resena
import com.example.retodam2rutas.model.Ruta
import com.example.retodam2rutas.model.Usuario
import com.example.retodam2rutas.model.Valoracion
import androidx.room.Room
import androidx.room.RoomDatabase

@Database(
    // Se agregan la entidades
    entities = [
        Ruta::class,
        Usuario::class,
        PuntoRuta::class,
        Valoracion::class,
        Resena::class],
    // Cambiar este número si se modifica la estructura de la DB
    version = 2,
    // Cambiar a false si no se quiere exportar el esquema
    exportSchema = true
)
@TypeConverters(TipoConverter::class)
abstract class AppDatabase(): RoomDatabase() {
    //DAOs
    abstract fun rutaDao(): RutaDao
}