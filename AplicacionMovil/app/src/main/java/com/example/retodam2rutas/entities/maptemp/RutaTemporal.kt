package com.example.retodam2rutas.entities.maptemp

import java.time.LocalDateTime

data class RutaTemporal(
    val nombre: String,
    val trackPoints: MutableList<TrackPoint> = mutableListOf(),
    val inicio: LocalDateTime = LocalDateTime.now()
)

