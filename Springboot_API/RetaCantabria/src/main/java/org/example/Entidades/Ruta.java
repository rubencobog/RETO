package org.example.Entidades;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.time.LocalTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "rutas")
public class Ruta {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idRuta", nullable = false)
    private Integer idRuta;

    @Column(name = "nombre", nullable = false, length = 20)
    private String nombre;

    @Column(name = "nombre_inicioruta",columnDefinition = "VARCHAR(45) DEFAULT 'Inicio'",  length = 45)
    private String nombreInicioruta;

    @Column(name = "nombre_finalruta",columnDefinition = "VARCHAR(45) DEFAULT 'Fin'",  length = 45)
    private String nombreFinalruta;

    @Column(name = "latitudInicial")
    private Double latitudInicial;

    @Column(name = "latitudFinal")
    private Double latitudFinal;

    @Column(name = "longitudInicial")
    private Double longitudInicial;

    @Column(name = "longitudFinal")
    private Double longitudFinal;

    @Column(name = "distancia")
    private Double distancia;

    @Column(name = "duracion")
    private LocalTime duracion;

    @Column(name = "desnivelPositivo")
    private Integer desnivelPositivo;

    @Column(name = "desnivelNegativo")
    private Integer desnivelNegativo;

    @Column(name="desnivelAcumulado")
    private Integer desnivelAcumulado;

    @Column(name = "altitudMax")
    private Double altitudMax;

    @Column(name = "altitudMin")
    private Double altitudMin;

    @ColumnDefault("'LINEAL'")
    @Enumerated(EnumType.STRING)
    @Column(name = "clasificacion")
    private CLASIFICACION clasificacion;

    @Column(name = "nivelEsfuerzo")
    private Byte nivelEsfuerzo;

    @Column(name = "nivelRiesgo")
    private Byte nivelRiesgo;

    @ColumnDefault("0")
    @Column(name = "estadoRuta")
    private boolean estadoRuta;

    @Column(name = "tipoTerreno")
    private Byte tipoTerreno;

    @Column(name = "indicaciones")
    private Byte indicaciones;

    @Lob
    @Column(name = "temporadas")
    private String temporadas;

    @Column(name = "accesibilidad")
    private boolean accesibilidad;

    @Column(name = "rutaFamiliar")
    private boolean rutaFamiliar;

    @Lob
    @Column(name = "archivoGPX")
    private String archivoGPX;

    @Lob
    @Column(name = "recomendacionesEquipo")
    private String recomendacionesEquipo;

    @Column(name = "zonaGeografica", length = 45)
    private String zonaGeografica;

