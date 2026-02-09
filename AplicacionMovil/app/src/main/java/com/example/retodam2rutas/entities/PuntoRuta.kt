package com.example.retodam2rutas.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.time.LocalDateTime

@Entity(tableName = "puntosRuta")
data class PuntoRuta(

    @PrimaryKey
    @ColumnInfo(name = "id")
    val id: Long,

    @ColumnInfo(name = "latitud")
    val latitud: Double,

    @ColumnInfo(name = "longitud")
    val longitud: Double,

    @ColumnInfo(name = "elevacion")
    val elevacion: Int,

    @ColumnInfo(name = "timestamp")
    val timeStamp: LocalDateTime,
)
