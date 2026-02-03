package org.example.DTO;

import org.example.Entidades.Valoracion;

import java.time.LocalDateTime;

public record ValoracionDTO(
        Long idRuta,
        Long idUsuario,
        Integer dificultad,
        Integer belleza,
        Integer interesCultural,
        LocalDateTime fecha
) {
    public ValoracionDTO(Valoracion val) {
        this(
                val.getRuta().getIdRuta(),
                val.getUsuario().getIdUsuario(),
                val.getDificultad(),
                val.getBelleza(),
                val.getInteresCultural(),
                val.getFecha()
        );
    }
}
