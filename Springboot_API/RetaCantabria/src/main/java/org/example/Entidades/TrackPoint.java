package org.example.Entidades;

import jakarta.persistence.*;

import java.time.LocalDateTime;

@Entity
@DiscriminatorValue("TRACKPOINT")
public class TrackPoint extends PuntoRuta{
    public TrackPoint() {
    }

    public TrackPoint(int idPuntoRuta, double longitud, double latitud, int elevacion, LocalDateTime timestamp, Ruta ruta) {
        super(idPuntoRuta, longitud, latitud, elevacion, timestamp, ruta);
    }


    @Override
    public String getTipo() {
        return "Trackpoint";
    }
}
