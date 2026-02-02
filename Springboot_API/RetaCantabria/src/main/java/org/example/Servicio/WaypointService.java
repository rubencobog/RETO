package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Waypoint;
import org.example.Logica.WaypointRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class WaypointService implements IWaypointService<Waypoint, Long> {

    private final WaypointRepository repository;

    public WaypointService(WaypointRepository repository) {
        this.repository = repository;
    }

    @Override
    public Waypoint crear(Waypoint wp) {
        return repository.save(wp);
    }

    @Override
    public Waypoint modificar(Waypoint wp, Long id) {
        Waypoint w = repository.findById(id).orElse(null);
        if (w != null) {
            w.setLongitud(wp.getLongitud());
            w.setLatitud(wp.getLatitud());
            w.setElevacion(wp.getElevacion());
            w.setTimestamp(wp.getTimestamp());
            w.setRuta(wp.getRuta());
            w.setNombre(wp.getNombre());
            w.setDescripcion(wp.getDescripcion());
            return repository.save(w);
        }
        return null;
    }

    @Override
    public List<Waypoint> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<Waypoint> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(w -> w.getIdPuntoRuta().toString().equals(valor))
                    .toList();
            case "longitud" -> repository.findAll()
                    .stream()
                    .filter(w -> Double.toString(w.getLongitud()).equals(valor))
                    .toList();
            case "latitud" -> repository.findAll()
                    .stream()
                    .filter(w -> Double.toString(w.getLatitud()).equals(valor))
                    .toList();
            case "elevacion" -> repository.findAll()
                    .stream()
                    .filter(w -> Integer.toString(w.getElevacion()).equals(valor))
                    .toList();
            case "timestamp" -> repository.findAll()
                    .stream()
                    .filter(w -> w.getTimestamp() != null && w.getTimestamp().toString().equals(valor))
                    .toList();
            case "ruta" -> repository.findAll()
                    .stream()
                    .filter(w -> w.getRuta() != null && w.getRuta().getIdRuta().toString().equals(valor))
                    .toList();
            case "nombre" -> repository.findAll()
                    .stream()
                    .filter(w -> w.getNombre() != null && w.getNombre().equalsIgnoreCase(valor))
                    .toList();
            case "descripcion" -> repository.findAll()
                    .stream()
                    .filter(w -> w.getDescripcion() != null && w.getDescripcion().equalsIgnoreCase(valor))
                    .toList();
            default -> List.of();
        };
    }
    public List<Waypoint> findAllByRuta(Long idRuta) {
        return repository.findByRuta(idRuta);
    }
}
