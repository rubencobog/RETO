package org.example.Logica;

import org.example.Entidades.Resena;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ResenaRepository extends JpaRepository<Resena, Long> {
    List<Resena> findByRuta_IdRuta(Long idRuta);
}
