package com.example.retodam2rutas.data.service

import com.example.retodam2rutas.model.UsuarioModel
import retrofit2.Call
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.GET
import retrofit2.http.Query

interface UsuarioService {

    @GET("usuario/login")
    suspend fun getLogin(@Query("email") email: String, @Query("password") password: String): UsuarioModel
}

object UsuarioServiceFactory{
    fun makeUsuarioService(): UsuarioService{
        return Retrofit.Builder()
            .baseUrl("http://localhost:5050/api/")
            .addConverterFactory(GsonConverterFactory.create())
            .build().create(UsuarioService::class.java)


    }
}