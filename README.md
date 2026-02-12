<h1 align="center">🗺️ ITINERE 🗺️</h1>

<p align="center">
  Plataforma para creación , planificación de actividades  y recorrido de rutas seguras , estupendas y relajantes
</p>

<p align="center">
  <img src="https://github.com/rubencobog/RETO/blob/a07b755a3df5fc2fedb25fb56cddfa9e596b4343/LOGO_app/itinere_logo.png" alt="Logo de Itinere" width="20%">
</p>
<h6 align="center">
  <em>Vendí mi Kia, me hice una ruta al día y ahora me siguen todas las tías</em>
</h6>
<p align="center">
  <img src="https://img.shields.io/badge/Java-17-ED8B00?style=for-the-badge&logo=java&logoColor=white"/>
  <img src="https://img.shields.io/badge/SpringBoot-3.2-6DB33F?style=for-the-badge&logo=springboot&logoColor=white"/>
  <img src="https://img.shields.io/badge/Kotlin-1.9-0095D5?style=for-the-badge&logo=kotlin&logoColor=white"/>
  <img src="https://img.shields.io/badge/MySQL-8.1-00758F?style=for-the-badge&logo=mysql&logoColor=white"/>
  <img src="https://img.shields.io/badge/Intellig_Idea_Ultimate-2026-6f42c1?style=for-the-badge&logo=idea&logoColor=white"/>
  <img src="https://img.shields.io/badge/Visual_Studio-2022-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white"/>
  <img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white"/>
  <img src="https://img.shields.io/badge/Spring_Security-6.1-6DB33F?style=for-the-badge&logo=spring&logoColor=white"/>
  <img src="https://img.shields.io/badge/Fused_Location_Provider-21.1.0-FF6F00?style=for-the-badge&logo=android&logoColor=white"/>
</p>

---

<br>

## 🚀 Introducción

**Itinere** es una plataforma innovadora diseñada para **facilitar la creación y planificación de rutas** de manera sencilla y eficiente.  
Ya sea que quieras recorrer caminos a pie, en bici o para tus actividades al aire libre, Itinere te ayuda a **organizar cada recorrido** de forma clara y segura.  
Con alcance mundial y compatibilidad total con **ordenador y móvil**, podrás disfrutar de una experiencia de **alta calidad** en cualquier lugar. 

Actualmente, **Itinere** se encuentra en **beta abierta** y todavía está en desarrollo, por lo que **puede contener errores**.  
¡Tu feedback es muy importante! Si encuentras algún fallo, **contáctanos** y serás **recompensado**. 

<p align="center" style="font-size:0.9em;">
📧 Contáctanos en: <a href="mailto:itinere@gmail.com">itinere@gmail.com</a>
</p>

## 📌 Lógica de la aplicación

Itinere es una **solución tecnológica integral** que conecta:

- 🖥️ **Aplicación de Escritorio** para administración avanzada  
- 📱 **Aplicación Móvil** para usuarios finales  
- 🌐 **API REST** segura y escalable  
- 🗄️ **Base de Datos** relacional optimizada  
- 🔒 **Spring Security** para autenticación y control de acceso

💡 Arquitectura moderna basada en **buenas prácticas** y **diseño limpio**.



## 🧱 Arquitectura del Sistema

```
📱 Mobile App 
      │
      ▼
🌐 REST API 
      │
      ▼
🗄️ MySQL Database 
      ▲
      │
🌐 REST API 
      ▲
      │
🖥️ Desktop App 
```

## ⚙️ Principios Aplicados

- 🧩 Separación en capas  
- 🏗️ Arquitectura RESTful  
- 🔁 Patrón DTO  
- 🔐 Control de excepciones global  
- ✔️ Validaciones robustas  

---

## 🖥️ Aplicación de Escritorio

<p>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/java/java-original.svg" width="40"/>
</p>

### ✨ Funcionalidades

- 📋 **CRUD completo** (crear, leer, actualizar y eliminar rutas y actividades)  
- 🔎 **Filtros dinámicos** para encontrar rutas según tus necesidades  
- 👥 **Gestión de usuarios** con control de acceso seguro  
- 🛡️ **Validación en tiempo real** de datos y entradas  
- ⚠️ **Manejo estructurado de errores** para mantener estabilidad  
- 📂 **Generación de archivos GPX y PDF** de rutas y reportes  
- 🔗 **Creación de códigos QR** para compartir rutas fácilmente  
- 🗺️ **Mapas dinámicos** para visualizar rutas interactivamente  
- 📇 **Fichas informativas** con detalles de cada ruta o actividad

### 🛠️ Stack Tecnológico

- ☕ **Java 17**  
- 🖼️ **Swing / JavaFX**  
- 🔌 **JDBC**  
- 📚 **Programación funcional**  
- 📝 **QrCoder** – para generación de códigos QR  
- 📄 **iText** – para creación y manejo de PDFs  
- 📊 **OxyPlot** – para generación de gráficos y visualización de datos
- 📦 **JSON / Gson** – manejo de datos y deserialización  
---

## 📱 Aplicación Móvil

