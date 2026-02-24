package org.example.Entidades;

import jakarta.persistence.*;
import org.example.Interfaz.PuntosInteresPeligro;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "puntosinteres")
public class PuntoInteres implements PuntosInteresPeligro {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String nombre;

    @ColumnDefault("'naturaleza'")
    @Enumerated(EnumType.STRING)
    @Column(name = "tipo")
    private TIPOPI tipo;

    @Column(name = "caracteristicas_especiales",columnDefinition = "TEXT")
    private String caracteristicasEspeciales;

    @OneToMany(mappedBy = "puntoInteres", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ImagenInteres> imagenes=new ArrayList<>();

    @OneToOne
    @JoinColumn(name = "punto_ruta_id")
    private PuntoRuta puntoRuta;

    @Override
    public PuntoRuta getPunto() {
        return puntoRuta;
    }

    public PuntoInteres() {
    }

    public PuntoInteres(Long id, String nombre, TIPOPI tipo, String caracteristicasEspeciales, List<ImagenInteres> imagenes, PuntoRuta puntoRuta) {
        this.id = id;
        this.nombre = nombre;
        this.tipo = tipo;
        this.caracteristicasEspeciales = caracteristicasEspeciales;
        this.imagenes = imagenes;
        this.puntoRuta = puntoRuta;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public TIPOPI getTipo() {
        return tipo;
    }

    public void setTipo(TIPOPI tipo) {
        this.tipo = tipo;
    }

    public String getCaracteristicasEspeciales() {
        return caracteristicasEspeciales;
    }

    public void setCaracteristicasEspeciales(String caracteristicasEspeciales) {
        this.caracteristicasEspeciales = caracteristicasEspeciales;
    }

    public List<ImagenInteres> getImagenes() {
        return imagenes;
    }

    public void setImagenes(List<ImagenInteres> imagenes) {
        this.imagenes = imagenes;
    }

    public PuntoRuta getPuntoRuta() {
        return puntoRuta;
    }

    public void setPuntoRuta(PuntoRuta puntoRuta) {
        this.puntoRuta = puntoRuta;
    }
}