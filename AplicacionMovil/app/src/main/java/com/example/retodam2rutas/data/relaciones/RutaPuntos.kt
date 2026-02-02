package com.example.retodam2rutas.data.relaciones

import androidx.room.Embedded
import androidx.room.Relation
import com.example.retodam2rutas.model.PuntoRuta
import com.example.retodam2rutas.model.Ruta

data class RutaPuntos(
    @Embedded
    val ruta: Ruta,

    @Relation(
        parentColumn = "idRuta",
        entityColumn = "rutaId"
    )
    val puntos: List<PuntoRuta>
)
