package org.example.Logica;

import org.example.Entidades.TrackPoint;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.List;

@Repository
public interface TrackPointRepository extends JpaRepository<TrackPoint, Long> {
    @Query("SELECT t FROM TrackPoint t WHERE t.ruta.idRuta = :rutaId")
    List<TrackPoint> findbyRuta(@Param("rutaId") long idRuta);
}
