package org.example.Entidades;

import jakarta.persistence.*;

import java.time.LocalDate;

@Entity
@Table(name="resenas")
public class Resena {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idResena;
    @Column(name = "resena",columnDefinition = "TEXT")
    private String resena;
    private LocalDate fecha;
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idUsuario", nullable = false)
    private Usuario usuario;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idRuta", nullable = false)
    private Ruta ruta;

    public Resena() {
    }

    public Resena(int idResena, String resena, LocalDate fecha, Usuario usuario, Ruta ruta) {
        this.idResena = idResena;
        this.resena = resena;
        this.fecha = fecha;
        this.usuario = usuario;
        this.ruta = ruta;
    }

    public Integer getIdResena() {
        return idResena;
    }

    public void setIdResena(int idResena) {
        this.idResena = idResena;
    }

    public String getResena() {
        return resena;
    }

    public void setResena(String resena) {
        this.resena = resena;
    }

    public LocalDate getFecha() {
        return fecha;
    }

    public void setFecha(LocalDate fecha) {
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
