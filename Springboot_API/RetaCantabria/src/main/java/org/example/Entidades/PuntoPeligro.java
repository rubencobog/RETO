package org.example.Entidades;

import jakarta.persistence.*;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

@Entity
@Table(name = "puntospeligro")
public class PuntoPeligro extends PuntoRuta{

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
}