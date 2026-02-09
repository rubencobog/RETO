package com.example.retodam2rutas.data.database

import androidx.room.Database
import androidx.room.TypeConverters
import com.example.retodam2rutas.components.TipoConverter
import com.example.retodam2rutas.data.daos.RutaDao
import com.example.retodam2rutas.entities.PuntoRuta
import com.example.retodam2rutas.entities.Resena
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.Usuario
import com.example.retodam2rutas.entities.Valoracion
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
    version = 1,
    // Cambiar a false si no se quiere exportar el esquema
    exportSchema = true
)
@TypeConverters(TipoConverter::class)
abstract class AppDatabase(): RoomDatabase() {
    //DAOs
    abstract fun rutaDao(): RutaDao
}