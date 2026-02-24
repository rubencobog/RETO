package com.example.retodam2rutas.data.service

import com.example.retodam2rutas.data.daos.UsuarioDao
import com.example.retodam2rutas.entities.Usuario
import com.example.retodam2rutas.model.UsuarioModel
import com.example.retodam2rutas.model.toEntity
import kotlinx.coroutines.flow.Flow
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.GET
import retrofit2.http.Query

interface UsuarioService {

    @GET("usuario/login")
    suspend fun getLogin(@Query("email") email: String, @Query("password") password: String): UsuarioModel

    @GET("usuario")
    suspend fun getAllUsuarios(): List<UsuarioModel>

    @GET("usuario/buscar")
    suspend fun buscar(@Query("campo") campo: String, @Query("valor") valor: String): List<UsuarioModel>
}

class UsuarioServiceImpl(
    private val api: UsuarioService = BaseServiceFactory.createService(),
    private val dao: UsuarioDao
){


    val usuarios: Flow<List<Usuario>> = dao.getAll()

    suspend fun refreshUsers() {
        val remoteUsers = api.getAllUsuarios()
        dao.insertAll(remoteUsers.map { it.toEntity() })
    }

    suspend fun buscar(campo: String, valor: String): List<UsuarioModel>{
        return api.buscar(campo, valor)
    }

    suspend fun getAll(): List<UsuarioModel> {
        return api.getAllUsuarios()
    }

    suspend fun login(email: String, password: String): UsuarioModel {
        return api.getLogin(email, password)
    }


}



object BaseServiceFactory {
    val retrofit: Retrofit by lazy {
        Retrofit.Builder()
            .baseUrl("http://10.0.22.18:5050/api/")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
    }

    // Generic function to create any Retrofit service
    fun <T> createService(serviceClass: Class<T>): T {
        return retrofit.create(serviceClass)
    }

    // Kotlin reified version for convenience
    inline fun <reified T> createService(): T {
        return retrofit.create(T::class.java)
    }

}