<p>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/android/android-original.svg" width="40"/>
</p>

### ✨ Funcionalidades

- 🔐 **Inicio de sesión seguro** con autenticación moderna  
- 🗺️ **Mapas interactivos y navegación en tiempo real**  
- 📊 **Visualización de estadísticas personales** de rutas recorridas  
- 📇 **Fichas de rutas y actividades** con información detallada  
- 🏷️ **Etiquetado y favoritos** para rutas preferidas  
- 🌐 **Sincronización automática con API REST**  
- 🎨 **Interfaz adaptativa** a móviles y tablets   

### 🛠️ Tecnologías

- 🤖 **Android Studio** – IDE oficial para desarrollo móvil  
- 🔗 **Retrofit / OkHttp** – comunicación eficiente con API REST  
- 📦 **JSON / Gson** – manejo de datos y deserialización  
- 🗺️ **Google Maps & Fused Location Provider 21.1.0** – mapas y geolocalización en tiempo real  
- ⚡ **Coroutines / Flow** – operaciones asíncronas y rendimiento optimizado  

---

## 🌐 Backend (API REST)

<p>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/spring/spring-original.svg" width="40"/>
</p>

### 🚀 Características

El backend de Itinere ofrece una **API REST robusta, segura y confiable**:  

- 📡 **Endpoints RESTful** para rutas, usuarios y actividades  
- 🧾 **Validaciones con annotations** para mantener consistencia de datos  
- 🔑 **Autenticación JWT** y manejo seguro de sesiones  
- 🔒 **Encriptación de contraseñas y datos sensibles**  
- 🧱 **Arquitectura MVC** para separación de responsabilidades  
- 🛑 **Manejo global de excepciones** para estabilidad de la API  
- 📂 **Generación de ficheros GPX y PDF** de rutas y reportes  
- 🛡️ **Rutas seguras** con validaciones de cada lugar y control de acceso
- ⚡ **Triggers de auditoría** con cambio de datos en tiempo real

---

## 🗄️ Base de Datos

<p>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mysql/mysql-original.svg" width="50"/>
</p>

### 📊 Modelo Relacional

- 👤 `Actividad`
- 📅 `Calendario`
- 📝 `Resena`
- 🖼️ `ImagenInteres`
- ⚠️ `ImagenPeligro`
- 📍 `PuntoInteres`
- 📌 `PuntoPeligro`
- 🗺️ `PuntoRuta`
- 🧾 `Ruta`
- 👤 `Usuario`
- ⭐ `Valoracion`
- 📌 `Waypoint`
- 🚶 `TrackPoint`

### ⚙️ Características Técnicas

- 🔗 Claves primarias y foráneas  
- 📈 Índices optimizados  
- 🧠 Procedimientos almacenados  
- 🛡️ Integridad referencial garantizada

---

## 🔐 Seguridad

La plataforma Itinere utiliza **Spring Security 6.1** para garantizar la seguridad de la aplicación y los datos:  

- 🔒 **Encriptación de contraseñas con BCrypt**  
- 🚫 **Protección contra SQL Injection** y ataques comunes  
- 🛡️ **Validación server-side** de formularios y datos críticos  
- 👁️ **Control de sesiones y token JWT** para autenticación segura  
- 🔗 **Protección de endpoints REST** según roles y accesos  
- 🛡️ **Políticas de seguridad adicionales**: CORS, CSRF y manejo de errores centralizado

---

## 🚀 Instalación

### 🗄️ Base de Datos

```sql
CREATE DATABASE retacantabria;
```




### 🌐 Backend

```bash
git clone https://github.com/rubencobog/RETO/tree/Develop
cd backend
mvn clean install
```

Configurar `application.properties`.



### 🖥️ Desktop App

Abrir proyecto en NetBeans / IntelliJ.  
Configurar credenciales de base de datos.



### 📱 Mobile App

Abrir en Android Studio.  
Configurar URL del backend.



### 📈 Roadmap

- ✅ Arquitectura base  
- ✅ CRUD completo  
- ✅ API REST  
- 🔄 Testing automatizado  
- 🐳 Dockerización  
- 🚀 CI/CD  

---

## 🤝 Contribución

1. 🍴 Fork del repositorio  
2. 🌱 Crear nueva rama  
3. 💾 Commit de cambios  
4. 🔀 Pull Request  
5. 👥 Colaboración en equipo  
   - Todos los integrantes deben seguir las normas de comportamiento y buenas prácticas.  
   - Coordinarse con los compañeros antes de integrar cambios importantes.  
   - Revisar y aprobar los Pull Requests de otros miembros antes de fusionar.
     

## 👥 Integrantes
- 🧑‍💻 [Fabian](https://github.com/Napster002)  
- 👩‍💻 [Ruben](https://github.com/rubencobog)   
- 👩‍🔬 [Francisco](https://github.com/Fran898)  
- 🧑‍🚀 [Saul](https://github.com/SaulGarciaaaa)



## 📄 Licencia

📘 MIT License

<p align="center">
  ✨ Código limpio · Arquitectura escalable · Diseño profesional ✨
</p>
