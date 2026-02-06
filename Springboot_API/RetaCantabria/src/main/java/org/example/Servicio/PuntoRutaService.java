package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.PuntoRuta;
import org.example.Logica.PuntoRutaRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class PuntoRutaService implements IPuntoRutaService<PuntoRuta, Long> {

    private final PuntoRutaRepository repository;

    public PuntoRutaService(PuntoRutaRepository repository) {
        this.repository = repository;
    }

    @Override
    public PuntoRuta crear(PuntoRuta punto) {
        return repository.save(punto);
    }

    @Override
    public PuntoRuta modificar(PuntoRuta punto, Long id) {
        PuntoRuta pr = repository.findById(id).orElse(null);
        if (pr != null) {
            pr.setLongitud(punto.getLongitud());
            pr.setLatitud(punto.getLatitud());
            pr.setElevacion(punto.getElevacion());
            pr.setTimestamp(punto.getTimestamp());
            return repository.save(pr);
        }
        return null;
    }

    @Override
    public List<PuntoRuta> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<PuntoRuta> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "idpuntoruta" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getIdPuntoRuta().toString().equalsIgnoreCase(valor))
                    .toList();
            case "longitud" -> repository.findAll()
                    .stream()
                    .filter(p -> Double.toString(p.getLongitud()).equals(valor))
                    .toList();
            case "latitud" -> repository.findAll()
                    .stream()
                    .filter(p -> Double.toString(p.getLatitud()).equals(valor))
                    .toList();
            case "elevacion" -> repository.findAll()
                    .stream()
                    .filter(p -> Integer.toString(p.getElevacion()).equals(valor))
                    .toList();
            case "timestamp" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getTimestamp() != null && p.getTimestamp().toString().equals(valor))
                    .toList();
            default -> List.of();
        };
    }
    public List<PuntoRuta> puntosRuta(long idRuta){
        return repository.getpuntosRutas(idRuta);
    }
}