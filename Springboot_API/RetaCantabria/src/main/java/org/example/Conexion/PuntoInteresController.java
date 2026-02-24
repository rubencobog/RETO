package org.example.Conexion;

import org.example.Entidades.PuntoInteres;
import org.example.Servicio.PuntoInteresService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/puntointeres")
public class PuntoInteresController {

    private final PuntoInteresService puntoInteresService;

    @Autowired
    public PuntoInteresController(PuntoInteresService puntoInteresService) {
        this.puntoInteresService = puntoInteresService;
    }

    @GetMapping("/test")
    public String test() {
        return "API PuntoInteres funcionando";
    }

    @GetMapping
    public List<PuntoInteres> findAll() {
        return puntoInteresService.listar();
    }

    @GetMapping("/buscar")
    public List<PuntoInteres> buscar(@RequestParam String campo, @RequestParam String valor) {
        return puntoInteresService.buscar(campo, valor);
    }

    @PostMapping
    public PuntoInteres create(@RequestBody PuntoInteres puntoInteres) {
        return puntoInteresService.crear(puntoInteres);
    }

    @PutMapping("/{id}")
    public PuntoInteres update(@RequestBody PuntoInteres puntoInteres, @PathVariable Long id) {
        return puntoInteresService.modificar(puntoInteres, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        puntoInteresService.eliminar(id);
    }
}