package com.example.retodam2rutas.data.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.Index
import androidx.room.PrimaryKey
import java.time.LocalDateTime

@Entity(
    tableName = "valoracion",
    foreignKeys = [
        ForeignKey(
            entity = Usuario::class,
            parentColumns = ["idUsuario"],
            childColumns = ["usuarioId"],
            onDelete = ForeignKey.CASCADE
        ),
        ForeignKey(
            entity = Ruta::class,
            parentColumns = ["idRuta"],
            childColumns = ["rutaId"],
            onDelete = ForeignKey.CASCADE
        )
    ],
    indices = [
        Index(value = ["usuarioId"]),
        Index(value = ["rutaId"])
    ]
)
data class Valoracion(

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "idValora")
    val id: Int = 0,

    @ColumnInfo(name = "dificultad")
    val dificultad: Int,       // 1–5

    @ColumnInfo(name = "belleza")
    val belleza: Int,          // 1–5

    @ColumnInfo(name = "interesCultural")
    val interesCultural: Int,  // 1–5

    @ColumnInfo(name = "fecha")
    val fecha: LocalDateTime,

    @ColumnInfo(name = "usuarioId")
    val usuarioId: Int,

    @ColumnInfo(name = "rutaId")
    val rutaId: Int
)
