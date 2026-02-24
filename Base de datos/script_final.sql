CREATE DATABASE  IF NOT EXISTS `retacantabria` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `retacantabria`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: retacantabria
-- ------------------------------------------------------
-- Server version	8.0.41

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
  `fecha` date NOT NULL,
  `detalles` text,
  `recomendaciones` text,
  PRIMARY KEY (`id_calendario`),
  KEY `FKjp5m6kccseblh0lla2891c6fj` (`id_usuario`),
  KEY `FKd43p7o6s0o3lusqyrsdyrp32` (`id_ruta`),
  CONSTRAINT `FKd43p7o6s0o3lusqyrsdyrp32` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FKjp5m6kccseblh0lla2891c6fj` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calendario`
--

LOCK TABLES `calendario` WRITE;
/*!40000 ALTER TABLE `calendario` DISABLE KEYS */;
INSERT INTO `calendario` VALUES (6,4,5,'2026-02-11','',''),(17,2,5,'2026-02-21','','');
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
  CONSTRAINT `FKh40g8tvawaagcvuc3dcpp8pnn` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `punto_ruta`
--

LOCK TABLES `punto_ruta` WRITE;
/*!40000 ALTER TABLE `punto_ruta` DISABLE KEYS */;
INSERT INTO `punto_ruta` VALUES (668,1,2,40.416775,-3.70379,'2026-02-11 10:00:00.000000','TRACKPOINT',NULL,NULL),(670,2,2,40.41702,-3.70415,'2026-02-11 10:02:00.000000','TRACKPOINT',NULL,NULL),(673,3,2,40.41735,-3.7045,'2026-02-11 10:04:00.000000','TRACKPOINT',NULL,NULL),(675,4,2,40.41768,-3.70482,'2026-02-11 10:06:00.000000','TRACKPOINT',NULL,NULL),(678,5,2,40.418,-3.7051,'2026-02-11 10:08:00.000000','TRACKPOINT',NULL,NULL),(668,6,2,40.416775,-3.70379,'2026-02-11 10:00:00.000000','WAYPOINT','Prueba','Punto de prueba'),(15,9,10,40.417,-3.7042,'2026-01-29 14:30:00.000000','WAYPOINT','No','1'),(15,10,10,40.417,-3.7042,'2026-01-29 14:30:00.000000','TRACKPOINT',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puntospeligro`
--

LOCK TABLES `puntospeligro` WRITE;
/*!40000 ALTER TABLE `puntospeligro` DISABLE KEYS */;
INSERT INTO `puntospeligro` VALUES (3,234,1,1,'es to cuesta');
/*!40000 ALTER TABLE `puntospeligro` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `actualizarNivelRiesgo_Insert` AFTER INSERT ON `puntospeligro` FOR EACH ROW BEGIN
  DECLARE media_gravedad DOUBLE;

  SELECT AVG(gravedad)
  INTO media_gravedad
  FROM puntospeligro
  WHERE rutas_idRuta = NEW.punto_ruta_id;

  UPDATE rutas
  SET nivel_riesgo = ROUND(media_gravedad)
  WHERE idRuta = NEW.punto_ruta_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  CONSTRAINT `FK6novogobw2qxgw1jnnxck7tl4` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`) ON DELETE CASCADE,
  CONSTRAINT `FKt4ih3ur3d8r0d5oq8n9urngeu` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resenas`
--

LOCK TABLES `resenas` WRITE;
/*!40000 ALTER TABLE `resenas` DISABLE KEYS */;
INSERT INTO `resenas` VALUES ('2026-02-04',1,2,4,'Buena ruta, me encontré 5 euros'),('2026-02-12',7,2,5,'Reseña ru'),('2026-02-12',8,2,5,'Reseña'),('2026-02-12',9,2,5,'Mejor ruta del siglo');
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
  `distancia` double DEFAULT NULL,
  `duracion` time DEFAULT NULL,
  `estado_ruta` bit(1) DEFAULT b'0',
  `id_ruta` int NOT NULL AUTO_INCREMENT,
  `indicaciones` tinyint DEFAULT NULL,
  `latitud_final` double DEFAULT NULL,
  `latitud_inicial` double DEFAULT NULL,
  `longitud_final` double DEFAULT NULL,
  `longitud_inicial` double DEFAULT NULL,
  `media_estrellas` double DEFAULT NULL,
  `nivel_esfuerzo` tinyint DEFAULT NULL,
  `nivel_riesgo` tinyint DEFAULT NULL,
  `ruta_familiar` bit(1) DEFAULT NULL,
  `tipo_terreno` tinyint DEFAULT NULL,
  `usuario_id_usuario` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `nombre_finalruta` varchar(45) DEFAULT NULL,
  `nombre_inicioruta` varchar(45) DEFAULT NULL,
  `zona_geografica` varchar(45) DEFAULT NULL,
  `archivogpx` tinytext,
  `clasificacion` enum('CIRCULAR','LINEAL') DEFAULT 'LINEAL',
  `recomendaciones_equipo` tinytext,
  `temporadas` tinytext,
  PRIMARY KEY (`id_ruta`),
  KEY `FKrellf3guudcjy8hrv3d8s2gxo` (`usuario_id_usuario`),
  CONSTRAINT `FKrellf3guudcjy8hrv3d8s2gxo` FOREIGN KEY (`usuario_id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rutas`
--

LOCK TABLES `rutas` WRITE;
/*!40000 ALTER TABLE `rutas` DISABLE KEYS */;
INSERT INTO `rutas` VALUES (_binary '',678,668,20,10,10,0.35205844280237364,'00:00:00',_binary '',2,3,34.34,34.34,78.87,78.34,4.2,2,3,_binary '',2,3,'Ruta del Cares','final','inicio','winsconsin','gpx','CIRCULAR','rebequita por si refresca','verano'),(_binary '\0',0,0,0,0,0,123,'02:00:00',_binary '',3,0,0,0,0,0,0,0,0,_binary '\0',0,5,'Ruta route',NULL,NULL,'qweqe',NULL,'LINEAL','qweqwe','Primavera'),(_binary '\0',0,0,0,0,0,123,'02:00:00',_binary '',4,0,0,0,0,0,0,0,0,_binary '\0',0,5,'Ruta Reto',NULL,NULL,'qweqe',NULL,'LINEAL','qweqwe','Primavera'),(_binary '\0',0,0,0,0,0,123,'00:03:00',_binary '',7,0,0,0,0,0,0,0,0,_binary '\0',0,5,'Rutilla',NULL,NULL,'asdasd',NULL,'LINEAL','adsad','Verano'),(_binary '\0',0,0,0,0,0,1232,'03:00:00',_binary '',8,0,0,0,0,0,0,0,0,_binary '\0',0,5,'ruta2',NULL,NULL,'kbzn',NULL,'CIRCULAR','si','Otoño'),(_binary '\0',15,15,0,0,0,0,'00:00:00',_binary '',10,1,0,0,0,0,0,2,3,_binary '\0',1,5,'Ruta de Montaña Ejemplo','','','',NULL,'CIRCULAR','',''),(_binary '\0',0,0,0,0,0,1234,'02:02:02',_binary '\0',11,0,0,0,0,0,0,0,0,_binary '',0,5,'Ruta del bacalao',NULL,NULL,'Madagascar',NULL,'CIRCULAR','si','Verano');
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
  `password` text NOT NULL,
  `rol` enum('administrador','diseñador','profesor','alumno') DEFAULT 'alumno',
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (3,'RUBEN','cobo','rcg@hotmail.com','$2a$10$TJd3rtABDymsIwc2JRofr.YflWLD0p4N0Nr83E1cHkuLp5tWZZ3ze','administrador'),(4,'admin','admin','prueba','$2a$10$wdam.eRtj8PHlJht/TDWb.snTkwtmFRf9cIKhWiUiMomjVdRBmNI6','diseñador'),(5,'admin','admin','admin','$2a$10$Bin/tCtde3cglNO.bR33o.PD0qrLO4nscze6/pUkKp9HbL3Kdg1iG','administrador'),(6,'ethan','ethan','ethan','$2a$10$TQdM0T6nqYKOGJqFcECmXeE.nh9Pz/vUjQC5HT133TFuJQ4MbIPHa','diseñador'),(7,'hola','hola','hola','$2a$10$p1RR9tmZ4Xv2G6j/hAm.sO11FXj2X6/DBGxPqIzHsmCadGxUNO8xG','profesor'),(10,'Fabian','Fabianez','fabian','$2a$10$.Yd2TF4PQIH2gSzZplqFwevJFtSq8UX0nQaC/Dh2dugBOXhIxs50u','alumno');
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
  CONSTRAINT `FKi8bgn6i518ymmqi9676rimfv4` FOREIGN KEY (`id_ruta`) REFERENCES `rutas` (`id_ruta`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FKkf165idseexrg1k9o7fqusoey` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `valoracion`
