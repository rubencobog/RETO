package org.example.Conexion;

import org.example.Entidades.TrackPoint;
import org.example.Servicio.TrackPointService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/trackpoint")
public class TrackPointController {

    private final TrackPointService trackPointService;

    @Autowired
    public TrackPointController(TrackPointService trackPointService) {
        this.trackPointService = trackPointService;
    }

    @GetMapping("/test")
    public String test() {
        return "API TrackPoint funcionando";
    }

    @GetMapping
    public List<TrackPoint> findAll() {
        return trackPointService.listar();
    }

    @GetMapping("/buscar")
    public List<TrackPoint> buscar(@RequestParam String campo, @RequestParam String valor) {
        return trackPointService.buscar(campo, valor);
    }

    @PostMapping
    public TrackPoint create(@RequestBody TrackPoint trackPoint) {
        return trackPointService.crear(trackPoint);
    }

    @PutMapping("/{id}")
    public TrackPoint update(@RequestBody TrackPoint trackPoint, @PathVariable Long id) {
        return trackPointService.modificar(trackPoint, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        trackPointService.eliminar(id);
    }

    @GetMapping("/buscarRuta")
    public List<TrackPoint> findAllByRuta(@RequestParam Long idRuta) {
        return trackPointService.findAllByRuta(idRuta);
    }
}
