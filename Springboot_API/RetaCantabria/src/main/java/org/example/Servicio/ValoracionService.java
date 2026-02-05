package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Ruta;
import org.example.Entidades.Valoracion;
import org.example.Logica.ValoracionRepository;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

@Service
@Transactional
public class ValoracionService implements IValoracionService<Valoracion, Long> {

    private final ValoracionRepository repository;
    private final RutaService rutaservice;

    public ValoracionService(ValoracionRepository repository, RutaService rutaservice) {
        this.repository = repository;
        this.rutaservice = rutaservice;
    }

    @Override
    public Valoracion crear(Valoracion v) {
        return repository.save(v);
    }

    @Override
    public Valoracion modificar(Valoracion v, Long id) {
        Valoracion val = repository.findById(id).orElse(null);
        if (val != null) {
            val.setDificultad(v.getDificultad());
            val.setBelleza(v.getBelleza());
            val.setInteresCultural(v.getInteresCultural());
            val.setFecha(v.getFecha());
            return repository.save(val);
        }
        return null;
    }

    @Override
    public List<Valoracion> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<Valoracion> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(v -> v.getId().toString().equals(valor))
                    .toList();
            case "dificultad" -> repository.findAll()
                    .stream()
                    .filter(v -> Integer.toString(v.getDificultad()).equals(valor))
                    .toList();
            case "belleza" -> repository.findAll()
                    .stream()
                    .filter(v -> Integer.toString(v.getBelleza()).equals(valor))
                    .toList();
            case "interescultural" -> repository.findAll()
                    .stream()
                    .filter(v -> Integer.toString(v.getInteresCultural()).equals(valor))
                    .toList();
            case "fecha" -> repository.findAll()
                    .stream()
                    .filter(v -> v.getFecha() != null && v.getFecha().toString().equals(valor))
                    .toList();
            default -> List.of();
        };
    }
    public List<Valoracion>obtenerValoracionesPorRuta(Long idRuta) {
        Ruta ruta = rutaservice.buscarPorId(idRuta).orElse(null);
        if (ruta == null) {
            throw new ResponseStatusException(
                    HttpStatus.NOT_FOUND, "Ruta no encontrada"
            );
        }
        return repository.findByRuta_idRuta(idRuta);
    }
}
