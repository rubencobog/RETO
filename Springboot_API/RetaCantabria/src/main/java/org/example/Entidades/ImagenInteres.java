package org.example.Entidades;

import jakarta.persistence.*;

@Entity
@Table(name = "imagenesinteres")
public class ImagenInteres {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idimagenesinteres", nullable = false)
    private Integer id;

    @Column(name = "url", nullable = false,columnDefinition = "TEXT")
    private String url;


    @Column(name = "descripcion",columnDefinition = "TEXT")
    private String descripcion;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "puntosinteres_idPuntosinteres", nullable = false)
    private PuntoInteres puntoInteres;

}