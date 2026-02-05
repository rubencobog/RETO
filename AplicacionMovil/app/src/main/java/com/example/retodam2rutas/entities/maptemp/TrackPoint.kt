package com.example.retodam2rutas.entities.maptemp

import java.time.LocalDateTime

data class TrackPoint(
    val latitude: Double,
    val longitude: Double,
    val timestamp: LocalDateTime = LocalDateTime.now()
)

