package com.example.retodam2rutas.data.daos

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import androidx.room.Update
import com.example.retodam2rutas.entities.PuntoInteres

@Dao
interface PuntoInteresDao {

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insert(puntoInteres: PuntoInteres): Long

    @Update
    suspend fun update(puntoInteres: PuntoInteres)

    @Delete
    suspend fun delete(puntoInteres: PuntoInteres)

    @Query("SELECT * FROM puntosInteres WHERE id = :id")
    suspend fun getById(id: Long): PuntoInteres?

    @Query("""
        SELECT * FROM puntosInteres 
        WHERE puntoRutaId = :puntoRutaId
    """)
    suspend fun getByPuntoRuta(puntoRutaId: Long): List<PuntoInteres>

    @Query("SELECT * FROM puntosInteres")
    suspend fun getAll(): List<PuntoInteres>

    @Query("DELETE FROM puntosInteres WHERE puntoRutaId = :puntoRutaId")
    suspend fun deleteByPuntoRuta(puntoRutaId: Long)
}
