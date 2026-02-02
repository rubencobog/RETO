package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.TrackPoint;
import org.example.Logica.TrackPointRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class TrackPointService implements ITrackPointService<TrackPoint, Long> {

    private final TrackPointRepository repository;

    public TrackPointService(TrackPointRepository repository) {
        this.repository = repository;
    }

    @Override
    public TrackPoint crear(TrackPoint tp) {
        return repository.save(tp);
    }

    @Override
    public TrackPoint modificar(TrackPoint tp, Long id) {
        TrackPoint t = repository.findById(id).orElse(null);
        if (t != null) {
            t.setLongitud(tp.getLongitud());
            t.setLatitud(tp.getLatitud());
            t.setElevacion(tp.getElevacion());
            t.setTimestamp(tp.getTimestamp());
            t.setRuta(tp.getRuta());
            return repository.save(t);
        }
        return null;
    }

    @Override
    public List<TrackPoint> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<TrackPoint> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(t -> t.getIdPuntoRuta().toString().equals(valor))
                    .toList();
            case "longitud" -> repository.findAll()
                    .stream()
                    .filter(t -> Double.toString(t.getLongitud()).equals(valor))
                    .toList();
            case "latitud" -> repository.findAll()
                    .stream()
                    .filter(t -> Double.toString(t.getLatitud()).equals(valor))
                    .toList();
            case "elevacion" -> repository.findAll()
                    .stream()
                    .filter(t -> Integer.toString(t.getElevacion()).equals(valor))
                    .toList();
            case "timestamp" -> repository.findAll()
                    .stream()
                    .filter(t -> t.getTimestamp() != null && t.getTimestamp().toString().equals(valor))
                    .toList();
            case "ruta" -> repository.findAll()
                    .stream()
                    .filter(t -> t.getRuta() != null && t.getRuta().getIdRuta().toString().equals(valor))
                    .toList();
            default -> List.of();
        };
    }
    public List<TrackPoint> findAllByRuta(Long idRuta) {
        return repository.findbyRuta(idRuta);
    }
}
