package com.example.retodam2rutas.model

import com.example.retodam2rutas.entities.TIPOUSUARIO
import com.example.retodam2rutas.entities.Usuario

data class UsuarioModel(
    val apellido: String,
    val email: String,
    val idUsuario: Int,
    val nombre: String,
    val password: String,
    val rol: String,
)

fun UsuarioModel.toEntity() = Usuario(
    idUsuario = idUsuario,
    email = email,
    apellido = apellido,
    nombre = nombre,
    password = password,
    rol = TIPOUSUARIO.valueOf(rol) )
