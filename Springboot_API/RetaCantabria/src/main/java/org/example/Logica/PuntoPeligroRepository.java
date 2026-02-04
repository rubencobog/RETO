package org.example.Logica;


import org.example.Entidades.PuntoPeligro;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface PuntoPeligroRepository extends JpaRepository<PuntoPeligro, Long> {
@Query("SELECT pp FROM PuntoPeligro pp  WHERE pp.puntoRuta.idPuntoRuta = :idPP")
 List<PuntoPeligro> getPuntoPeligro(@Param("idRuta") long  id);
}
