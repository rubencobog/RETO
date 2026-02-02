package com.example.retodam2rutas.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.time.LocalDateTime

@Entity(tableName = "puntosRuta")
data class PuntoRuta(

    @PrimaryKey
    @ColumnInfo(name = "id")
    val id: Int,

    @ColumnInfo(name = "latitud")
    val latitud: Int,

    @ColumnInfo(name = "longitud")
    val longitud: Int,

    @ColumnInfo(name = "elevacion")
    val elevacion: Int,

    @ColumnInfo(name = "timestamp")
    val timeStamp: LocalDateTime,
)
