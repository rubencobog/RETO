package com.example.retodam2rutas.data.relaciones

import androidx.room.Embedded
import androidx.room.Relation
import com.example.retodam2rutas.entities.Resena
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.Valoracion

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
