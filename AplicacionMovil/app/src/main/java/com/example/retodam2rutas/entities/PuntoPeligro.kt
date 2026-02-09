package com.example.retodam2rutas.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.Index
import androidx.room.PrimaryKey

@Entity(
    tableName = "puntosPeligro",
    foreignKeys = [
        ForeignKey(
            entity = PuntoRuta::class,
            parentColumns = ["id"],
            childColumns = ["puntoRutaId"],
            onDelete = ForeignKey.CASCADE
        )
    ],
    indices = [Index("puntoRutaId")]
)
data class PuntoPeligro(

    @PrimaryKey(autoGenerate = true)
    val id: Long = 0,

    val kilometro: Double?,

    val gravedad: Byte,

    val justificacion: String?,

    @ColumnInfo(name = "puntoRutaId")
    val puntoRutaId: Long
)

