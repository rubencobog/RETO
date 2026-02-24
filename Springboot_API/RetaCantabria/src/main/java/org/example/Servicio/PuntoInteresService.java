package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.PuntoInteres;
import org.example.Logica.PuntoInteresRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class PuntoInteresService implements IPuntoInteresService<PuntoInteres, Long> {

    private final PuntoInteresRepository repository;

    public PuntoInteresService(PuntoInteresRepository repository) {
        this.repository = repository;
    }

    @Override
    public PuntoInteres crear(PuntoInteres punto) {
        return repository.save(punto);
    }

    @Override
    public PuntoInteres modificar(PuntoInteres punto, Long id) {
        PuntoInteres pi = repository.findById(id).orElse(null);
        if (pi != null) {
            pi.setNombre(punto.getNombre());
            pi.setTipo(punto.getTipo());
            pi.setCaracteristicasEspeciales(punto.getCaracteristicasEspeciales());
            return repository.save(pi);
        }
        return null;
    }

    @Override
    public List<PuntoInteres> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<PuntoInteres> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getId().toString().equals(valor))
                    .toList();
            case "nombre" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getNombre() != null && p.getNombre().equalsIgnoreCase(valor))
                    .toList();
            case "tipo" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getTipo() != null && p.getTipo().name().equalsIgnoreCase(valor))
                    .toList();
            case "caracteristicasespeciales" -> repository.findAll()
                    .stream()
                    .filter(p -> p.getCaracteristicasEspeciales() != null &&
                            p.getCaracteristicasEspeciales().equalsIgnoreCase(valor))
                    .toList();
            default -> List.of();
        };
    }
}
