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
    private PuntoPeligro puntospeligroIdpuntospeligro;

}