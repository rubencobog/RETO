package org.example.Conexion;

import org.example.DTO.ValoracionDTO;
import org.example.Entidades.Resena;
import org.example.Entidades.Ruta;
import org.example.Entidades.Usuario;
import org.example.Entidades.Valoracion;
import org.example.Servicio.RutaService;
import org.example.Servicio.UsuarioService;
import org.example.Servicio.ValoracionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

@RestController
@RequestMapping("/api/valoracion")
public class ValoracionController {

    private final ValoracionService valoracionService;
    private final RutaService rutaService;
    private final UsuarioService usuarioService;

    @Autowired
    public ValoracionController(ValoracionService valoracionService,RutaService rutaService,UsuarioService usuarioService) {
        this.valoracionService = valoracionService;
        this.rutaService=rutaService;
        this.usuarioService=usuarioService;
    }

    @GetMapping("/test")
    public String test() {
        return "API Valoracion funcionando";
    }

    @GetMapping
    /*
    public List<Valoracion> findAll() {
        return valoracionService.listar();
    }
     */
    public List<ValoracionDTO>findAll(){
        return valoracionService.listar()
                .stream()
                .map(ValoracionDTO::new)
                .toList();
    }

    @GetMapping("/buscar")
    public List<Valoracion> buscar(@RequestParam String campo, @RequestParam String valor) {
        return valoracionService.buscar(campo, valor);
    }
    @GetMapping("/buscar/{idRuta}")
    public ResponseEntity<List<Valoracion>> buscarPorRuta(@PathVariable("idRuta") Long idRuta){
        List<Valoracion>valoraciones=valoracionService.obtenerValoracionesPorRuta(idRuta);
        return ResponseEntity.ok(valoraciones);
    }

    @PostMapping
    public Valoracion create(@RequestBody ValoracionDTO valoracionDTO) {
        Ruta ruta=rutaService.buscarPorId(valoracionDTO.idRuta()).orElseThrow(() -> new ResponseStatusException(
                HttpStatus.NOT_FOUND, "Ruta no encontrada"));

        Usuario usuario=usuarioService.buscarPorID(valoracionDTO.idUsuario()).orElseThrow(() -> new ResponseStatusException(
                HttpStatus.NOT_FOUND, "Usuario no encontrado"));

        Valoracion valoracion=new Valoracion();
        valoracion.setRuta(ruta);
        valoracion.setUsuario(usuario);
        valoracion.setDificultad(valoracionDTO.dificultad());
        valoracion.setBelleza(valoracionDTO.belleza());
        valoracion.setInteresCultural(valoracionDTO.interesCultural());
        valoracion.setFecha(valoracionDTO.fecha().toLocalDateTime());

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
