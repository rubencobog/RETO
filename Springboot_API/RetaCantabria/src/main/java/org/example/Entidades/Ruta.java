package org.example.Entidades;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.time.LocalTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "rutas")
public class Ruta {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idRuta", nullable = false)
    private Integer id;

    @Column(name = "nombre", nullable = false, length = 20)
    private String nombre;

    @Column(name = "nombre_inicioruta", nullable = false, length = 45)
    private String nombreInicioruta;

    @Column(name = "nombre_finalruta", nullable = false, length = 45)
    private String nombreFinalruta;

    @Column(name = "latitudInicial", nullable = false)
    private Double latitudInicial;

    @Column(name = "latitudFinal", nullable = false)
    private Double latitudFinal;

    @Column(name = "longitudInicial", nullable = false)
    private Double longitudInicial;

    @Column(name = "longitudFinal", nullable = false)
    private Double longitudFinal;

    @Column(name = "distancia", nullable = false)
    private Double distancia;

    @Column(name = "duracion", nullable = false)
    private LocalTime duracion;

    @Column(name = "desnivelPositivo")
    private Integer desnivelPositivo;

    @Column(name = "desnivelNegativo")
    private Integer desnivelNegativo;

    @Column(name="desnivelAcumulado")
    private Integer desnivelAcumulado;

    @Column(name = "altitudMax")
    private Double altitudMax;

    @Column(name = "altitudMin")
    private Double altitudMin;

    @ColumnDefault("'LINEAL'")
    @Column(name = "clasificacion")
    private CLASIFICACION clasificacion;

    @Column(name = "nivelEsfuerzo")
    private Byte nivelEsfuerzo;

    @Column(name = "nivelRiesgo")
    private Byte nivelRiesgo;

    @ColumnDefault("0")
    @Column(name = "estadoRuta")
    private boolean estadoRuta;

    @Column(name = "tipoTerreno")
    private Byte tipoTerreno;

    @Column(name = "indicaciones")
    private Byte indicaciones;

    @Lob
    @Column(name = "temporadas")
    private String temporadas;

    @Column(name = "accesibilidad")
    private boolean accesibilidad;

    @Column(name = "rutaFamiliar")
    private boolean rutaFamiliar;

    @Lob
    @Column(name = "archivoGPX")
    private String archivoGPX;

    @Lob
    @Column(name = "recomendacionesEquipo")
    private String recomendacionesEquipo;

    @Column(name = "zonaGeografica", length = 45)
    private String zonaGeografica;

    @Column(name = "mediaEstrellas")
    private Double mediaEstrellas;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "usuario_idUsuario", nullable = false)
    private Usuario usuarioIdusuario;
    @OneToMany(mappedBy = "ruta", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<PuntoRuta> puntos = new ArrayList<>();

}