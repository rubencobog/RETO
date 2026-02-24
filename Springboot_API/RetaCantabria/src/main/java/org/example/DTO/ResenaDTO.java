package org.example.DTO;

import org.example.Entidades.Resena;

import java.time.LocalDate;

public record ResenaDTO(
        Long idRuta,
        Long idUsuario,
        String resena,
        LocalDate fecha
) {
    public ResenaDTO(Resena res){
        this(
        res.getRuta().getIdRuta(),
        res.getUsuario().getIdUsuario(),
        res.getResena(),
        res.getFecha()
        );
    }
}
