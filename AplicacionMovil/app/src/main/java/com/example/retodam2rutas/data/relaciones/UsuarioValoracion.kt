package com.example.retodam2rutas.data.relaciones

import androidx.room.Embedded
import androidx.room.Relation
import com.example.retodam2rutas.model.Usuario
import com.example.retodam2rutas.model.Valoracion

data class UsuarioValoracion(
    @Embedded
    val usuario: Usuario,

    @Relation(
        parentColumn = "idUsuario",
        entityColumn = "usuarioId"
    )
    val valoraciones: List<Valoracion>
)