    @Column(name = "mediaEstrellas")
    private Double mediaEstrellas;

    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "usuario_idUsuario", nullable = false)
    private Usuario usuarioIdusuario;
    @OneToMany(mappedBy = "ruta", cascade = CascadeType.ALL, orphanRemoval = true)
    @JsonManagedReference
    private List<PuntoRuta> puntos = new ArrayList<>();

    @OneToMany(mappedBy = "ruta",cascade = CascadeType.ALL,orphanRemoval = true)
    private List<Valoracion>valoraciones=new ArrayList<>();

    @OneToMany(mappedBy = "ruta",cascade = CascadeType.ALL,orphanRemoval = true)
    private List<Resena>resenas=new ArrayList<>();

    public Ruta() {
    }

    public Ruta(Integer idRuta, String nombre, String nombreInicioruta, String nombreFinalruta, Double latitudInicial, Double latitudFinal, Double longitudInicial, Double longitudFinal, Double distancia, LocalTime duracion, Integer desnivelPositivo, Integer desnivelNegativo, Integer desnivelAcumulado, Double altitudMax, Double altitudMin, CLASIFICACION clasificacion, Byte nivelEsfuerzo, Byte nivelRiesgo, boolean estadoRuta, Byte tipoTerreno, Byte indicaciones, String temporadas, boolean accesibilidad, boolean rutaFamiliar, String archivoGPX, String recomendacionesEquipo, String zonaGeografica, Double mediaEstrellas, Usuario usuarioIdusuario, List<PuntoRuta> puntos, List<Valoracion> valoraciones, List<Resena> resenas) {
        this.idRuta = idRuta;
        this.nombre = nombre;
        this.nombreInicioruta = nombreInicioruta;
        this.nombreFinalruta = nombreFinalruta;
        this.latitudInicial = latitudInicial;
        this.latitudFinal = latitudFinal;
        this.longitudInicial = longitudInicial;
        this.longitudFinal = longitudFinal;
        this.distancia = distancia;
        this.duracion = duracion;
        this.desnivelPositivo = desnivelPositivo;
        this.desnivelNegativo = desnivelNegativo;
        this.desnivelAcumulado = desnivelAcumulado;
        this.altitudMax = altitudMax;
        this.altitudMin = altitudMin;
        this.clasificacion = clasificacion;
        this.nivelEsfuerzo = nivelEsfuerzo;
        this.nivelRiesgo = nivelRiesgo;
        this.estadoRuta = estadoRuta;
        this.tipoTerreno = tipoTerreno;
        this.indicaciones = indicaciones;
        this.temporadas = temporadas;
        this.accesibilidad = accesibilidad;
        this.rutaFamiliar = rutaFamiliar;
        this.archivoGPX = archivoGPX;
        this.recomendacionesEquipo = recomendacionesEquipo;
        this.zonaGeografica = zonaGeografica;
        this.mediaEstrellas = mediaEstrellas;
        this.usuarioIdusuario = usuarioIdusuario;
        this.puntos = puntos;
        this.valoraciones = valoraciones;
        this.resenas = resenas;
    }

    public Integer getId() {
        return idRuta;
    }

    public void setId(Integer id) {
        this.idRuta = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getNombreInicioruta() {
        return nombreInicioruta;
    }

    public void setNombreInicioruta(String nombreInicioruta) {
        this.nombreInicioruta = nombreInicioruta;
    }

    public String getNombreFinalruta() {
        return nombreFinalruta;
    }

    public void setNombreFinalruta(String nombreFinalruta) {
        this.nombreFinalruta = nombreFinalruta;
    }

    public Double getLatitudInicial() {
        return latitudInicial;
    }

    public void setLatitudInicial(Double latitudInicial) {
        this.latitudInicial = latitudInicial;
    }

    public Double getLatitudFinal() {
        return latitudFinal;
    }

    public void setLatitudFinal(Double latitudFinal) {
        this.latitudFinal = latitudFinal;
    }

    public Double getLongitudInicial() {
        return longitudInicial;
    }

    public void setLongitudInicial(Double longitudInicial) {
        this.longitudInicial = longitudInicial;
    }

    public Double getLongitudFinal() {
        return longitudFinal;
    }

    public void setLongitudFinal(Double longitudFinal) {
        this.longitudFinal = longitudFinal;
    }

    public Double getDistancia() {
        return distancia;
    }

    public void setDistancia(Double distancia) {
        this.distancia = distancia;
    }

    public LocalTime getDuracion() {
        return duracion;
    }

    public void setDuracion(LocalTime duracion) {
        this.duracion = duracion;
    }

    public Integer getDesnivelPositivo() {
        return desnivelPositivo;
    }

    public void setDesnivelPositivo(Integer desnivelPositivo) {
        this.desnivelPositivo = desnivelPositivo;
    }

    public Integer getDesnivelNegativo() {
        return desnivelNegativo;
    }

    public void setDesnivelNegativo(Integer desnivelNegativo) {
        this.desnivelNegativo = desnivelNegativo;
    }

    public Integer getDesnivelAcumulado() {
        return desnivelAcumulado;
    }

    public void setDesnivelAcumulado(Integer desnivelAcumulado) {
        this.desnivelAcumulado = desnivelAcumulado;
    }

    public Double getAltitudMax() {
        return altitudMax;
    }

    public void setAltitudMax(Double altitudMax) {
        this.altitudMax = altitudMax;
    }

    public Double getAltitudMin() {
        return altitudMin;
    }

    public void setAltitudMin(Double altitudMin) {
        this.altitudMin = altitudMin;
    }

    public CLASIFICACION getClasificacion() {
        return clasificacion;
    }

    public void setClasificacion(CLASIFICACION clasificacion) {
        this.clasificacion = clasificacion;
    }

    public Byte getNivelEsfuerzo() {
        return nivelEsfuerzo;
    }

    public void setNivelEsfuerzo(Byte nivelEsfuerzo) {
        this.nivelEsfuerzo = nivelEsfuerzo;
    }

    public Byte getNivelRiesgo() {
        return nivelRiesgo;
    }

    public void setNivelRiesgo(Byte nivelRiesgo) {
        this.nivelRiesgo = nivelRiesgo;
    }

    public boolean isEstadoRuta() {
        return estadoRuta;
    }

    public void setEstadoRuta(boolean estadoRuta) {
        this.estadoRuta = estadoRuta;
    }

    public Byte getTipoTerreno() {
        return tipoTerreno;
    }

    public void setTipoTerreno(Byte tipoTerreno) {
        this.tipoTerreno = tipoTerreno;
    }

    public Byte getIndicaciones() {
        return indicaciones;
    }

    public void setIndicaciones(Byte indicaciones) {
        this.indicaciones = indicaciones;
    }

    public String getTemporadas() {
        return temporadas;
    }

    public void setTemporadas(String temporadas) {
        this.temporadas = temporadas;
    }

    public boolean isAccesibilidad() {
        return accesibilidad;
    }

    public void setAccesibilidad(boolean accesibilidad) {
        this.accesibilidad = accesibilidad;
    }

    public boolean isRutaFamiliar() {
        return rutaFamiliar;
    }

    public void setRutaFamiliar(boolean rutaFamiliar) {
        this.rutaFamiliar = rutaFamiliar;
    }

    public String getArchivoGPX() {
        return archivoGPX;
    }

    public void setArchivoGPX(String archivoGPX) {
        this.archivoGPX = archivoGPX;
    }

    public String getRecomendacionesEquipo() {
        return recomendacionesEquipo;
    }

    public void setRecomendacionesEquipo(String recomendacionesEquipo) {
        this.recomendacionesEquipo = recomendacionesEquipo;
    }

    public String getZonaGeografica() {
        return zonaGeografica;
    }

    public void setZonaGeografica(String zonaGeografica) {
        this.zonaGeografica = zonaGeografica;
    }

    public Double getMediaEstrellas() {
        return mediaEstrellas;
    }

    public void setMediaEstrellas(Double mediaEstrellas) {
        this.mediaEstrellas = mediaEstrellas;
    }

    public Usuario getUsuarioIdusuario() {
        return usuarioIdusuario;
    }

    public void setUsuarioIdusuario(Usuario usuarioIdusuario) {
        this.usuarioIdusuario = usuarioIdusuario;
    }

    public List<PuntoRuta> getPuntos() {
        return puntos;
    }

    public void setPuntos(List<PuntoRuta> puntos) {
        this.puntos = puntos;
    }

    public Integer getIdRuta() {
        return idRuta;
    }

    public void setIdRuta(Integer idRuta) {
        this.idRuta = idRuta;
    }

    public List<Valoracion> getValoraciones() {
        return valoraciones;
    }

    public void setValoraciones(List<Valoracion> valoraciones) {
        this.valoraciones = valoraciones;
    }

    public List<Resena> getResenas() {
        return resenas;
    }

    public void setResenas(List<Resena> resenas) {
        this.resenas = resenas;
    }
}