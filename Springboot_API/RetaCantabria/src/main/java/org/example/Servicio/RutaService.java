package org.example.Servicio;

import jakarta.transaction.Transactional;
import org.example.Entidades.Ruta;
import org.example.Logica.RutaRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Transactional
public class RutaService implements IRutaService<Ruta, Long> {

    private final RutaRepository repository;

    public RutaService(RutaRepository repository) {
        this.repository = repository;
    }

    @Override
    public Ruta crear(Ruta ruta) {
        return repository.save(ruta);
    }

    @Override
    public Ruta modificar(Ruta ruta, Long id) {
        Ruta r = repository.findById(id).orElse(null);
        if (r != null) {
            r.setNombre(ruta.getNombre());
            r.setNombreInicioruta(ruta.getNombreInicioruta());
            r.setNombreFinalruta(ruta.getNombreFinalruta());
            r.setLatitudInicial(ruta.getLatitudInicial());
            r.setLatitudFinal(ruta.getLatitudFinal());
            r.setLongitudInicial(ruta.getLongitudInicial());
            r.setLongitudFinal(ruta.getLongitudFinal());
            r.setDistancia(ruta.getDistancia());
            r.setDuracion(ruta.getDuracion());
            r.setDesnivelPositivo(ruta.getDesnivelPositivo());
            r.setDesnivelNegativo(ruta.getDesnivelNegativo());
            r.setDesnivelAcumulado(ruta.getDesnivelAcumulado());
            r.setAltitudMax(ruta.getAltitudMax());
            r.setAltitudMin(ruta.getAltitudMin());
            r.setClasificacion(ruta.getClasificacion());
            r.setNivelEsfuerzo(ruta.getNivelEsfuerzo());
            r.setNivelRiesgo(ruta.getNivelRiesgo());
            r.setEstadoRuta(ruta.isEstadoRuta());
            r.setTipoTerreno(ruta.getTipoTerreno());
            r.setIndicaciones(ruta.getIndicaciones());
            r.setTemporadas(ruta.getTemporadas());
            r.setAccesibilidad(ruta.isAccesibilidad());
            r.setRutaFamiliar(ruta.isRutaFamiliar());
            r.setArchivoGPX(ruta.getArchivoGPX());
            r.setRecomendacionesEquipo(ruta.getRecomendacionesEquipo());
            r.setZonaGeografica(ruta.getZonaGeografica());
            r.setMediaEstrellas(ruta.getMediaEstrellas());
            return repository.save(r);
        }
        return null;
    }

    @Override
    public List<Ruta> listar() {
        return repository.findAll();
    }

    @Override
    public void eliminar(Long id) {
        repository.deleteById(id);
    }

    @Override
    public List<Ruta> buscar(String campo, String valor) {
        return switch (campo.toLowerCase()) {
            case "id" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getIdRuta().toString().equals(valor))
                    .toList();
            case "nombre" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getNombre() != null && r.getNombre().equalsIgnoreCase(valor))
                    .toList();
            case "nombre_inicioruta" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getNombreInicioruta() != null &&
                            r.getNombreInicioruta().equalsIgnoreCase(valor))
                    .toList();
            case "nombre_finalruta" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getNombreFinalruta() != null &&
                            r.getNombreFinalruta().equalsIgnoreCase(valor))
                    .toList();
            case "latitudinicial" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getLatitudInicial() != null &&
                            r.getLatitudInicial().toString().equals(valor))
                    .toList();
            case "latitudfinal" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getLatitudFinal() != null &&
                            r.getLatitudFinal().toString().equals(valor))
                    .toList();
            case "longitudinicial" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getLongitudInicial() != null &&
                            r.getLongitudInicial().toString().equals(valor))
                    .toList();
            case "longitudfinal" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getLongitudFinal() != null &&
                            r.getLongitudFinal().toString().equals(valor))
                    .toList();
            case "distancia" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getDistancia() != null &&
                            r.getDistancia().toString().equals(valor))
                    .toList();
            case "duracion" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getDuracion() != null &&
                            r.getDuracion().toString().equals(valor))
                    .toList();
            case "desnivelpositivo" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getDesnivelPositivo() != null &&
                            r.getDesnivelPositivo().toString().equals(valor))
                    .toList();
            case "desnivelnegativo" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getDesnivelNegativo() != null &&
                            r.getDesnivelNegativo().toString().equals(valor))
                    .toList();
            case "desnivelacumulado" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getDesnivelAcumulado() != null &&
                            r.getDesnivelAcumulado().toString().equals(valor))
                    .toList();
            case "altitudmax" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getAltitudMax() != null &&
                            r.getAltitudMax().toString().equals(valor))
                    .toList();
            case "altitudmin" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getAltitudMin() != null &&
                            r.getAltitudMin().toString().equals(valor))
                    .toList();
            case "clasificacion" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getClasificacion() != null &&
                            r.getClasificacion().name().equalsIgnoreCase(valor))
                    .toList();
            case "nivelesfuerzo" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getNivelEsfuerzo() != null &&
                            r.getNivelEsfuerzo().toString().equals(valor))
                    .toList();
            case "nivelriesgo" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getNivelRiesgo() != null &&
                            r.getNivelRiesgo().toString().equals(valor))
                    .toList();
            case "estadRuta" -> repository.findAll()
                    .stream()
                    .filter(r -> Boolean.toString(r.isEstadoRuta()).equalsIgnoreCase(valor))
                    .toList();
            case "tipoterreno" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getTipoTerreno() != null &&
                            r.getTipoTerreno().toString().equals(valor))
                    .toList();
            case "indicaciones" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getIndicaciones() != null &&
                            r.getIndicaciones().toString().equals(valor))
                    .toList();
            case "temporadas" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getTemporadas() != null &&
                            r.getTemporadas().equalsIgnoreCase(valor))
                    .toList();
            case "accesibilidad" -> repository.findAll()
                    .stream()
                    .filter(r -> Boolean.toString(r.isAccesibilidad()).equalsIgnoreCase(valor))
                    .toList();
            case "rutafamiliar" -> repository.findAll()
                    .stream()
                    .filter(r -> Boolean.toString(r.isRutaFamiliar()).equalsIgnoreCase(valor))
                    .toList();
            case "archivogpx" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getArchivoGPX() != null &&
                            r.getArchivoGPX().equalsIgnoreCase(valor))
                    .toList();
            case "recomendacionesequipo" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getRecomendacionesEquipo() != null &&
                            r.getRecomendacionesEquipo().equalsIgnoreCase(valor))
                    .toList();
            case "zonageografica" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getZonaGeografica() != null &&
                            r.getZonaGeografica().equalsIgnoreCase(valor))
                    .toList();
            case "mediaestrellas" -> repository.findAll()
                    .stream()
                    .filter(r -> r.getMediaEstrellas() != null &&
                            r.getMediaEstrellas().toString().equals(valor))
                    .toList();
            default -> List.of();
        };
    }
}
