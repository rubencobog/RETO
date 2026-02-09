package org.example.DTO;

import org.example.Entidades.Ruta;

import java.time.LocalTime;

public record RutaDTO(
        Long idRuta,
        Long idUsuario,
        String nombre,
        String nombreInicioruta,
        String nombreFinalruta,
        Double distancia,
        LocalTime duracion,
        Double mediaEstrellas,
        String zonaGeografica,
        Boolean estadoRuta
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
                r.isEstadoRuta()
        );
    }
}
