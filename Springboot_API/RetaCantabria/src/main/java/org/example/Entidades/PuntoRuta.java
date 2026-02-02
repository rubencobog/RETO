package org.example.Entidades;

import com.fasterxml.jackson.annotation.JsonBackReference;
import jakarta.persistence.*;

import java.time.LocalDateTime;

@Entity
@Inheritance(strategy = InheritanceType.SINGLE_TABLE)
@DiscriminatorColumn(name = "tipo_punto")
public abstract class PuntoRuta {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private Integer idPuntoRuta;

    private double longitud;
    private double latitud;
    private int elevacion;
    private LocalDateTime timestamp;

    @ManyToOne(optional = false)
    @JoinColumn(name = "idRuta")
    @JsonBackReference
    private Ruta ruta;

    public PuntoRuta() {
    }

    public PuntoRuta(int idPuntoRuta, double longitud, double latitud, int elevacion, LocalDateTime timestamp, Ruta ruta) {
        this.idPuntoRuta = idPuntoRuta;
        this.longitud = longitud;
        this.latitud = latitud;
        this.elevacion = elevacion;
        this.timestamp = timestamp;
        this.ruta = ruta;
    }

    public Integer getIdPuntoRuta() {
        return idPuntoRuta;
    }

    public void setIdPuntoRuta(int idPuntoRuta) {
        this.idPuntoRuta = idPuntoRuta;
    }

    public double getLongitud() {
        return longitud;
    }

    public void setLongitud(double longitud) {
        this.longitud = longitud;
    }

    public double getLatitud() {
        return latitud;
    }

    public void setLatitud(double latitud) {
        this.latitud = latitud;
    }

    public int getElevacion() {
        return elevacion;
    }

    public void setElevacion(int elevacion) {
        this.elevacion = elevacion;
    }

    public LocalDateTime getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(LocalDateTime timestamp) {
        this.timestamp = timestamp;
    }

    public Ruta getRuta() {
        return ruta;
    }

    public void setRuta(Ruta ruta) {
        this.ruta = ruta;
    }

    public abstract String getTipo();
}
