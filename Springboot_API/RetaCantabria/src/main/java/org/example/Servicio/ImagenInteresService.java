package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.ImagenInteres;
import org.example.Logica.ImagenInteresRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class ImagenInteresService implements IImagenInteresService<ImagenInteres, Long> {

    private final ImagenInteresRepository repository;

    public ImagenInteresService(ImagenInteresRepository repository) {
        this.repository = repository;
    }

    @Override
    public ImagenInteres crear(ImagenInteres imagen) {
        return repository.save(imagen);
    }

    @Override
    public ImagenInteres modificar(ImagenInteres imagen, Long id) {
        ImagenInteres img = repository.findById(id).orElse(null);
        if (img != null) {
            img.setUrl(imagen.getUrl());
            img.setDescripcion(imagen.getDescripcion());
            return repository.save(img);
        }
        return null;
    }

    @Override
    public List<ImagenInteres> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<ImagenInteres> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(i -> i.getId().toString().equals(valor))
                    .toList();
            case "url" -> repository.findAll()
                    .stream()
                    .filter(i -> i.getUrl() != null && i.getUrl().equalsIgnoreCase(valor))
                    .toList();
            case "descripcion" -> repository.findAll()
                    .stream()
                    .filter(i -> i.getDescripcion() != null && i.getDescripcion().equalsIgnoreCase(valor))
                    .toList();
            default -> List.of();
        };
    }
}