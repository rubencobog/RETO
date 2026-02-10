package org.example.Entidades;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;

import java.time.Instant;
import java.time.LocalDate;
import java.time.LocalDateTime;

@Entity
@Table(name = "calendario")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class Calendario {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idCalendario", nullable = false)
    private Integer id;

    @JsonFormat(pattern = "yyyy-MM-dd")
    @Column(name = "fecha", nullable = false)
    private LocalDate fecha;

    @Lob
    @Column(name = "detalles",columnDefinition = "TEXT")
    private String detalles;

    @Lob
    @Column(name = "recomendaciones",columnDefinition = "TEXT")
    private String recomendaciones;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idRuta", nullable = false)
    private Ruta rutasIdruta;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "idUsuario", nullable = false)
    @JsonBackReference("calendarios-usuario")
    @JsonIgnoreProperties("calendarios")
    private Usuario usuarioIdusuario;

    public Calendario() {
    }

    public Calendario(Integer id, LocalDate fecha, String detalles, String recomendaciones, Ruta rutasIdruta, Usuario usuarioIdusuario) {
        this.id = id;
        this.fecha = fecha;
        this.detalles = detalles;
        this.recomendaciones = recomendaciones;
        this.rutasIdruta = rutasIdruta;
        this.usuarioIdusuario = usuarioIdusuario;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public LocalDate getFecha() {
        return fecha;
    }

    public void setFecha(LocalDate fecha) {
        this.fecha = fecha;
    }

    public String getDetalles() {
        return detalles;
    }

    public void setDetalles(String detalles) {
        this.detalles = detalles;
    }

    public String getRecomendaciones() {
        return recomendaciones;
    }

    public void setRecomendaciones(String recomendaciones) {
        this.recomendaciones = recomendaciones;
    }

    public Ruta getRutasIdruta() {
        return rutasIdruta;
    }

    public void setRutasIdruta(Ruta rutasIdruta) {
        this.rutasIdruta = rutasIdruta;
    }

    public Usuario getUsuarioIdusuario() {
        return usuarioIdusuario;
    }

    public void setUsuarioIdusuario(Usuario usuarioIdusuario) {
        this.usuarioIdusuario = usuarioIdusuario;
    }
    @Override
    public String toString() {
        return "Calendario{" +
                "fecha=" + fecha +
                ", detalles='" + detalles + '\'' +
                ", recomendaciones='" + recomendaciones + '\'' +
                ", idRuta=" + (rutasIdruta != null ? rutasIdruta.getId() : null) +
                ", idUsuario=" + (usuarioIdusuario != null ? usuarioIdusuario.getIdUsuario() : null) +
                '}';
    }
}