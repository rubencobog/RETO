package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Calendario;
import org.example.Logica.CalendarioRepository;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
@Transactional
public class CalendarioService implements ICalendarioService<Calendario, Long> {

    private final CalendarioRepository repository;

    public CalendarioService(CalendarioRepository repository) {
        this.repository = repository;
    }

    @Override
    public Calendario crear(Calendario calendario) {
        return repository.save(calendario);
    }

    @Override
    public Calendario modificar(Calendario calendario, Long id) {
        Calendario cal = repository.findById(id).orElse(null);
        if (cal != null) {
            cal.setFecha(calendario.getFecha());
            cal.setDetalles(calendario.getDetalles());
            cal.setRecomendaciones(calendario.getRecomendaciones());
            return repository.save(cal);
        }
        return null;
    }

    @Override
    public List<Calendario> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<Calendario> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(c -> c.getId().toString().equals(valor))
                    .toList();
            case "fecha" -> repository.findAll()
                    .stream()
                    .filter(c -> c.getFecha().toString().equals(valor))
                    .toList();
            case "detalles" -> repository.findAll()
                    .stream()
                    .filter(c -> c.getDetalles() != null && c.getDetalles().equalsIgnoreCase(valor))
                    .toList();
            case "recomendaciones" -> repository.findAll()
                    .stream()
                    .filter(c -> c.getRecomendaciones() != null && c.getRecomendaciones().equalsIgnoreCase(valor))
                    .toList();
            default -> List.of();
        };
    }
}
