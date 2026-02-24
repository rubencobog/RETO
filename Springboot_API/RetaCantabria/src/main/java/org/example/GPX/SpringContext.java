package org.example.GPX;

import org.springframework.beans.BeansException;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import org.springframework.stereotype.Component;
// Clase (enlace) para usar los metodos de las clases de la base de datos (utilizando Spring)
@Component
public class SpringContext implements ApplicationContextAware {
    // Permite acceder a la aplicación(base de datos) desde cualquier parte de este programa
    private static ApplicationContext context;
    @Override
    public void setApplicationContext(ApplicationContext applicationContext) throws BeansException {
        context=applicationContext;
    }
    public static <T> T getBean(Class<T> beanClass) {
        return context.getBean(beanClass);
    }
}
