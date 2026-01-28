package org.example.Entidades;

import jakarta.persistence.*;
import org.example.Interfaz.PuntosInteresPeligro;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "puntospeligro")
public class PuntoPeligro implements PuntosInteresPeligro {
    @Id
    @GeneratedValue(strategy =GenerationType.IDENTITY)
    private Long id;

    @Column(name = "kilometro")
    private Double kilometro;

    @Column(name = "gravedad")
    private Byte gravedad;

    @Column(name="justificacion",columnDefinition = "TEXT")
    private String justificacion;


    @OneToMany(mappedBy = "puntoPeligro", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ImagenPeligro> imagenes=new ArrayList<>();

    @OneToOne
    @JoinColumn(name = "punto_ruta_id")
    private PuntoRuta puntoRuta;

    @Override
    public PuntoRuta getPunto() {
        return puntoRuta;
    }

    public PuntoPeligro(Long id, Double kilometro, Byte gravedad, String justificacion, List<ImagenPeligro> imagenes, PuntoRuta puntoRuta) {
        this.id = id;
        this.kilometro = kilometro;
        this.gravedad = gravedad;
        this.justificacion = justificacion;
        this.imagenes = imagenes;
        this.puntoRuta = puntoRuta;
    }

    public PuntoPeligro() {

    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Double getKilometro() {
        return kilometro;
    }

    public void setKilometro(Double kilometro) {
        this.kilometro = kilometro;
    }

    public Byte getGravedad() {
        return gravedad;
    }

    public void setGravedad(Byte gravedad) {
        this.gravedad = gravedad;
    }

    public String getJustificacion() {
        return justificacion;
    }

    public void setJustificacion(String justificacion) {
        this.justificacion = justificacion;
    }

    public List<ImagenPeligro> getImagenes() {
        return imagenes;
    }

    public void setImagenes(List<ImagenPeligro> imagenes) {
        this.imagenes = imagenes;
    }

    public PuntoRuta getPuntoRuta() {
        return puntoRuta;
    }

    public void setPuntoRuta(PuntoRuta puntoRuta) {
        this.puntoRuta = puntoRuta;
    }
}