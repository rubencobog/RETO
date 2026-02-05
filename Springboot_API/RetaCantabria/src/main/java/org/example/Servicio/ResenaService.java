package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Resena;
import org.example.Entidades.Ruta;
import org.example.Logica.ResenaRepository;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

@Service
@Transactional
public class ResenaService implements IResenaService<Resena, Long> {

    private final ResenaRepository repository;
    private final RutaService rutaService;

    public ResenaService(ResenaRepository repository, RutaService rutaService) {
        this.repository = repository;
        this.rutaService=rutaService;
    }

    @Override
    public Resena crear(Resena resena) {
        if(resena==null){
            System.out.println("fallo en la reseña");
        }
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
    public List<Resena> obtenerResenasPorRuta(Long idRuta) {
        Ruta ruta=rutaService.buscarPorId(idRuta).orElse(null);
                if(ruta==null){
            throw new ResponseStatusException(
                    HttpStatus.NOT_FOUND, "Ruta no encontrada"
            );
        }
        return repository.findByRuta_IdRuta(idRuta);
    }
}
