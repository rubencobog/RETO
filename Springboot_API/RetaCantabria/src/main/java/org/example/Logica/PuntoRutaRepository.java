package org.example.Logica;

import org.example.Entidades.PuntoRuta;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface PuntoRutaRepository extends JpaRepository<PuntoRuta, Long> {
    @Query("SELECT pr FROM PuntoRuta pr where pr.ruta.idRuta = :idRuta")
    List<PuntoRuta> getpuntosRutas(@Param("idRuta") Long idRuta);
}
