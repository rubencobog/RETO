package org.example.Conexion;

import org.example.DTO.ResenaDTO;
import org.example.DTO.ResenaDevueltaDTO;
import org.example.Entidades.Resena;
import org.example.Entidades.Ruta;
import org.example.Entidades.Usuario;
import org.example.Servicio.ResenaService;
import org.example.Servicio.RutaService;
import org.example.Servicio.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/resena")
public class ResenaController {

    private final ResenaService resenaService;
    private final RutaService rutaService;
    private final UsuarioService usuarioService;

    @Autowired
    public ResenaController(ResenaService resenaService,RutaService rutaService,UsuarioService usuarioService) {
        this.resenaService = resenaService;
        this.rutaService=rutaService;
        this.usuarioService=usuarioService;
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

    @GetMapping("/buscar/{idRuta}")
    public ResponseEntity<List<ResenaDevueltaDTO>>buscarPorRuta(@PathVariable("idRuta") long idRuta){
        List<Resena>resenas=resenaService.obtenerResenasPorRuta(idRuta);
        List<ResenaDevueltaDTO>resenasDevueltas=new ArrayList<>();
        for(Resena res:resenas){
            resenasDevueltas.add(new ResenaDevueltaDTO(res));
        }
        return ResponseEntity.ok(resenasDevueltas);
    }

    @GetMapping("/buscar")
    public List<Resena> buscar(@RequestParam String campo, @RequestParam String valor) {
        return resenaService.buscar(campo, valor);
    }

    @PostMapping
    public Resena create(@RequestBody ResenaDTO resenadto) {
        if (resenadto.idUsuario() == null || resenadto.idRuta() == null) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "idUsuario o idRuta es null");
        }
        Usuario usuario = usuarioService.buscarPorID(resenadto.idUsuario())
                .orElseThrow(() -> new ResponseStatusException(
                        HttpStatus.NOT_FOUND, "Usuario no encontrado"
                ));
        Ruta ruta=rutaService.buscarPorId(resenadto.idRuta()).orElseThrow(() -> new ResponseStatusException(
                HttpStatus.NOT_FOUND, "Ruta no encontrada"
        ));
        Resena resena=new Resena();
        resena.setFecha(resenadto.fecha());
        resena.setResena(resenadto.resena());
        resena.setRuta(ruta);
        resena.setUsuario(usuario);

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
