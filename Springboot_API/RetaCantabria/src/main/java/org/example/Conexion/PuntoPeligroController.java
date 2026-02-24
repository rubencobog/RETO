package org.example.Conexion;

import org.example.Entidades.PuntoPeligro;
import org.example.Servicio.PuntoPeligroService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/puntopeligro")
public class PuntoPeligroController {

    private final PuntoPeligroService puntoPeligroService;

    @Autowired
    public PuntoPeligroController(PuntoPeligroService puntoPeligroService) {
        this.puntoPeligroService = puntoPeligroService;
    }

    @GetMapping("/test")
    public String test() {
        return "API PuntoPeligro funcionando";
    }

    @GetMapping
    public List<PuntoPeligro> findAll() {
        return puntoPeligroService.listar();
    }

    @GetMapping("/buscar")
    public List<PuntoPeligro> buscar(@RequestParam String campo, @RequestParam String valor) {
        return puntoPeligroService.buscar(campo, valor);
    }

    @PostMapping
    public PuntoPeligro create(@RequestBody PuntoPeligro puntoPeligro) {
        return puntoPeligroService.crear(puntoPeligro);
    }

    @PutMapping("/{id}")
    public PuntoPeligro update(@RequestBody PuntoPeligro puntoPeligro, @PathVariable Long id) {
        return puntoPeligroService.modificar(puntoPeligro, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        puntoPeligroService.eliminar(id);
    }

    @GetMapping("/buscaPP")
    public List<PuntoPeligro> buscarppruta(@RequestParam Long idRuta){
        return puntoPeligroService.puntospeligroRuta(idRuta);
    }
}
