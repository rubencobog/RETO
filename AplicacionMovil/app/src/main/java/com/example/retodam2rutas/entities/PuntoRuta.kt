package com.example.retodam2rutas.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.Index
import androidx.room.PrimaryKey
import java.time.LocalDateTime

@Entity(
    tableName = "puntosRuta",
    foreignKeys = [
        ForeignKey(
            entity = Ruta::class,
            parentColumns = ["idRuta"],
            childColumns = ["rutaId"],
            onDelete = ForeignKey.CASCADE
        )
    ],
    indices = [Index("rutaId")]
)
data class PuntoRuta(

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "id")
    val id: Long = 0L,

    @ColumnInfo(name = "latitud")
    val latitud: Double,

    @ColumnInfo(name = "longitud")
    val longitud: Double,

    @ColumnInfo(name = "elevacion")
    val elevacion: Int,

    @ColumnInfo(name = "timestamp")
    val timeStamp: LocalDateTime,

    @ColumnInfo(name = "rutaId")
    val rutaId: Long? = null
)

