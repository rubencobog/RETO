package org.example.Conexion;

import org.example.Entidades.Waypoint;
import org.example.Servicio.WaypointService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/waypoint")
public class WaypointController {

    private final WaypointService waypointService;

    @Autowired
    public WaypointController(WaypointService waypointService) {
        this.waypointService = waypointService;
    }

    @GetMapping("/test")
    public String test() {
        return "API Waypoint funcionando";
    }

    @GetMapping
    public List<Waypoint> findAll() {
        return waypointService.listar();
    }

    @GetMapping("/buscar")
    public List<Waypoint> buscar(@RequestParam String campo, @RequestParam String valor) {
        return waypointService.buscar(campo, valor);
    }

    @PostMapping
    public Waypoint create(@RequestBody Waypoint waypoint) {
        return waypointService.crear(waypoint);
    }

    @PutMapping("/{id}")
    public Waypoint update(@RequestBody Waypoint waypoint, @PathVariable Long id) {
        return waypointService.modificar(waypoint, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        waypointService.eliminar(id);
    }

    @GetMapping("/buscarRuta")
    public List<Waypoint> findAllByRuta(@RequestParam long idRuta) {
        return waypointService.findAllByRuta(idRuta);
    }
}
