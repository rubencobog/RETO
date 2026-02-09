package com.example.retodam2rutas.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.Index
import androidx.room.PrimaryKey
import java.time.LocalTime

@Entity(tableName = "rutas",
    foreignKeys = [
        ForeignKey(
            entity = Usuario::class,
            parentColumns = ["idUsuario"],
            childColumns = ["usuarioId"],
            onDelete = ForeignKey.CASCADE
        )
    ],
    indices = [Index(value = ["usuarioId"])]
)
data class Ruta(

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "idRuta")
    val id: Int,

    @ColumnInfo(name = "nombre")
    val nombre: String,

    @ColumnInfo(name = "nombre_inicioruta", defaultValue = "Inicio")
    val nombreInicioruta: String = "Inicio",

    @ColumnInfo(name = "nombre_finalruta",defaultValue = "Fin")
    val nombreFinalruta: String = "Fin",

    @ColumnInfo(name = "latitudInicial")
    val latitudInicial: Double,

    @ColumnInfo(name = "latitudFinal")
    val latitudFinal: Double,

    @ColumnInfo(name = "longitudInicial")
    val longitudInicial: Double,

    @ColumnInfo(name = "longitudFinal")
    val longitudFinal: Double,

    @ColumnInfo(name = "distancia")
    var distancia: Double,

    @ColumnInfo(name = "duracion")
    var duracion: LocalTime,

    @ColumnInfo(name = "desnivelPositivo")
    var desnivelPositivo: Int,

    @ColumnInfo(name = "desnivelNegativo")
    var desnivelNegativo: Int,

    @ColumnInfo(name = "desnivelAcumulado")
    var desnivelAcumulado: Int,

    @ColumnInfo(name = "altitudMax")
    var altitudMax: Double,

    @ColumnInfo(name = "altitudMin")
    var altitudMin: Double,

    @ColumnInfo(name = "clasificacion", defaultValue = "LINEAL")
    var clasificacion: CLASIFICACION = CLASIFICACION.LINEAL,

    @ColumnInfo(name = "nivelEsfuerzo")
    var nivelEsfuerzo: Byte? = null,

    @ColumnInfo(name = "nivelRiesgo")
    var nivelRiesgo: Byte? = null,

    @ColumnInfo(name = "estadoRuta", defaultValue = "0")
    var estadoRuta: Boolean = false,

    @ColumnInfo(name = "tipoTerreno")
    val tipoTerreno: Byte? = null,

    @ColumnInfo(name = "indicaciones")
    val indicaciones: Byte? = null,

    @ColumnInfo(name = "temporadas")
    val temporadas: String? = null,

    @ColumnInfo(name = "accesibilidad")
    val accesibilidad: Boolean = false,

    @ColumnInfo(name = "rutaFamiliar")
    val rutaFamiliar: Boolean = false,

    @ColumnInfo(name = "archivoGPX")
    val archivoGPX: String? = null,

    @ColumnInfo(name = "recomendacionesEquipo")
    val recomendacionesEquipo: String? = null,

    @ColumnInfo(name = "zonaGeografica")
    val zonaGeografica: String? = null,

    @ColumnInfo(name = "mediaEstrellas")
    val mediaEstrellas: Double? = null,

    @ColumnInfo(name = "usuarioId")
    val usuarioId: Int
)