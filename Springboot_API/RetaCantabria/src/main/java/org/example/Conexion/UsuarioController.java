package org.example.Conexion;


import org.example.DTO.UsuarioDTO;
import org.example.Entidades.Usuario;
import org.example.Servicio.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/usuario")
public class UsuarioController {

    private final UsuarioService usuarioService;

    @Autowired
    public UsuarioController(UsuarioService usuarioService) {
        this.usuarioService = usuarioService;
    }

    @GetMapping("/test")
    public String test() {
        return "API funcionando";
    }

    @GetMapping
    /*public List<Usuario> findAll() {
        return usuarioService.listar();
    }
     */
    public List<UsuarioDTO> getUsuarios() {
        return usuarioService.listar()
                .stream()
                .map(UsuarioDTO::new)
                .toList();
    }

    @GetMapping("/buscar")
    public List<Usuario> buscar(@RequestParam String campo, @RequestParam String valor) {
        return usuarioService.buscar(campo, valor);
    }

    @PostMapping
    public Usuario create(@RequestBody Usuario usuario) {
        return usuarioService.crear(usuario);
    }

    @PutMapping("/{id}")
    public Usuario update(@RequestBody Usuario usuario, @PathVariable Long id) {
        return usuarioService.modificar(usuario, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        usuarioService.eliminar(id);
    }
}
