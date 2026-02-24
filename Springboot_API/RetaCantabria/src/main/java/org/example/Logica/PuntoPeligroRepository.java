package org.example.Logica;


import org.example.Entidades.PuntoPeligro;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface PuntoPeligroRepository extends JpaRepository<PuntoPeligro, Long> {
@Query("Select pp from PuntoPeligro pp join pp.puntoRuta pr join pr.ruta r where r.idRuta= :idRuta")
 List<PuntoPeligro> getPuntoPeligro(@Param("idRuta") long  id);
}
