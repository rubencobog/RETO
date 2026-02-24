package org.example.Conexion;

import org.example.Entidades.ImagenPeligro;
import org.example.Servicio.ImagenPeligroService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/imagenpeligro")
public class ImagenPeligroController {

    private final ImagenPeligroService imagenPeligroService;

    @Autowired
    public ImagenPeligroController(ImagenPeligroService imagenPeligroService) {
        this.imagenPeligroService = imagenPeligroService;
    }

    @GetMapping("/test")
    public String test() {
        return "API ImagenPeligro funcionando";
    }

    @GetMapping
    public List<ImagenPeligro> findAll() {
        return imagenPeligroService.listar();
    }

    @GetMapping("/buscar")
    public List<ImagenPeligro> buscar(@RequestParam String campo, @RequestParam String valor) {
        return imagenPeligroService.buscar(campo, valor);
    }

    @PostMapping
    public ImagenPeligro create(@RequestBody ImagenPeligro imagenPeligro) {
        return imagenPeligroService.crear(imagenPeligro);
    }

    @PutMapping("/{id}")
    public ImagenPeligro update(@RequestBody ImagenPeligro imagenPeligro, @PathVariable Long id) {
        return imagenPeligroService.modificar(imagenPeligro, id);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        imagenPeligroService.eliminar(id);
    }
}