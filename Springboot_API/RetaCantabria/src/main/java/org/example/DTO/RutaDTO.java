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
        Double distancia,
        @JsonFormat(pattern = "HH:mm:ss")
        LocalTime duracion,
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
                r.getDistancia(),
                r.getDuracion(),
                r.getMediaEstrellas(),
                r.getZonaGeografica(),
                r.isEstadoRuta(),
                r.isRutaFamiliar(),
                r.isRutaFamiliar(),
                r.getClasificacion()
        );
    }
}
