package org.example.Entidades;

import com.fasterxml.jackson.annotation.JsonBackReference;
import jakarta.persistence.*;

import java.time.LocalDate;
import java.time.LocalDateTime;

@Entity
@Table(name = "valoracion")
public class Valoracion {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idValora", nullable = false)
    private Integer id;
    private int dificultad;       // 1-5
    private int belleza;          // 1-5
    private int interesCultural;  // 1-5
    private LocalDateTime fecha;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idUsuario", nullable = false)
    @JsonBackReference("valoraciones-usuario")
    private Usuario usuario;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idRuta", nullable = false)
    @JsonBackReference("valoraciones-ruta")
    private Ruta ruta;

    public Valoracion() {
    }

    public Valoracion(Integer id, int dificultad, int belleza, int interesCultural, LocalDateTime fecha, Usuario usuario, Ruta ruta) {
        this.id = id;
        this.dificultad = dificultad;
        this.belleza = belleza;
        this.interesCultural = interesCultural;
        this.fecha = fecha;
        this.usuario = usuario;
        this.ruta = ruta;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public int getDificultad() {
        return dificultad;
    }

    public void setDificultad(int dificultad) {
        this.dificultad = dificultad;
    }

    public int getBelleza() {
        return belleza;
    }

    public void setBelleza(int belleza) {
        this.belleza = belleza;
    }

    public int getInteresCultural() {
        return interesCultural;
    }

    public void setInteresCultural(int interesCultural) {
        this.interesCultural = interesCultural;
    }

    public LocalDateTime getFecha() {
        return fecha;
    }

    public void setFecha(LocalDateTime fecha) {
        this.fecha = fecha;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public void setUsuario(Usuario usuario) {
        this.usuario = usuario;
    }

    public Ruta getRuta() {
        return ruta;
    }

    public void setRuta(Ruta ruta) {
        this.ruta = ruta;
    }
}