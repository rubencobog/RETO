package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Resena;
import org.example.Logica.ResenaRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class ResenaService implements IResenaService<Resena, Long> {

    private final ResenaRepository repository;

    public ResenaService(ResenaRepository repository) {
        this.repository = repository;
    }

    @Override
    public Resena crear(Resena resena) {
        return repository.save(resena);
    }

    @Override
    public Resena modificar(Resena resena, Long id) {
        Resena r = repository.findById(id).orElse(null);
        if (r != null) {
            r.setResena(resena.getResena());
            r.setFecha(resena.getFecha());
            return repository.save(r);
        }
        return null;
    }

    @Override
    public List<Resena> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<Resena> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "idresena" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getIdResena().toString().equals(valor))
                    .toList();
            case "resena" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getResena() != null && r.getResena().equalsIgnoreCase(valor))
                    .toList();
            case "fecha" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getFecha() != null && r.getFecha().toString().equals(valor))
                    .toList();
            default -> List.of();
        };
    }
}
