CREATE DATABASE  IF NOT EXISTS `retacantabria` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `retacantabria`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: retacantabria
-- ------------------------------------------------------
-- Server version	9.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `actividad`
--

DROP TABLE IF EXISTS `actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actividad` (
  `id_actividad` int NOT NULL AUTO_INCREMENT,
  `rutas_id_ruta` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id_actividad`),
  KEY `FKno585m1opiyauukejpchv13ce` (`rutas_id_ruta`),
  CONSTRAINT `FKno585m1opiyauukejpchv13ce` FOREIGN KEY (`rutas_id_ruta`) REFERENCES `rutas` (`id_ruta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actividad`
--

LOCK TABLES `actividad` WRITE;
/*!40000 ALTER TABLE `actividad` DISABLE KEYS */;
/*!40000 ALTER TABLE `actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `calendario`
--

DROP TABLE IF EXISTS `calendario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `calendario` (
  `id_calendario` int NOT NULL AUTO_INCREMENT,
  `id_ruta` int NOT NULL,
  `id_usuario` int NOT NULL,
  `fecha` datetime(6) NOT NULL,
  `detalles` tinytext,
  `recomendaciones` tinytext,
  PRIMARY KEY (`id_calendario`),
  KEY `FKd43p7o6s0o3lusqyrsdyrp32` (`id_ruta`),
  KEY `FKjp5m6kccseblh0lla2891c6fj` (`id_usuario`),
  CONSTRAINT `FKd43p7o6s0o3lusqyrsdyrp32` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`),
  CONSTRAINT `FKjp5m6kccseblh0lla2891c6fj` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calendario`
--

LOCK TABLES `calendario` WRITE;
/*!40000 ALTER TABLE `calendario` DISABLE KEYS */;
/*!40000 ALTER TABLE `calendario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imagenesinteres`
--

DROP TABLE IF EXISTS `imagenesinteres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imagenesinteres` (
  `idimagenesinteres` int NOT NULL AUTO_INCREMENT,
  `puntosinteres_id_puntosinteres` bigint NOT NULL,
  `descripcion` text,
  `url` text NOT NULL,
  PRIMARY KEY (`idimagenesinteres`),
  KEY `FKduuo9ohyoo5eucm87sbpupli` (`puntosinteres_id_puntosinteres`),
  CONSTRAINT `FKduuo9ohyoo5eucm87sbpupli` FOREIGN KEY (`puntosinteres_id_puntosinteres`) REFERENCES `puntosinteres` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imagenesinteres`
--

