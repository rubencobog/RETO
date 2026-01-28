package org.example.Entidades;

import jakarta.persistence.*;

@Entity
@Table(name = "actividad")
public class Actividad {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idActividad", nullable = false)
    private Integer id;

    @Column(name = "nombre", nullable = false, length = 50)
    private String nombre;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "rutas_idRuta", nullable = false)
    private Ruta rutasIdruta;

    public Actividad() {
    }

    public Actividad(Integer id, String nombre, Ruta rutasIdruta) {
        this.id = id;
        this.nombre = nombre;
        this.rutasIdruta = rutasIdruta;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public Ruta getRutasIdruta() {
        return rutasIdruta;
    }

    public void setRutasIdruta(Ruta rutasIdruta) {
        this.rutasIdruta = rutasIdruta;
    }

}