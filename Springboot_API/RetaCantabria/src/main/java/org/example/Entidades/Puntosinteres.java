package org.example.Entidades;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

@Entity
@Table(name = "puntosinteres")
public class Puntosinteres {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idPuntosinteres", nullable = false)
    private Integer id;

    @Column(name = "nombre", nullable = false, length = 40)
    private String nombre;

    @Column(name = "latitud", nullable = false)
    private Double latitud;

    @Column(name = "longitud", nullable = false)
    private Double longitud;

    @Column(name = "elevacion", nullable = false)
    private Double elevacion;

    @Lob
    @Column(name = "caracteristicas")
    private String caracteristicas;

    @ColumnDefault("'mirador'")
    @Lob
    @Column(name = "tipo")
    private String tipo;

    @Lob
    @Column(name = "descripcion")
    private String descripcion;

    @Column(name = "timestamp")
    private Integer timestamp;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "rutas_idRuta", nullable = false)
    private Ruta rutasIdruta;

}