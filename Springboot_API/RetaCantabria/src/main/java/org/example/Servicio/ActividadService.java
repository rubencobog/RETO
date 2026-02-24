package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Actividad;
import org.example.Logica.ActividadRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class ActividadService implements IActividadService<Actividad, Long> {

    private final ActividadRepository repository;

    public ActividadService(ActividadRepository repository) {
        this.repository = repository;
    }

    @Override
    public Actividad crear(Actividad actividad) {
        return repository.save(actividad);
    }

    @Override
    public Actividad modificar(Actividad actividad, Long id) {
        Actividad act = repository.findById(id).orElse(null);
        if (act != null) {
            act.setNombre(actividad.getNombre());
            return repository.save(act);
        }
        return null;
    }

    @Override
    public List<Actividad> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<Actividad> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()// pasar de List a flujo de datos(stream)
                    .filter(a -> a.getId().toString().equals(valor))// filtrar el flujo de datos
                    .toList();// pasar de flujo de datos(stream) a List
            case "nombre" -> repository.findAll()
                    .stream()
                    .filter(a -> a.getNombre().equalsIgnoreCase(valor))
                    .toList();
            default -> List.of();
        };
    }
}