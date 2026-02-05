package com.example.retodam2rutas.data.relaciones

import androidx.room.Embedded
import androidx.room.Relation
import com.example.retodam2rutas.data.entities.Ruta
import com.example.retodam2rutas.data.entities.Usuario
import com.example.retodam2rutas.data.entities.Valoracion

data class ValoracionCompleta(
    @Embedded val valoracion: Valoracion,

    @Relation(
        parentColumn = "usuarioId",
        entityColumn = "idUsuario"
    )
    val usuario: Usuario,

    @Relation(
        parentColumn = "rutaId",
        entityColumn = "idRuta"
    )
    val ruta: Ruta
)
