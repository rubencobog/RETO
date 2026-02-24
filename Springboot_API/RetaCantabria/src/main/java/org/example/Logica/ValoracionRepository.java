package org.example.Logica;

import org.example.Entidades.Valoracion;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ValoracionRepository extends JpaRepository<Valoracion, Long> {
    List<Valoracion> findByRuta_idRuta(Long idRuta);
}
