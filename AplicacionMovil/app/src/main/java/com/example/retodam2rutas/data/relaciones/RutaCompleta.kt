package com.example.retodam2rutas.data.relaciones

import androidx.room.Embedded
import androidx.room.Relation
import com.example.retodam2rutas.model.Resena
import com.example.retodam2rutas.model.Ruta
import com.example.retodam2rutas.model.Valoracion

data class RutaCompleta(

    @Embedded
    val ruta: Ruta,

    @Relation(
        parentColumn = "idRuta",
        entityColumn = "rutaId"
    )
    val valoraciones: List<Valoracion>,

    @Relation(
        parentColumn = "idRuta",
        entityColumn = "rutaId"
    )
    val resenas: List<Resena>
)
