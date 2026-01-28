package org.example.Entidades;

import jakarta.persistence.*;

@Entity
@Table(name = "trackpoints")
public class TrackPoint {
    @Id
    @GeneratedValue(strategy =GenerationType.IDENTITY)
    private int idTrackpoint;

}
