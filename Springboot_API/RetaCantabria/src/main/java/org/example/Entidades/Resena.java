package org.example.Entidades;

import jakarta.persistence.*;

import java.time.LocalDate;

@Entity
@Table(name="resenas")
public class Resena {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int idResena;
    @Column(name = "resena",columnDefinition = "TEXT")
    private String resena;
    private LocalDate fecha;
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idUsuario", nullable = false)
    private Usuario usuario;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idRuta", nullable = false)
    private Ruta ruta;

}
