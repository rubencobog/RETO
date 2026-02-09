package org.example.Logica;


import org.example.Entidades.Calendario;
import org.example.Entidades.Ruta;
import org.springframework.data.jpa.repository.JpaRepository;

import java.time.LocalDate;
import java.util.Optional;

public interface CalendarioRepository extends JpaRepository<Calendario, Long> {
    Optional<Calendario> findByFechaAndRutasIdruta(
            LocalDate fecha,
            Ruta ruta
    );
}
