package com.example.retodam2rutas.components

import androidx.room.TypeConverter
import com.example.retodam2rutas.data.entities.CLASIFICACION
import com.example.retodam2rutas.data.entities.TIPOUSUARIO
import java.time.LocalDate
import java.time.LocalDateTime
import java.time.LocalTime
import java.time.format.DateTimeFormatter

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

    //================ Converter de LocalTime =================

    private val formatter = DateTimeFormatter.ISO_LOCAL_TIME

    @TypeConverter
    fun fromLocalTime(time: LocalTime?): String? {
        return time?.format(formatter)
    }

    @TypeConverter
    fun toLocalTime(timeString: String?): LocalTime? {
        return timeString?.let { LocalTime.parse(it, formatter) }
    }
}