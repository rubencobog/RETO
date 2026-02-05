package org.example.Conexion;

import org.example.DTO.RutaDTO;
import org.example.Entidades.Ruta;
import org.example.Servicio.RutaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/ruta")
public class RutaController {

    private final RutaService rutaService;

    @Autowired
    public RutaController(RutaService rutaService) {
        this.rutaService = rutaService;
    }

    @GetMapping("/test")
    public String test() {
        return "API Ruta funcionando";
    }

    @GetMapping
     public List<Ruta> findAll() {
        return rutaService.listar();
    }

/*
    //ENTIDAD PARA NO MOSTRAR TODOS LOS DATOS
    public List<RutaDTO> findAll() {
        return rutaService.listar()
                .stream()
                .map(RutaDTO::new)
                .toList();
    }
*/

    @GetMapping("/buscar")
    public List<Ruta> buscar(@RequestParam String campo, @RequestParam String valor) {
        return rutaService.buscar(campo, valor);
    }

    @PostMapping
    public Ruta create(@RequestBody Ruta ruta) {
        return rutaService.crear(ruta);
    }

    @PutMapping("/{id}")
    public Ruta update(@RequestBody Ruta ruta, @PathVariable Long id) {
        return rutaService.modificar(ruta, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        rutaService.eliminar(id);
    }
}
