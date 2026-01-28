package org.example.Entidades;

import jakarta.persistence.*;

@Entity
@Table(name = "imagenesinteres")
public class ImagenInteres {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idimagenesinteres", nullable = false)
    private Integer id;

    @Column(name = "url", nullable = false, columnDefinition = "TEXT")
    private String url;


    @Column(name = "descripcion", columnDefinition = "TEXT")
    private String descripcion;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "puntosinteres_idPuntosinteres", nullable = false)
    private PuntoInteres puntoInteres;

    public ImagenInteres() {
    }

    public ImagenInteres(Integer id, String url, String descripcion, PuntoInteres puntoInteres) {
        this.id = id;
        this.url = url;
        this.descripcion = descripcion;
        this.puntoInteres = puntoInteres;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public PuntoInteres getPuntoInteres() {
        return puntoInteres;
    }

    public void setPuntoInteres(PuntoInteres puntoInteres) {
        this.puntoInteres = puntoInteres;
    }
}