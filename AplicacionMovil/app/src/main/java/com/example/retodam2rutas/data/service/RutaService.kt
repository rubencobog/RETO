package com.example.retodam2rutas.data.service

import android.util.Log
import com.example.retodam2rutas.data.daos.RutaDao
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.model.RutaModel
import com.example.retodam2rutas.model.toEntity
import com.example.retodam2rutas.model.toModel
import kotlinx.coroutines.flow.Flow
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Query

interface RutaService {

    @GET("ruta")
    suspend fun getAllRutas(): List<RutaModel>

    @GET("ruta/buscar")
    suspend fun buscar(
        @Query("campo") campo: String,
        @Query("valor") valor: String
    ): List<RutaModel>

    @GET("ruta/usuario")
    suspend fun getByUsuario(
        @Query("usuarioId") usuarioId: Int
    ): List<RutaModel>

    @POST("ruta")
    suspend fun insertar(
        @Body ruta: RutaModel
    ): RutaModel

}

class RutaServiceImpl(
    private val api: RutaService = BaseServiceFactory.createService(),
    private val dao: RutaDao
) {

    val rutas: Flow<List<Ruta>> = dao.getAll()

    suspend fun refreshRutas() {
        val remoteRutas = api.getAllRutas()
        dao.insertAll(remoteRutas.map { it.toEntity() })
    }

    suspend fun getAll(): List<RutaModel> {
        return api.getAllRutas()
    }

    suspend fun insertarRuta(ruta: Ruta) {
        Log.d("USER", "Ruta: " + ruta.usuarioId)
        api.insertar(ruta.toModel())
    }

}
