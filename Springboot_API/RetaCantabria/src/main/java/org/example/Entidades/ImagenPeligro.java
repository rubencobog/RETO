package org.example.Entidades;

import jakarta.persistence.*;

@Entity
@Table(name = "imagenespeligro")
public class ImagenPeligro {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idimagenespeligro", nullable = false)
    private Integer id;

    @Lob
    @Column(name = "url", nullable = false)
    private String url;

    @Lob
    @Column(name = "descripcion")
    private String descripcion;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "puntospeligro_idPuntospeligro", nullable = false)
    private PuntoPeligro puntoPeligro;

    public ImagenPeligro() {
    }

    public ImagenPeligro(Integer id, String url, String descripcion, PuntoPeligro puntoPeligro) {
        this.id = id;
        this.url = url;
        this.descripcion = descripcion;
        this.puntoPeligro = puntoPeligro;
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

    public PuntoPeligro getPuntoPeligro() {
        return puntoPeligro;
    }

    public void setPuntoPeligro(PuntoPeligro puntoPeligro) {
        this.puntoPeligro = puntoPeligro;
    }
}