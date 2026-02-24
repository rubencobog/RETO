package org.example.Conexion;


import org.example.DTO.UsuarioDTO;
import org.example.Entidades.Usuario;
import org.example.Servicio.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.ArrayList;
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
    public List<UsuarioDTO> getUsuarios() {
        return usuarioService.listar()
                .stream()
                .map(UsuarioDTO::new)
                .toList();

    }

    @GetMapping("/buscar")
    public List<UsuarioDTO> buscar(@RequestParam String campo, @RequestParam String valor) {
        List<Usuario>usuarios=usuarioService.buscar(campo, valor);
        List<UsuarioDTO>usuariosDTO=new ArrayList<>();
        for(Usuario usu:usuarios){
            usuariosDTO.add(new UsuarioDTO(usu));
        }
        return usuariosDTO;
    }

    @PostMapping
    public ResponseEntity<UsuarioDTO> create(@RequestBody Usuario usuario) {
        Usuario usu=usuarioService.crear(usuario);
        return ResponseEntity.ok(new UsuarioDTO(usu));
    }

    @PutMapping("/{id}")
    public Usuario update(@RequestBody UsuarioDTO usuarioDTO, @PathVariable Long id) {
        Usuario usuario=usuarioService.buscarPorID(id).orElseThrow(()->new ResponseStatusException(HttpStatus.NOT_FOUND, "Usuario no encontrado"));
        if(usuario!=null){
            usuario.setNombre(usuarioDTO.nombre());
            usuario.setApellido(usuarioDTO.apellido());
            usuario.setEmail(usuarioDTO.email());
            usuario.setPassword(usuarioDTO.password());
            usuario.setRol(usuarioDTO.rol());
        }
        return usuarioService.modificar(usuario, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        usuarioService.eliminar(id);
    }

    @GetMapping("/login")
    public UsuarioDTO login(@RequestParam("email") String email, @RequestParam("password") String password) {
        Usuario usu=usuarioService.buscarUsuario(email, password);
        return new UsuarioDTO(usu);
    }
    @GetMapping("/buscaUsu/{idUsuario}")
    public Usuario buscaUsuario(@PathVariable long idUsuario) {
        return usuarioService.buscarUsuario(idUsuario);
    }
}
