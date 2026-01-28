package org.example.Conexion;

import org.example.Entidades.Valoracion;
import org.example.Servicio.ValoracionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/valoracion")
public class ValoracionController {

    private final ValoracionService valoracionService;

    @Autowired
    public ValoracionController(ValoracionService valoracionService) {
        this.valoracionService = valoracionService;
    }

    @GetMapping("/test")
    public String test() {
        return "API Valoracion funcionando";
    }

    @GetMapping
    public List<Valoracion> findAll() {
        return valoracionService.listar();
    }

    @GetMapping("/buscar")
    public List<Valoracion> buscar(@RequestParam String campo, @RequestParam String valor) {
        return valoracionService.buscar(campo, valor);
    }

    @PostMapping
    public Valoracion create(@RequestBody Valoracion valoracion) {
        return valoracionService.crear(valoracion);
    }

    @PutMapping("/{id}")
    public Valoracion update(@RequestBody Valoracion valoracion, @PathVariable Long id) {
        return valoracionService.modificar(valoracion, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        valoracionService.eliminar(id);
    }
}
