package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.ImagenPeligro;
import org.example.Logica.ImagenPeligroRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class ImagenPeligroService implements IImagenPeligroService<ImagenPeligro, Long> {

    private final ImagenPeligroRepository repository;

    public ImagenPeligroService(ImagenPeligroRepository repository) {
        this.repository = repository;
    }

    @Override
    public ImagenPeligro crear(ImagenPeligro imagen) {
        return repository.save(imagen);
    }

    @Override
    public ImagenPeligro modificar(ImagenPeligro imagen, Long id) {
        ImagenPeligro img = repository.findById(id).orElse(null);
        if (img != null) {
            img.setUrl(imagen.getUrl());
            img.setDescripcion(imagen.getDescripcion());
            return repository.save(img);
        }
        return null;
    }

    @Override
    public List<ImagenPeligro> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<ImagenPeligro> buscar(String campo, String valor) {
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
