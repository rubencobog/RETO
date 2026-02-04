package org.example.DTO;

import org.example.Entidades.Resena;

import java.time.LocalDate;

public record ResenaDevueltaDTO (
    int idResena,
    String resena,
    LocalDate fecha,
    String nomUsuario,
    String nomRuta
    )
{
    public ResenaDevueltaDTO(Resena resena){
        this(
                resena.getIdResena(),
                resena.getResena(),
                resena.getFecha(),
                resena.getUsuario().getNombre(),
                resena.getRuta().getNombre()
                );
    }
}
