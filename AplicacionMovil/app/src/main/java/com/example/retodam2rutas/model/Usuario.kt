package com.example.retodam2rutas.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "usuario")
data class Usuario(

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "idUsuario")
    val idUsuario: Int = 0,

    @ColumnInfo(name = "nombre")
    val nombre: String,

    @ColumnInfo(name = "apellido")
    val apellido: String,

    @ColumnInfo(name = "email")
    val email: String,

    @ColumnInfo(name = "password")
    val password: String,

    @ColumnInfo(name = "rol", defaultValue = "alumno")
    val rol: TIPOUSUARIO = TIPOUSUARIO.alumno
)
