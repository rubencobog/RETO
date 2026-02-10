package com.example.retodam2rutas.data.service

import com.example.retodam2rutas.data.daos.UsuarioDao
import com.example.retodam2rutas.entities.Usuario
import com.example.retodam2rutas.model.UsuarioModel
import com.example.retodam2rutas.model.toEntity
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.map
import retrofit2.Call
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.GET
import retrofit2.http.Query

interface UsuarioService {

    @GET("usuario/login")
    suspend fun getLogin(@Query("email") email: String, @Query("password") password: String): UsuarioModel

    @GET("usuario")
    suspend fun getAllUsuarios(): List<UsuarioModel>
}

class UsuarioServiceImpl(
    private val api: UsuarioService = UsuarioServiceFactory.makeUsuarioService(),
    private val dao: UsuarioDao
){


    val usuarios: Flow<List<Usuario>> = dao.getAll()

    suspend fun refreshUsers() {
        val remoteUsers = api.getAllUsuarios()
        dao.insertAll(remoteUsers.map { it.toEntity() })
    }


}




object UsuarioServiceFactory{
    fun makeUsuarioService(): UsuarioService{
        return Retrofit.Builder()
            .baseUrl("http://10.0.22.10:5050/api/")
            .addConverterFactory(GsonConverterFactory.create())
            .build().create(UsuarioService::class.java)
    }
}