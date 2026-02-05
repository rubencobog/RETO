package com.example.retodam2rutas.model

data class UsuarioModel(
    val apellido: String,
    val email: String,
    val idUsuario: Int,
    val nombre: String,
    val password: String,
    val resenas: List<Any>,
    val rol: String,
    val valoraciones: List<Any>
)