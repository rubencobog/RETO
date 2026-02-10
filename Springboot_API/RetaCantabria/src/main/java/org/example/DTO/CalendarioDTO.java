package org.example.DTO;

import com.fasterxml.jackson.annotation.JsonFormat;
import org.example.Entidades.Calendario;

import java.time.LocalDate;
import java.time.LocalDateTime;

public record CalendarioDTO(
        String fecha,
        String detalles,
        String recomendaciones,
        Long idRuta,
        Long idUsuario

) {
    public CalendarioDTO(Calendario calendario) {
        this(
                calendario.getFecha().toString(),
                calendario.getDetalles(),
                calendario.getRecomendaciones(),
                calendario.getRutasIdruta().getIdRuta(),
                calendario.getUsuarioIdusuario().getIdUsuario()
        );
    }
}
