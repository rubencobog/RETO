package org.example.Conexion;

import org.example.Entidades.Calendario;
import org.example.Servicio.CalendarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/calendario")
public class CalendarioController {

    private final CalendarioService calendarioService;

    @Autowired
    public CalendarioController(CalendarioService calendarioService) {
        this.calendarioService = calendarioService;
    }

    @GetMapping("/test")
    public String test() {
        return "API Calendario funcionando";
    }

    @GetMapping
    public List<Calendario> findAll() {
        return calendarioService.listar();
    }

    @GetMapping("/buscar")
    public List<Calendario> buscar(@RequestParam String campo, @RequestParam String valor) {
        return calendarioService.buscar(campo, valor);
    }

    @PostMapping
    public Calendario create(@RequestBody Calendario calendario) {
        return calendarioService.crear(calendario);
    }

    @PutMapping("/{id}")
    public Calendario update(@RequestBody Calendario calendario, @PathVariable Long id) {
        return calendarioService.modificar(calendario, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        calendarioService.eliminar(id);
    }
}