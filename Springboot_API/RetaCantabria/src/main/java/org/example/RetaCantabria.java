package org.example;


import org.example.Entidades.Ruta;
import org.example.Logica.RutaRepository;
import org.example.Servicio.RutaService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.annotation.Bean;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

import java.util.List;

@SpringBootApplication
@EntityScan("org.example")
@EnableJpaRepositories("org.example")
public class RetaCantabria {
    public static void main(String[] args) {
        SpringApplication.run(RetaCantabria.class, args);
    }
    }