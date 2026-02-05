package com.example.retodam2rutas.data.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.Index
import androidx.room.PrimaryKey
import java.time.LocalDate

@Entity(
    tableName = "resenas",
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
data class Resena(

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "idResena")
    val idResena: Int = 0,

    @ColumnInfo(name = "resena")
    val resena: String,

    @ColumnInfo(name = "fecha")
    val fecha: LocalDate,

    @ColumnInfo(name = "usuarioId")
    val usuarioId: Int,

    @ColumnInfo(name = "rutaId")
    val rutaId: Int
)
