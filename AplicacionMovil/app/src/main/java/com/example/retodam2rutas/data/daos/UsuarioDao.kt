package com.example.retodam2rutas.data.daos

import androidx.room.Dao
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.Usuario
import kotlinx.coroutines.flow.Flow

@Dao
interface UsuarioDao {

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insert(usuario: Usuario): Long

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insertAll(usuario: List<Usuario>)

    @Query("SELECT * FROM usuario ORDER BY nombre ASC")
    fun getAll(): Flow<List<Usuario>>


    @Query("SELECT * FROM usuario WHERE email = :email")
    suspend fun getLogin(email: String): Usuario


}