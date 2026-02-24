package com.example.retodam2rutas.data.relaciones

import androidx.room.Embedded
import androidx.room.Relation
import com.example.retodam2rutas.entities.PuntoRuta
import com.example.retodam2rutas.entities.Ruta

data class RutaPuntos(
    @Embedded
    val ruta: Ruta,

    @Relation(
        parentColumn = "idRuta",
        entityColumn = "rutaId"
    )
    val puntos: List<PuntoRuta>
)
