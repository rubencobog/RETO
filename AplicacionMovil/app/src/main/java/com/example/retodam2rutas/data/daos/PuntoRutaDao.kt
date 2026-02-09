package com.example.retodam2rutas.data.daos

import androidx.room.Dao
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import com.example.retodam2rutas.entities.PuntoRuta

@Dao
interface PuntoRutaDao {

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insert(puntoRuta: PuntoRuta): Long

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insertAll(puntos: List<PuntoRuta>)

    @Query("SELECT * FROM puntosRuta ORDER BY timestamp ASC")
    suspend fun getAll(): List<PuntoRuta>

    @Query("SELECT * FROM puntosRuta WHERE id = :rutaId ORDER BY timestamp ASC")
    suspend fun getByRuta(rutaId: Int): List<PuntoRuta>

    @Query("DELETE FROM puntosRuta")
    suspend fun deleteAll()

    @Query("DELETE FROM puntosRuta WHERE id = :rutaId")
    suspend fun deleteByRuta(rutaId: Int)

}