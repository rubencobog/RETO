package org.example.Conexion;

import org.example.DTO.ResenaDTO;
import org.example.Entidades.Resena;
import org.example.Servicio.ResenaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/resena")
public class ResenaController {

    private final ResenaService resenaService;

    @Autowired
    public ResenaController(ResenaService resenaService) {
        this.resenaService = resenaService;
    }

    @GetMapping("/test")
    public String test() {
        return "API Resena funcionando";
    }

    @GetMapping
    /*
    public List<Resena> findAll() {
        return resenaService.listar();
    }
     */
    public List<ResenaDTO>findAll(){
        return resenaService.listar()
                .stream()
                .map(ResenaDTO::new)
                .toList();
    }

    @GetMapping("/buscar")
    public List<Resena> buscar(@RequestParam String campo, @RequestParam String valor) {
        return resenaService.buscar(campo, valor);
    }

    @PostMapping
    public Resena create(@RequestBody Resena resena) {
        return resenaService.crear(resena);
    }

    @PutMapping("/{id}")
    public Resena update(@RequestBody Resena resena, @PathVariable Long id) {
        return resenaService.modificar(resena, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        resenaService.eliminar(id);
    }
}
