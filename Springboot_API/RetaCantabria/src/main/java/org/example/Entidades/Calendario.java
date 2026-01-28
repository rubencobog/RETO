package org.example.Entidades;

import jakarta.persistence.*;

import java.time.Instant;

@Entity
@Table(name = "calendario")
public class Calendario {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idCalendario", nullable = false)
    private Integer id;

    @Column(name = "fecha", nullable = false)
    private Instant fecha;

    @Lob
    @Column(name = "detalles")
    private String detalles;

    @Lob
    @Column(name = "recomendaciones")
    private String recomendaciones;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "rutas_idRuta", nullable = false)
    private Ruta rutasIdruta;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "usuario_idUsuario", nullable = false)
    private Usuario usuarioIdusuario;

}