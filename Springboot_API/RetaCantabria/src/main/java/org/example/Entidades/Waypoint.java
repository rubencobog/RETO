package org.example.Entidades;

import jakarta.persistence.Column;
import jakarta.persistence.DiscriminatorValue;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;

import java.time.LocalDateTime;

@Entity
@DiscriminatorValue("WAYPOINT")
public class Waypoint extends PuntoRuta{

    @Column(nullable = true)
    private String nombre;
    @Column(nullable = true)
    private String descripcion;

    public Waypoint() {
    }

    public Waypoint(int idPuntoRuta, double longitud, double latitud, int elevacion, LocalDateTime timestamp, Ruta ruta,String nombre,String descripcion) {
        super(idPuntoRuta, longitud, latitud, elevacion, timestamp,ruta);
        this.nombre=nombre;
        this.descripcion=descripcion;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    @Override
    public String getTipo() {
        return "Waypoint";
    }
}
