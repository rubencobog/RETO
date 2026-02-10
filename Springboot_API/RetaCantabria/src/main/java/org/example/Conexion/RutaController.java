package org.example.Conexion;

import org.example.DTO.RutaDTO;
import org.example.Entidades.Ruta;
import org.example.Servicio.RutaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

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

    @GetMapping("/{id}")
    public RutaDTO buscarPorId(@PathVariable Long id) {
        Ruta ruta = rutaService.buscarPorId(id).orElseThrow(() -> new ResponseStatusException(
                HttpStatus.NOT_FOUND, "Ruta no encontrada"));
        return new RutaDTO(ruta);
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
    @GetMapping
    public List<RutaDTO> listar() {
            return rutaService.listar()
                    .stream()
                    .map(RutaDTO::new)
                    .toList();
        }

    @GetMapping("/buscar")
    public List<Ruta> buscar(@RequestParam String campo, @RequestParam String valor) {
        return rutaService.buscar(campo, valor);
    }

    @PostMapping
    public ResponseEntity<Long> create(@RequestBody Ruta ruta) {
        Ruta creada = rutaService.crear(ruta);
        return ResponseEntity.ok(creada.getIdRuta());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Void> update(@RequestBody Ruta ruta, @PathVariable Long id) {
        rutaService.modificar(ruta, id);
        return ResponseEntity.ok().build();
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        rutaService.eliminar(id);
    }
}
