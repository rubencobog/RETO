package org.example.Logica;

import org.example.Entidades.Waypoint;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface WaypointRepository extends JpaRepository<Waypoint, Long> {
 @Query("SELECT w FROM Waypoint w Where w.ruta.idRuta = :rutaId")
 List<Waypoint> findByRuta(@Param("rutaId") Long rutaId);
}
