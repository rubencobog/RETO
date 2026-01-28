package org.example.Entidades;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

@Entity
@Table(name = "puntosinteres")
public class PuntoInteres extends PuntoRuta{
    @Column(name = "elevacion", nullable = false)
    private Double elevacion;

    @Lob
    @Column(name = "caracteristicas_especiales",columnDefinition = "TEXT")
    private String caracteristicasEspeciales;

    @ColumnDefault("'naturaleza'")
    @Column(name = "tipo")
    private TIPOPI tipo;

    @Column(name = "timestamp")
    private Integer timestamp;

}