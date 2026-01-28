package org.example.Entidades;

import jakarta.persistence.*;

import java.time.LocalDate;

@Entity
@Table(name = "valora")
public class Valora {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idValora", nullable = false)
    private Integer id;

    @Column(name = "dificultad", nullable = false)
    private Byte dificultad;

    @Column(name = "fecha", nullable = false)
    private LocalDate fecha;

    @Column(name = "estrellas", nullable = false)
    private Byte estrellas;

    @Column(name = "interesCultural", nullable = false)
    private Byte interesCultural;

    @Column(name = "belleza", nullable = false)
    private Byte belleza;

    @Lob
    @Column(name = "valoracionTecnica")
    private String valoracionTecnica;

    @Lob
    @Column(name = "`reseña`")
    private String reseña;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "usuario_idUsuario", nullable = false)
    private Usuario usuarioIdusuario;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "rutas_idRuta", nullable = false)
    private Ruta rutasIdruta;

}