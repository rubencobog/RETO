package org.example.DTO;

import org.example.Entidades.Valoracion;

import java.time.OffsetDateTime;
import java.time.ZoneOffset;

public record ValoracionDevueltaDTO (
        int idValoracion,
        int dificultad,
        int belleza,
        int interesCultura,
        String nomUsuario,
        String nomRuta,
        OffsetDateTime fecha
){
    public ValoracionDevueltaDTO(Valoracion val) {
        this(
                val.getId(),
                val.getDificultad(),
                val.getBelleza(),
                val.getInteresCultural(),
                val.getUsuario().getNombre(),
                val.getRuta().getNombre(),
                OffsetDateTime.of(val.getFecha(), ZoneOffset.of("-08:00"))
        );
    }
}
