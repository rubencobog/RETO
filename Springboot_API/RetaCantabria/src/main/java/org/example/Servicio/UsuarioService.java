package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Usuario;
import org.example.Logica.UsuarioRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class UsuarioService implements IUsuarioService<Usuario, Long> {

    private final UsuarioRepository repository;

    public UsuarioService(UsuarioRepository repository) {
        this.repository = repository;
    }

    @Override
    public Usuario crear(Usuario usuario) {
        return repository.save(usuario);
    }

    public Optional<Usuario> buscarPorID(Long id){
        return repository.findById(id);
    }

    @Override
    public Usuario modificar(Usuario usuario, Long id) {
        Usuario existente = repository.findById(id).orElse(null); // idUsuario es Integer
        if (existente != null) {
            existente.setNombre(usuario.getNombre());
            existente.setApellido(usuario.getApellido());
            existente.setEmail(usuario.getEmail());
            usuario.setPassword(usuario.getPassword());
            existente.setRol(usuario.getRol());
            return repository.save(existente);
        }
        return null;
    }

    @Override
    public List<Usuario> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<Usuario> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(u -> u.getIdUsuario().toString().equals(valor))
                    .toList();
            case "nombre" -> repository.findAll()
                    .stream()
                    .filter(u -> u.getNombre().equalsIgnoreCase(valor))
                    .toList();
            case "apellido" -> repository.findAll()
                    .stream()
                    .filter(u -> u.getApellido().equalsIgnoreCase(valor))
                    .toList();
            case "email" -> repository.findAll()
                    .stream()
                    .filter(u -> u.getEmail().equalsIgnoreCase(valor))
                    .toList();
            case "rol" -> repository.findAll()
                    .stream()
                    .filter(u -> u.getRol().name().equalsIgnoreCase(valor))
                    .toList();
            default -> List.of();
        };
    }
    public Usuario buscarUsuario(String email , String password) {
        return repository.findAll().stream().
                filter(u->u.getEmail().equalsIgnoreCase(email)&&u.getPassword().equals(password))
                .findFirst().orElse(null);
    }
    public Usuario buscarUsuario(long idUsuario) {
        return repository.usuariocreaRuta(idUsuario);
    }
}

