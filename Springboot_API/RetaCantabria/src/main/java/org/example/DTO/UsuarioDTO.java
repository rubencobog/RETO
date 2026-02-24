package org.example.DTO;

import org.example.Entidades.TIPOUSUARIO;
import org.example.Entidades.Usuario;

public record UsuarioDTO(
        Long idUsuario,
        String nombre,
        String apellido,
        String email,
        String password,
        TIPOUSUARIO rol
) {
    public UsuarioDTO(Usuario usu){
        this(
                usu.getIdUsuario(),
                usu.getNombre(),
                usu.getApellido(),
                usu.getEmail(),
                usu.getPassword(),
                usu.getRol()
        );
    }
}
