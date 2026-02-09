package com.example.retodam2rutas.data.daos

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import androidx.room.Update
import com.example.retodam2rutas.entities.PuntoPeligro

@Dao
interface PuntoPeligroDao {

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insert(puntoPeligro: PuntoPeligro): Long

    @Update
    suspend fun update(puntoPeligro: PuntoPeligro)

    @Delete
    suspend fun delete(puntoPeligro: PuntoPeligro)

    @Query("SELECT * FROM puntosPeligro WHERE id = :id")
    suspend fun getById(id: Long): PuntoPeligro?

    @Query("""
        SELECT * FROM puntosPeligro 
        WHERE puntoRutaId = :puntoRutaId
    """)
    suspend fun getByPuntoRuta(puntoRutaId: Long): List<PuntoPeligro>

    @Query("SELECT * FROM puntosPeligro")
    suspend fun getAll(): List<PuntoPeligro>

    @Query("DELETE FROM puntosPeligro WHERE puntoRutaId = :puntoRutaId")
    suspend fun deleteByPuntoRuta(puntoRutaId: Long)

}
