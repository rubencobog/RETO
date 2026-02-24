package org.example.DTO;

import org.example.Entidades.Valoracion;

import java.time.LocalDateTime;
import java.time.OffsetDateTime;
import java.time.ZoneOffset;

public record ValoracionDTO(
        Long idRuta,
        Long idUsuario,
        Integer dificultad,
        Integer belleza,
        Integer interesCultural,
        OffsetDateTime fecha
) {
    public ValoracionDTO(Valoracion val) {
        this(
                val.getRuta().getIdRuta(),
                val.getUsuario().getIdUsuario(),
                val.getDificultad(),
                val.getBelleza(),
                val.getInteresCultural(),
                OffsetDateTime.of(val.getFecha(), ZoneOffset.of("-08:00"))
        );
    }
}
