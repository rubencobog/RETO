package org.example.DTO;

import org.example.Entidades.Ruta;

import java.time.LocalTime;

public record RutaDTO(
        Integer idRuta,
        String nombre,
        String nombreInicioruta,
        String nombreFinalruta,
        Double distancia,
        LocalTime duracion,
        Double mediaEstrellas,
        String zonaGeografica
) {
    public RutaDTO(Ruta r) {
        this(
                r.getIdRuta(),
                r.getNombre(),
                r.getNombreInicioruta(),
                r.getNombreFinalruta(),
                r.getDistancia(),
                r.getDuracion(),
                r.getMediaEstrellas(),
                r.getZonaGeografica()
        );
    }
}
