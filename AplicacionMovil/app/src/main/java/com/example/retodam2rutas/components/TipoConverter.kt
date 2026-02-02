package com.example.retodam2rutas.components

import androidx.room.TypeConverter
import com.example.retodam2rutas.model.CLASIFICACION
import com.example.retodam2rutas.model.TIPOUSUARIO
import java.time.LocalDate
import java.time.LocalDateTime

class TipoConverter {

    //================ Converter de clasificacion =================
    @TypeConverter
    fun fromClasificacion(value: CLASIFICACION?): String? {
        return value?.name
    }

    @TypeConverter
    fun toClasificacion(value: String?): CLASIFICACION {
        return value?.let { CLASIFICACION.valueOf(it) } ?: CLASIFICACION.LINEAL
    }

    //================ Converter de usuario =================
    @TypeConverter
    fun fromTipoUsuario(value: TIPOUSUARIO?): String {
        return value?.name ?: TIPOUSUARIO.alumno.name
    }

    @TypeConverter
    fun toTipoUsuario(value: String?): TIPOUSUARIO {
        return value?.let { TIPOUSUARIO.valueOf(it) } ?: TIPOUSUARIO.alumno
    }

    //================ Converter de LocalDateTime =================
    @TypeConverter
    fun fromLocalDateTime(value: LocalDateTime?): String? =
        value?.toString()

    @TypeConverter
    fun toLocalDateTime(value: String?): LocalDateTime? =
        value?.let { LocalDateTime.parse(it) }

    //================ Converter de LocalDate =================

    @TypeConverter
    fun fromLocalDate(value: LocalDate?): String? =
        value?.toString()

    @TypeConverter
    fun toLocalDate(value: String?): LocalDate? =
        value?.let { LocalDate.parse(it) }
}