package com.example.retodam2rutas.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.Index
import androidx.room.PrimaryKey

@Entity(
    tableName = "puntosInteres",
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
data class PuntoInteres(

    @PrimaryKey(autoGenerate = true)
    val id: Long = 0,

    val nombre: String,

    @ColumnInfo(defaultValue = "naturaleza")
    val tipo: TIPOPI = TIPOPI.naturaleza,

    @ColumnInfo(name = "caracteristicas_especiales")
    val caracteristicasEspeciales: String? = null,

    @ColumnInfo(name = "puntoRutaId")
    val puntoRutaId: Long
)

