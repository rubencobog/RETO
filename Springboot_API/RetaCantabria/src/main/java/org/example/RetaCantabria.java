package org.example;


import org.springframework.boot.SpringApplication;
import org.springframework.boot.WebApplicationType;
import org.springframework.boot.autoconfigure.domain.EntityScan;

@EntityScan("org.example.Entidades")
public class RetaCantabria {
    public static void main(String[] args) {
        SpringApplication app=new SpringApplication(RetaCantabria.class);
        app.setWebApplicationType(WebApplicationType.NONE);
        app.run(args);
    }
}