package org.example.Conexion;

import org.example.Entidades.PuntoRuta;
import org.example.Servicio.PuntoRutaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/puntoruta")
public class PuntoRutaController {

    private final PuntoRutaService puntoRutaService;

    @Autowired
    public PuntoRutaController(PuntoRutaService puntoRutaService) {
        this.puntoRutaService = puntoRutaService;
    }

    @GetMapping("/test")
    public String test() {
        return "API PuntoRuta funcionando";
    }

    @GetMapping
    public List<PuntoRuta> findAll() {
        return puntoRutaService.listar();
    }

    @GetMapping("/buscar")
    public List<PuntoRuta> buscar(@RequestParam String campo, @RequestParam String valor) {
        return puntoRutaService.buscar(campo, valor);
    }

    @PostMapping
    public PuntoRuta create(@RequestBody PuntoRuta puntoRuta) {
        return puntoRutaService.crear(puntoRuta);
    }

    @PutMapping("/{id}")
    public PuntoRuta update(@RequestBody PuntoRuta puntoRuta, @PathVariable Long id) {
        return puntoRutaService.modificar(puntoRuta, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        puntoRutaService.eliminar(id);
    }
}
