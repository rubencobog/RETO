package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.PuntoPeligro;
import org.example.Logica.PuntoPeligroRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class PuntoPeligroService implements IPuntoPeligroService<PuntoPeligro, Long> {

    private final PuntoPeligroRepository repository;

    public PuntoPeligroService(PuntoPeligroRepository repository) {
        this.repository = repository;
    }

    @Override
    public PuntoPeligro crear(PuntoPeligro punto) {
        return repository.save(punto);
    }

    @Override
    public PuntoPeligro modificar(PuntoPeligro punto, Long id) {
        PuntoPeligro pp = repository.findById(id).orElse(null);
        if (pp != null) {
            pp.setKilometro(punto.getKilometro());
            pp.setGravedad(punto.getGravedad());
            pp.setJustificacion(punto.getJustificacion());
            return repository.save(pp);
        }
        return null;
    }

    @Override
    public List<PuntoPeligro> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<PuntoPeligro> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getId().toString().equals(valor))
                    .toList();
            case "kilometro" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getKilometro() != null && p.getKilometro().toString().equals(valor))
                    .toList();
            case "gravedad" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getGravedad() != null && p.getGravedad().toString().equals(valor))
                    .toList();
            case "justificacion" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getJustificacion() != null && p.getJustificacion().equalsIgnoreCase(valor))
                    .toList();
            default -> List.of();
        };
    }
//    public List<PuntoPeligro> puntospeligroRuta(long id) {
//        return repository.getPuntoPeligro(id);
//    }
}
