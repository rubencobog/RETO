package org.example.Servicio;

import java.util.List;

public interface ServicioGenerica<T,Long> {
    T crear(T t);
    T modificar(T t,Long id);
    List<T> listar();
    void eliminar(Long id);
    List<T> buscar(String campo,String valor);
}