--

LOCK TABLES `valoracion` WRITE;
/*!40000 ALTER TABLE `valoracion` DISABLE KEYS */;
INSERT INTO `valoracion` VALUES (4,1,2,5,11,1,'2026-02-12 16:07:36.438676'),(5,5,2,5,12,5,'2026-02-12 16:19:36.534957'),(5,5,2,5,13,5,'2026-02-12 16:31:36.902918'),(5,5,2,5,14,5,'2026-02-13 12:43:17.321770'),(4,3,2,5,15,5,'2026-02-13 12:58:46.939609');
/*!40000 ALTER TABLE `valoracion` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `actualizarMediaEstrellas_Insert` AFTER INSERT ON `valoracion` FOR EACH ROW BEGIN
  DECLARE media DOUBLE;

  SELECT AVG( (belleza + interes_cultural + dificultad) / 3 )
  INTO media
  FROM valoracion
  WHERE id_ruta = NEW.id_ruta;

  UPDATE rutas
  SET media_estrellas = ROUND(IFNULL(media, 0), 2)
  WHERE id_ruta = NEW.id_ruta;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `actualizarMediaEstrellas_Delete` AFTER DELETE ON `valoracion` FOR EACH ROW BEGIN
  DECLARE media DOUBLE;

  SELECT AVG( (belleza + interes_cultural + dificultad) / 3 )
  INTO media
  FROM valoracion
  WHERE id_ruta = OLD.id_ruta;

  UPDATE rutas
  SET media_estrellas = ROUND(IFNULL(media, 0), 2)
  WHERE id_ruta = OLD.id_ruta;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Dumping events for database 'retacantabria'
--

--
-- Dumping routines for database 'retacantabria'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-02-13 14:05:22
