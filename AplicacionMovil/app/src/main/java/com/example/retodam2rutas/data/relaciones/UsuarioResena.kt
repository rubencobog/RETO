package com.example.retodam2rutas.data.relaciones

import androidx.room.Embedded
import androidx.room.Relation
import com.example.retodam2rutas.entities.Resena
import com.example.retodam2rutas.entities.Usuario

data class UsuarioResena(
    @Embedded
    val usuario: Usuario,

    @Relation(
        parentColumn = "idUsuario",
        entityColumn = "usuarioId"
    )
    val resena: List<Resena>
)
