package org.example.Entidades;

import jakarta.persistence.*;
import org.example.Interfaz.PuntosInteresPeligro;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "puntospeligro")
public class PuntoPeligro implements PuntosInteresPeligro {
    @Id
    @GeneratedValue(strategy =GenerationType.IDENTITY)
    private Long id;

    @Column(name = "kilometro")
    private Double kilometro;

    @Column(name = "gravedad")
    private Byte gravedad;

    @Column(name="justificacion",columnDefinition = "TEXT")
    private String justificacion;


    @OneToMany(mappedBy = "puntoPeligro", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ImagenPeligro> imagenes=new ArrayList<>();

    @OneToOne
    @JoinColumn(name = "punto_ruta_id")
    private PuntoRuta puntoRuta;

    @Override
    public PuntoRuta getPunto() {
        return puntoRuta;
    }
}