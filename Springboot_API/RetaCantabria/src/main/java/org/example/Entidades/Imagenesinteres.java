package org.example.Entidades;

import jakarta.persistence.*;

@Entity
@Table(name = "imagenesinteres")
public class Imagenesinteres {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idimagenesinteres", nullable = false)
    private Integer id;

    @Lob
    @Column(name = "url", nullable = false)
    private String url;

    @Lob
    @Column(name = "descripcion")
    private String descripcion;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "puntosinteres_idPuntosinteres", nullable = false)
    private Puntosinteres puntosinteresIdpuntosinteres;

}