package com.example.retodam2rutas.data.daos

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import androidx.room.Update
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.Usuario
import kotlinx.coroutines.flow.Flow

@Dao
interface RutaDao {

    @Insert(onConflict = OnConflictStrategy.ABORT)
    suspend fun insertRuta(ruta: Ruta): Long

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insertAll(ruta: List<Ruta>)

    @Query("SELECT * FROM rutas")
    fun getAll(): Flow<List<Ruta>>

    @Query("SELECT * FROM rutas")
    suspend fun getAllRutas(): List<Ruta>

    @Query("SELECT * FROM rutas WHERE idRuta = :rutaId")
    suspend fun getRutaById(rutaId: Int): Ruta?

    @Update
    suspend fun updateRuta(ruta: Ruta)

    @Delete
    suspend fun deleteRuta(ruta: Ruta)
}