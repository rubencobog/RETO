package com.example.retodam2rutas.entities.maptemp

data class RutaTemporal(
    val nombre: String,
    val trackPoints: MutableList<TrackPoint> = mutableListOf()
)

