package org.example.Conexion;

import org.example.Entidades.ImagenInteres;
import org.example.Servicio.ImagenInteresService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/imageninteres")
public class ImagenInteresController {

    private final ImagenInteresService imagenInteresService;

    @Autowired
    public ImagenInteresController(ImagenInteresService imagenInteresService) {
        this.imagenInteresService = imagenInteresService;
    }

    @GetMapping("/test")
    public String test() {
        return "API ImagenInteres funcionando";
    }

    @GetMapping
    public List<ImagenInteres> findAll() {
        return imagenInteresService.listar();
    }

    @GetMapping("/buscar")
    public List<ImagenInteres> buscar(@RequestParam String campo, @RequestParam String valor) {
        return imagenInteresService.buscar(campo, valor);
    }

    @PostMapping
    public ImagenInteres create(@RequestBody ImagenInteres imagenInteres) {
        return imagenInteresService.crear(imagenInteres);
    }

    @PutMapping("/{id}")
    public ImagenInteres update(@RequestBody ImagenInteres imagenInteres, @PathVariable Long id) {
        return imagenInteresService.modificar(imagenInteres, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        imagenInteresService.eliminar(id);
    }
}
