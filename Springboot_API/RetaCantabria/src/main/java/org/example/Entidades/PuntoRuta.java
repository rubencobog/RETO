package org.example.Entidades;

import jakarta.persistence.*;

@Entity
@Inheritance(strategy = InheritanceType.JOINED)
public class PuntoRuta {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int idPuntoRuta;
    private String nombre;
    private String descripcion;
    private double longitud;
    private double latitud;

    @ManyToOne(optional = false)
    @JoinColumn(name = "idRuta")
    private Ruta ruta;
}
