package org.example.DTO;

import com.fasterxml.jackson.annotation.JsonFormat;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import org.example.Entidades.CLASIFICACION;
import org.example.Entidades.Ruta;

import java.time.LocalTime;

public record RutaDTO(
        Long idRuta,
        Long idUsuario,
        String nombre,
        String nombreInicioruta,
        String nombreFinalruta,

        double latitudInicial,
        double latitudFinal,
        double longitudInicial,
        double longitudFinal,
        Double distancia,
        @JsonFormat(pattern = "HH:mm:ss")
        LocalTime duracion,
        Integer desnivelPositivo,
        Integer desnivelNegativo,

        Integer desnivelAcumulado,
        Double altitudMax,
        Double altitudMin,
        Byte nivelEsfuerzo,
        Byte nivelRiesgo,
        Byte tipoTerreno,
        Byte indicaciones,
        String temporadas,
        String recomendacionesEquipo,
        Double mediaEstrellas,
        String zonaGeografica,
        Boolean estadoRuta,
        Boolean accesible,
        Boolean familiar,
        @Enumerated(EnumType.STRING)
        CLASIFICACION clasificacion
) {
    public RutaDTO(Ruta r) {
        this(
                r.getIdRuta(),
                r.getUsuarioIdusuario().getIdUsuario(),
                r.getNombre(),
                r.getNombreInicioruta(),
                r.getNombreFinalruta(),
                r.getLatitudInicial(),
                r.getLatitudFinal(),
                r.getLongitudInicial(),
                r.getLongitudFinal(),
                r.getDistancia(),
                r.getDuracion(),
                r.getDesnivelPositivo(),
                r.getDesnivelNegativo(),
                r.getDesnivelAcumulado(),
                r.getAltitudMax(),
                r.getAltitudMin(),
                r.getNivelEsfuerzo(),
                r.getNivelRiesgo(),
                r.getTipoTerreno(),
                r.getIndicaciones(),
                r.getTemporadas(),
                r.getRecomendacionesEquipo(),
                r.getMediaEstrellas(),
                r.getZonaGeografica(),
                r.isEstadoRuta(),
                r.isRutaFamiliar(),
                r.isRutaFamiliar(),
                r.getClasificacion()
        );
    }
}
