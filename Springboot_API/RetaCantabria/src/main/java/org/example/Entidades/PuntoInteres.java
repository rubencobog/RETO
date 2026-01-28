package org.example.Entidades;

import jakarta.persistence.*;
import org.example.Interfaz.PuntosInteresPeligro;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "puntosinteres")
public class PuntoInteres implements PuntosInteresPeligro {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String nombre;

    @ColumnDefault("'naturaleza'")
    @Enumerated(EnumType.STRING)
    @Column(name = "tipo")
    private TIPOPI tipo;

    @Column(name = "caracteristicas_especiales",columnDefinition = "TEXT")
    private String caracteristicasEspeciales;

    @OneToMany(mappedBy = "puntoInteres", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ImagenInteres> imagenes=new ArrayList<>();

    @OneToOne
    @JoinColumn(name = "punto_ruta_id")
    private PuntoRuta puntoRuta;

    @Override
    public PuntoRuta getPunto() {
        return puntoRuta;
    }
}