LOCK TABLES `imagenesinteres` WRITE;
/*!40000 ALTER TABLE `imagenesinteres` DISABLE KEYS */;
/*!40000 ALTER TABLE `imagenesinteres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imagenespeligro`
--

DROP TABLE IF EXISTS `imagenespeligro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imagenespeligro` (
  `idimagenespeligro` int NOT NULL AUTO_INCREMENT,
  `puntospeligro_id_puntospeligro` bigint NOT NULL,
  `descripcion` tinytext,
  `url` tinytext NOT NULL,
  PRIMARY KEY (`idimagenespeligro`),
  KEY `FKsn2w22i15i5vuf2w9b3nlhbhd` (`puntospeligro_id_puntospeligro`),
  CONSTRAINT `FKsn2w22i15i5vuf2w9b3nlhbhd` FOREIGN KEY (`puntospeligro_id_puntospeligro`) REFERENCES `puntospeligro` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imagenespeligro`
--

LOCK TABLES `imagenespeligro` WRITE;
/*!40000 ALTER TABLE `imagenespeligro` DISABLE KEYS */;
/*!40000 ALTER TABLE `imagenespeligro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `punto_ruta`
--

DROP TABLE IF EXISTS `punto_ruta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `punto_ruta` (
  `elevacion` int NOT NULL,
  `id_punto_ruta` int NOT NULL AUTO_INCREMENT,
  `id_ruta` int NOT NULL,
  `latitud` double NOT NULL,
  `longitud` double NOT NULL,
  `timestamp` datetime(6) DEFAULT NULL,
  `tipo_punto` varchar(31) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_punto_ruta`),
  KEY `FKh40g8tvawaagcvuc3dcpp8pnn` (`id_ruta`),
  CONSTRAINT `FKh40g8tvawaagcvuc3dcpp8pnn` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `punto_ruta`
--

LOCK TABLES `punto_ruta` WRITE;
/*!40000 ALTER TABLE `punto_ruta` DISABLE KEYS */;
/*!40000 ALTER TABLE `punto_ruta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puntosinteres`
--

DROP TABLE IF EXISTS `puntosinteres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `puntosinteres` (
  `punto_ruta_id` int DEFAULT NULL,
  `id` bigint NOT NULL AUTO_INCREMENT,
  `caracteristicas_especiales` text,
  `nombre` varchar(255) DEFAULT NULL,
  `tipo` enum('historico_arqueologico','naturaleza','mirador','area_de_descanso','punto_de_agua','refugio_alojamiento','cultural','geologico','fauna_especifica','botánico') DEFAULT 'naturaleza',
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_3f1ss0exd65jfwkjxxdhmfw4t` (`punto_ruta_id`),
  CONSTRAINT `FKn0wi7fkc675mach0cu15v9xe9` FOREIGN KEY (`punto_ruta_id`) REFERENCES `punto_ruta` (`id_punto_ruta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puntosinteres`
--

LOCK TABLES `puntosinteres` WRITE;
/*!40000 ALTER TABLE `puntosinteres` DISABLE KEYS */;
/*!40000 ALTER TABLE `puntosinteres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puntospeligro`
--

DROP TABLE IF EXISTS `puntospeligro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `puntospeligro` (
  `gravedad` tinyint DEFAULT NULL,
  `kilometro` double DEFAULT NULL,
  `punto_ruta_id` int DEFAULT NULL,
  `id` bigint NOT NULL AUTO_INCREMENT,
  `justificacion` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_b1dvwua3hyg99psmdvsbo81tg` (`punto_ruta_id`),
  CONSTRAINT `FKj98n89wj6tc5xj9rxoh6p3arj` FOREIGN KEY (`punto_ruta_id`) REFERENCES `punto_ruta` (`id_punto_ruta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puntospeligro`
--

LOCK TABLES `puntospeligro` WRITE;
/*!40000 ALTER TABLE `puntospeligro` DISABLE KEYS */;
/*!40000 ALTER TABLE `puntospeligro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resenas`
--

DROP TABLE IF EXISTS `resenas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resenas` (
  `fecha` date DEFAULT NULL,
  `id_resena` int NOT NULL AUTO_INCREMENT,
  `id_ruta` int NOT NULL,
  `id_usuario` int NOT NULL,
  `resena` text,
  PRIMARY KEY (`id_resena`),
  KEY `FK6novogobw2qxgw1jnnxck7tl4` (`id_ruta`),
  KEY `FKt4ih3ur3d8r0d5oq8n9urngeu` (`id_usuario`),
  CONSTRAINT `FK6novogobw2qxgw1jnnxck7tl4` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`),
  CONSTRAINT `FKt4ih3ur3d8r0d5oq8n9urngeu` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resenas`
--

LOCK TABLES `resenas` WRITE;
/*!40000 ALTER TABLE `resenas` DISABLE KEYS */;
/*!40000 ALTER TABLE `resenas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rutas`
--

DROP TABLE IF EXISTS `rutas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rutas` (
  `accesibilidad` bit(1) DEFAULT NULL,
  `altitud_max` double DEFAULT NULL,
  `altitud_min` double DEFAULT NULL,
  `desnivel_acumulado` int DEFAULT NULL,
  `desnivel_negativo` int DEFAULT NULL,
  `desnivel_positivo` int DEFAULT NULL,
  `distancia` double NOT NULL,
  `duracion` time(6) NOT NULL,
  `estado_ruta` bit(1) DEFAULT b'0',
  `id_ruta` int NOT NULL AUTO_INCREMENT,
  `indicaciones` tinyint DEFAULT NULL,
  `latitud_final` double NOT NULL,
  `latitud_inicial` double NOT NULL,
  `longitud_final` double NOT NULL,
  `longitud_inicial` double NOT NULL,
  `media_estrellas` double DEFAULT NULL,
  `nivel_esfuerzo` tinyint DEFAULT NULL,
  `nivel_riesgo` tinyint DEFAULT NULL,
  `ruta_familiar` bit(1) DEFAULT NULL,
  `tipo_terreno` tinyint DEFAULT NULL,
  `usuario_id_usuario` int NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `nombre_finalruta` varchar(45) NOT NULL,
  `nombre_inicioruta` varchar(45) NOT NULL,
  `zona_geografica` varchar(45) DEFAULT NULL,
  `archivogpx` tinytext,
  `clasificacion` enum('CIRCULAR','LINEAL') DEFAULT 'LINEAL',
  `recomendaciones_equipo` tinytext,
  `temporadas` tinytext,
  PRIMARY KEY (`id_ruta`),
  KEY `FKrellf3guudcjy8hrv3d8s2gxo` (`usuario_id_usuario`),
  CONSTRAINT `FKrellf3guudcjy8hrv3d8s2gxo` FOREIGN KEY (`usuario_id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rutas`
--

LOCK TABLES `rutas` WRITE;
/*!40000 ALTER TABLE `rutas` DISABLE KEYS */;
INSERT INTO `rutas` VALUES (_binary '',22.22,22.22,234,234,234,234,'04:34:34.000000',_binary '\0',1,2,22.22,22.22,22.22,22.22,3,3,3,_binary '\0',3,1,'Ruta del Cares','final del Cares','inicio del Cares','Cantabria','gpx','LINEAL','llevar rebequita por si refresca','primavera');
/*!40000 ALTER TABLE `rutas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(25) NOT NULL,
  `email` varchar(30) NOT NULL,
  `password` varchar(32) NOT NULL,
  `rol` enum('administrador','diseñador','profesor','alumno') DEFAULT 'alumno',
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'ruben','cobo','rcg@gmail.com','1234','administrador');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `valoracion`
--

DROP TABLE IF EXISTS `valoracion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `valoracion` (
  `belleza` int NOT NULL,
  `dificultad` int NOT NULL,
  `id_ruta` int NOT NULL,
  `id_usuario` int NOT NULL,
  `id_valora` int NOT NULL AUTO_INCREMENT,
  `interes_cultural` int NOT NULL,
  `fecha` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`id_valora`),
  KEY `FKi8bgn6i518ymmqi9676rimfv4` (`id_ruta`),
  KEY `FKkf165idseexrg1k9o7fqusoey` (`id_usuario`),
  CONSTRAINT `FKi8bgn6i518ymmqi9676rimfv4` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`),
  CONSTRAINT `FKkf165idseexrg1k9o7fqusoey` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `valoracion`
--

LOCK TABLES `valoracion` WRITE;
/*!40000 ALTER TABLE `valoracion` DISABLE KEYS */;
/*!40000 ALTER TABLE `valoracion` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-01-30 19:52:45
