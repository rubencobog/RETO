package com.example.retodam2rutas.model.maptemp

data class RutaTemporal(
    val nombre: String,
    val trackPoints: MutableList<TrackPoint> = mutableListOf()
)

