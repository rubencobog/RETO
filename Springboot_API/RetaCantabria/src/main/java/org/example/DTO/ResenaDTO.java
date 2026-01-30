package org.example.DTO;

import org.example.Entidades.Resena;

import java.time.LocalDate;

public record ResenaDTO(
        Integer idRuta,
        Integer idUsuario,
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
