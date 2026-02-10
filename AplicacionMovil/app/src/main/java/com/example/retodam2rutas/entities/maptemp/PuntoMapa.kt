package com.example.retodam2rutas.entities.maptemp

import org.osmdroid.util.GeoPoint

data class PuntoMapa(
    val id: Long,
    val geoPoint: GeoPoint,
    val tipo: TipoPuntoMapa
)
