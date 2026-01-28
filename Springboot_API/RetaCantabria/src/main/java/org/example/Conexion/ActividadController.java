package org.example.Conexion;

import org.example.Entidades.Actividad;
import org.example.Servicio.ActividadService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/actividad")
public class ActividadController {

    private final ActividadService actividadService;

    @Autowired
    public ActividadController(ActividadService actividadService) {
        this.actividadService = actividadService;
    }

    @GetMapping("/test")
    public String test() {
        return "API Actividad funcionando";
    }

    @GetMapping
    public List<Actividad> findAll() {
        return actividadService.listar();
    }

    @GetMapping("/buscar")
    public List<Actividad> buscar(@RequestParam String campo, @RequestParam String valor) {
        return actividadService.buscar(campo, valor);
    }

    @PostMapping
    public Actividad create(@RequestBody Actividad actividad) {
        return actividadService.crear(actividad);
    }

    @PutMapping("/{id}")
    public Actividad update(@RequestBody Actividad actividad, @PathVariable Long id) {
        return actividadService.modificar(actividad, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        actividadService.eliminar(id);
    }
}
