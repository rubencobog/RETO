package org.example.Entidades;

import jakarta.persistence.*;
import org.example.Interfaz.PuntosInteresPeligro;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

@Entity
@Table(name = "puntospeligro")
public class PuntoPeligro implements PuntosInteresPeligro {
    @Id
    private Long id;
    @Column(name = "elevacion", nullable = false)
    private Double elevacion;

    @Column(name = "kilometros")
    private Double kilometros;

    @Column(name = "gravedad")
    private Byte gravedad;

    @Column(name = "posicion")
    private Integer posicion;

    @Lob
    @Column(name = "descripcion")
    private String descripcion;

    @Column(name = "timestamp")
    private Integer timestamp;
    @OneToOne
    @JoinColumn(name = "punto_ruta_id")
    private PuntoRuta puntoRuta;

    @Override
    public PuntoRuta getPunto() {
        return puntoRuta;
    }
}