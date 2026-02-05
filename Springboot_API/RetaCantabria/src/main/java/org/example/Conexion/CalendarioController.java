package org.example.Conexion;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.example.DTO.CalendarioDTO;
import org.example.Entidades.Calendario;
import org.example.Entidades.Ruta;
import org.example.Entidades.Usuario;
import org.example.Servicio.CalendarioService;
import org.example.Servicio.RutaService;
import org.example.Servicio.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.List;

@RestController
@RequestMapping("/api/calendario")
public class CalendarioController {

    private final CalendarioService calendarioService;
    private final RutaService rutaService;
    private final UsuarioService usuarioService;

    @Autowired
    public CalendarioController(CalendarioService calendarioService, RutaService rutaService, UsuarioService usuarioService) {
        this.calendarioService = calendarioService;
        this.rutaService = rutaService;
        this.usuarioService = usuarioService;
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
    public Calendario create(@RequestBody CalendarioDTO calendarioDTO) {
        if (calendarioDTO.idRuta() == null || calendarioDTO.idUsuario() == null) {
            System.err.println("ID Ruta: " + calendarioDTO.idRuta());
            System.err.println("ID Usuario: " + calendarioDTO.idUsuario());
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Falta idRuta o idUsuario");
        }
        Ruta ruta=rutaService.buscarPorId(calendarioDTO.idRuta()).orElseThrow(() -> new ResponseStatusException(
                HttpStatus.NOT_FOUND, "Ruta no encontrada"));
        Usuario usuario=usuarioService.buscarPorID(calendarioDTO.idUsuario()).orElseThrow(() -> new ResponseStatusException(
                HttpStatus.NOT_FOUND, "Usuario no encontrado"));
        LocalDate fecha = LocalDate.parse(calendarioDTO.fecha(), DateTimeFormatter.ofPattern("yyyy-MM-dd"));
        Calendario calendario=new Calendario();
        calendario.setFecha(fecha);
        calendario.setDetalles(calendarioDTO.detalles());
        calendario.setRecomendaciones(calendarioDTO.recomendaciones());
        calendario.setRutasIdruta(ruta);
        calendario.setUsuarioIdusuario(usuario);
        System.out.println(calendario.toString());
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