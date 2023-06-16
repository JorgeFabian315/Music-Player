-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: music_player
-- ------------------------------------------------------
-- Server version	8.0.32

CREATE DATABASE Music_Player;
USE Music_Player;

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
-- Table structure for table `artista`
--

DROP TABLE IF EXISTS `artista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `artista` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `TotalCanciones` int DEFAULT '0',
  `Apodo` varchar(50) NOT NULL,
  `Nacionalidad` varchar(45) NOT NULL,
  `FechaNacimiento` datetime NOT NULL,
  `IdGenero` int NOT NULL,
  `Fotografia` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Artista_Genero_idx` (`IdGenero`),
  CONSTRAINT `fk_Artista_Genero` FOREIGN KEY (`IdGenero`) REFERENCES `genero` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artista`
--

LOCK TABLES `artista` WRITE;
/*!40000 ALTER TABLE `artista` DISABLE KEYS */;
INSERT INTO `artista` VALUES (1,'Michael Jackson',1,'Rey del Pop','Estados Unidos','1958-08-29 00:00:00',2,'https://www.hola.com/imagenes/biografias/michael-jackson/79629-jackson10.jpg'),(2,'Madonna',1,'Reina del Pop','Estados Unidos','1958-08-16 00:00:00',2,'https://album.mediaset.es/eimg/2023/02/21/madonna_f53e.jpg?w=1200'),(3,'Bob Marley',1,'Tuff Gong','Jamaica','1945-02-06 00:00:00',5,'https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png'),(4,'Elvis Presley',1,'Rey del Rock','Estados Unidos','1935-01-08 00:00:00',1,'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Elvis_Presley_promoting_Jailhouse_Rock.jpg/220px-Elvis_Presley_promoting_Jailhouse_Rock.jpg'),(5,'Beyoncé',1,'Queen Bey','Estados Unidos','1981-09-04 00:00:00',2,'https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png'),(6,'Eminem',1,'Slim Shady','Estados Unidos','1972-10-17 00:00:00',3,'https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Eminem_live_at_D.C._2014_%28cropped%29.jpg/220px-Eminem_live_at_D.C._2014_%28cropped%29.jpg'),(7,'Frank Sinatra',1,'La Voz','Estados Unidos','1915-12-12 00:00:00',4,'https://upload.wikimedia.org/wikipedia/commons/thumb/e/e3/Frank_Sinatra_%281957_studio_portrait_close-up%29.jpg/800px-Frank_Sinatra_%281957_studio_portrait_close-up%29.jpg'),(8,'Shakira',0,'Reina del Pop Latino','Colombia','1977-02-02 00:00:00',2,'https://static.mujerhoy.com/www/multimedia/202301/12/media/cortadas/shakira-cambios-look-pelo-kzqD-U190238490989BCD-624x624@MujerHoy.jpg'),(9,'Prince',1,'El Artista Anteriormente Conocido Como Prince','Estados Unidos','1958-06-07 00:00:00',2,'https://ichef.bbci.co.uk/news/640/amz/worldservice/live/assets/images/2016/04/22/160422111840_prince_cambio_nombre_624x351_getty.jpg'),(10,'Adele',1,'La Voz','Reino Unido','1988-05-05 00:00:00',2,'https://media.vogue.mx/photos/62752654e77a9f1126753b96/1:1/w_2283,h_2283,c_limit/adele-GettyImages-1369535083.jpg'),(11,'Johnny Cash',1,'El Hombre de Negro','Estados Unidos','1932-02-26 00:00:00',6,'https://letraslibres.com/wp-content/uploads/2013/09/herrera_01-600pix.jpg'),(12,'Amy Winehouse',1,'La Diva del Soul','Reino Unido','1983-09-14 00:00:00',12,''),(13,'David Bowie',1,'Ziggy Stardust','Reino Unido','1947-01-08 00:00:00',14,'https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png'),(14,'Queen',0,'Los Reyes del Rock','Reino Unido','1970-06-27 00:00:00',1,'https://i.scdn.co/image/b040846ceba13c3e9c125d68389491094e7f2982'),(15,'Rihanna',1,'Reina del Pop','Barbados','1988-02-20 00:00:00',2,'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/rihanna-1666812930.jpg'),(16,'Justin Bieber',1,'Biebs','Canadá','1994-03-01 00:00:00',2,'https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png'),(17,'Gustavo Cerati',1,'Cerati','Argentina','1959-08-11 00:00:00',2,'https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png'),(18,'Juan Gabriel',1,'El Divo de Juárez','México','1950-01-07 00:00:00',7,'https://www.tvynovelas.com/__export/1654513705568/sites/tvynovelas/img/2022/06/06/juangabriel-casas-urquidi.jpg_1076173537.jpg'),(19,'Celia Cruz',1,'La Reina de la Salsa','Cuba','1925-10-21 00:00:00',17,'https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png'),(20,'Carlos Santana',2,'Santana','México','1947-07-20 00:00:00',11,'https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png');
/*!40000 ALTER TABLE `artista` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bitacora_usuario`
--

DROP TABLE IF EXISTS `bitacora_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bitacora_usuario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(200) NOT NULL,
  `CorreoElectronico` varchar(100) NOT NULL,
  `FechaAgregada` datetime DEFAULT CURRENT_TIMESTAMP,
  `IdUsuario` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Bitacora_Usuario` (`IdUsuario`),
  CONSTRAINT `fk_Bitacora_Usuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bitacora_usuario`
--

LOCK TABLES `bitacora_usuario` WRITE;
/*!40000 ALTER TABLE `bitacora_usuario` DISABLE KEYS */;
INSERT INTO `bitacora_usuario` VALUES (1,'Se agrego el usuario: Jorge.','Jorge@gmail.com','2023-06-13 15:55:54',1),(2,'Se agrego el usuario: Juan perez.','Juan@gmail.com','2023-06-13 15:55:54',2),(4,'Se agrego el usuario: Daniela .','Daniela@gmail.com','2023-06-13 15:55:54',4),(5,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 16:11:21',2),(6,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 16:23:20',2),(7,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 16:24:45',2),(8,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 16:26:35',2),(9,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 16:27:35',2),(10,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 16:29:33',2),(11,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 17:02:55',2),(12,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 17:06:52',2),(13,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 17:13:12',2),(14,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 17:15:09',2),(15,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 17:20:21',2),(16,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 17:28:45',2),(17,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 17:32:42',2),(20,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-13 19:29:42',1),(21,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-13 19:32:14',1),(22,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 19:34:34',2),(23,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-13 19:49:36',1),(24,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-13 19:49:49',2),(25,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 09:13:28',2),(26,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 11:54:40',2),(27,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 11:59:13',2),(28,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 12:00:22',2),(29,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 12:02:51',2),(30,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 12:29:44',2),(31,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 12:37:54',1),(32,'Inicio de sesión exitoso del usuario: Daniela@gmail.com.','Daniela@gmail.com','2023-06-14 12:38:47',4),(33,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 12:57:18',1),(34,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 12:57:34',2),(35,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 13:01:12',2),(36,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 13:04:14',2),(37,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 13:06:55',2),(38,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-14 13:12:11',2),(39,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 16:44:33',1),(40,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 16:48:57',1),(41,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 16:55:23',1),(42,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 16:58:25',1),(43,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 20:28:39',1),(44,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 20:29:38',1),(45,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 20:37:12',1),(46,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-14 20:47:57',1),(47,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-15 09:09:28',2),(48,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-15 09:14:19',1),(50,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-15 09:20:22',2),(51,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-15 09:23:12',2),(52,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-15 09:43:18',1),(53,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-15 09:43:31',2),(54,'Inicio de sesión exitoso del usuario: Daniela@gmail.com.','Daniela@gmail.com','2023-06-15 09:58:02',4),(55,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-16 08:34:57',1),(56,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-16 08:36:35',2),(57,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-16 08:50:36',2),(58,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-16 08:50:56',1),(59,'EL usuario: Jorge@gmail.com intento ingresar con una contraseña incorrecta.','Jorge@gmail.com','2023-06-16 08:53:44',1),(60,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-16 08:53:46',1),(61,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-16 08:55:28',1),(62,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-16 08:58:40',1),(63,'Se agrego el usuario: Adriana.','Adriana@gmail.com','2023-06-16 09:01:58',7),(64,'Adrianaa ascendido a Usuario VIP.','Adriana@gmail.com','2023-06-16 09:02:25',7),(65,'Adriana a descendido a Usuario.','Adriana@gmail.com','2023-06-16 09:02:32',7),(66,'EL usuario: Adriana@gmail.com intento ingresar con una contraseña incorrecta.','Adriana@gmail.com','2023-06-16 09:02:44',7),(67,'EL usuario: Adriana@gmail.com intento ingresar con una contraseña incorrecta.','Adriana@gmail.com','2023-06-16 09:02:50',7),(68,'EL usuario: Adriana@gmail.com intento ingresar con una contraseña incorrecta.','Adriana@gmail.com','2023-06-16 09:02:53',7),(69,'EL usuario: Adriana@gmail.com intento ingresar con una contraseña incorrecta.','Adriana@gmail.com','2023-06-16 09:02:59',7),(70,'EL usuario: Adriana@gmail.com intento ingresar con una contraseña incorrecta.','Adriana@gmail.com','2023-06-16 09:03:04',7),(71,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-16 09:03:24',2),(72,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-16 09:15:24',2),(73,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-16 09:18:16',2),(74,'Inicio de sesión exitoso del usuario: Juan@gmail.com.','Juan@gmail.com','2023-06-16 09:21:34',2),(75,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-16 09:25:46',1),(76,'Danielaa ascendido a Usuario VIP.','Daniela@gmail.com','2023-06-16 09:26:03',4),(77,'Inicio de sesión exitoso del usuario: Daniela@gmail.com.','Daniela@gmail.com','2023-06-16 09:26:27',4),(78,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-06-16 09:30:49',1);
/*!40000 ALTER TABLE `bitacora_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cancion`
--

DROP TABLE IF EXISTS `cancion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cancion` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(100) NOT NULL,
  `MeGusta` tinyint(1) DEFAULT '0',
  `IdArtista` int NOT NULL,
  `FechaAgregada` datetime DEFAULT CURRENT_TIMESTAMP,
  `IdGenero` int NOT NULL,
  `IdUsuario` int NOT NULL,
  `Duracion` varchar(45) NOT NULL,
  `Caratula` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Musica_Artista` (`IdArtista`),
  KEY `fk_Musica_Genero` (`IdGenero`),
  KEY `fk_Musica_Usuario` (`IdUsuario`),
  CONSTRAINT `fk_Musica_Artista` FOREIGN KEY (`IdArtista`) REFERENCES `artista` (`Id`),
  CONSTRAINT `fk_Musica_Genero` FOREIGN KEY (`IdGenero`) REFERENCES `genero` (`Id`),
  CONSTRAINT `fk_Musica_Usuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cancion`
--

LOCK TABLES `cancion` WRITE;
/*!40000 ALTER TABLE `cancion` DISABLE KEYS */;
INSERT INTO `cancion` VALUES (1,'Thriller',0,1,'2023-06-13 16:09:53',2,2,'05:57','https://www.mehaceruido.com/wp-content/uploads/2018/12/thriller.jpg'),(2,'Like a Prayer',0,2,'2023-06-13 16:09:53',2,2,'05:39','https://upload.wikimedia.org/wikipedia/en/0/08/Madonna_-_Like_a_Prayer_album.png'),(3,'Redemption Song',1,3,'2023-06-13 16:09:53',5,2,'03:47','https://i.scdn.co/image/ab67616d0000b2733dd13ecefb6fad273bcdcdf3'),(4,'Heartbreak Hotel',0,4,'2023-06-13 16:09:53',1,2,'02:08','https://pics.filmaffinity.com/Adele_Hello_Vaideo_musical-938814499-large.jpg'),(5,'Halo',0,5,'2023-06-13 16:09:53',2,2,'04:21','https://feeling.com.mx/i/s/230/beyonce-i-am...-sasha-fierce.jpg'),(6,'Lose Yourself',0,6,'2023-06-13 16:09:53',3,2,'05:26','https://www.billboard.com/wp-content/uploads/media/8-MILE-Eminem-2002-billboard-1548.jpg'),(7,'My Way',0,7,'2023-06-13 16:09:53',4,2,'04:35','https://i.ytimg.com/vi/Qp6D71kQRhA/maxresdefault.jpg'),(9,'Purple Rain',0,9,'2023-06-13 16:09:53',2,2,'08:41','https://i.ytimg.com/vi/81jraQDTJJk/maxresdefault.jpg'),(10,'Rolling in the Deep',0,10,'2023-06-13 16:09:53',2,2,'03:48','https://upload.wikimedia.org/wikipedia/en/7/74/Adele_-_Rolling_in_the_Deep.png'),(11,'Ring of Fire',0,11,'2023-06-13 16:09:53',6,2,'02:37','https://cdn.smehost.net/johnnycashonlinecom-uslegacyprod/wp-content/uploads/2018/10/jcash_ringoffire.jpg'),(12,'Rehab',0,12,'2023-06-13 16:09:53',12,2,'03:34','https://cde.3.elcomercio.pe/ima/0/1/1/4/7/1147931.jpg'),(13,'Space Oddity',0,13,'2023-06-13 16:09:53',14,2,'05:14','https://garajedelrock.com/wp-content/uploads/2020/05/david-bowie-space-oddity-album-1.jpg'),(15,'Umbrella',0,15,'2023-06-13 16:09:53',2,2,'04:35','https://i.ytimg.com/vi/ScsOxIfwwL4/hqdefault.jpg'),(16,'Baby',0,2,'2023-06-13 16:09:53',2,2,'03:36','https://yt3.googleusercontent.com/ytc/AGIKgqNEz6zvmf7H6vVA5eBWARRTcnXUUP01djNEcEyMNw=s900-c-k-c0x00ffffff-no-rj'),(17,'De Música Ligera',1,17,'2023-06-13 16:09:53',2,2,'05:12','https://i1.sndcdn.com/artworks-000090678745-wqsok1-t500x500.jpg'),(18,'Querida',1,18,'2023-06-13 16:09:53',7,2,'04:21','https://carteleradeteatro.mx/wp-content/uploads/2022/09/querida250.jpg'),(19,'La Vida Es Un Carnaval',0,19,'2023-06-13 16:09:53',17,2,'04:38','https://i.scdn.co/image/ab67616d0000b2732fec273003cb347f452e72ff'),(20,'Smooth',0,20,'2023-06-13 16:09:53',11,2,'04:56','https://i.ytimg.com/vi/6Whgn_iE5uc/maxresdefault.jpg'),(26,'Me Gusta',1,20,'2023-06-16 09:22:28',2,2,'30:00',NULL);
/*!40000 ALTER TABLE `cancion` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Al_Insertar_Cancion_AI` AFTER INSERT ON `cancion` FOR EACH ROW BEGIN
	UPDATE Artista SET TotalCanciones = TotalCanciones + 1 WHERE id = NEW.IdArtista;
	UPDATE Genero SET TotalCanciones = TotalCanciones + 1 WHERE id = NEW.IdGenero;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `cancion_AFTER_UPDATE` AFTER UPDATE ON `cancion` FOR EACH ROW BEGIN
	UPDATE Genero SET TotalCanciones = TotalCanciones - 1 WHERE id = OLD.IdGenero;
	UPDATE Genero SET TotalCanciones = TotalCanciones + 1 WHERE id = NEW.IdGenero;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `genero`
--

DROP TABLE IF EXISTS `genero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genero` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `TotalCanciones` int DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genero`
--

LOCK TABLES `genero` WRITE;
/*!40000 ALTER TABLE `genero` DISABLE KEYS */;
INSERT INTO `genero` VALUES (1,'Rock',1),(2,'Pop',9),(3,'Hip Hop',1),(4,'Jazz',1),(5,'Reggae',1),(6,'Country',1),(7,'Blues',1),(8,'Electrónica',0),(9,'R&B',0),(10,'Folk',0),(11,'Metal',1),(12,'Soul',1),(13,'Funk',0),(14,'Clásica',1),(15,'Indie',0),(16,'Reggaetón',0),(17,'Salsa',1),(18,'Cumbia',0),(19,'Bachata',0),(20,'Punk',0);
/*!40000 ALTER TABLE `genero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Valor` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador',1),(2,'Usuario VIP',2),(3,'Usuario',3);
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `CorreoElectronico` varchar(100) NOT NULL,
  `Contraseña` varchar(100) NOT NULL,
  `IdRol` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `CorreoElectronico` (`CorreoElectronico`),
  KEY `fk_Usuario_Rol` (`IdRol`),
  CONSTRAINT `fk_Usuario_Rol` FOREIGN KEY (`IdRol`) REFERENCES `rol` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Jorge','Jorge@gmail.com','40bd001563085fc35165329ea1ff5c5ecbdbbeef',1),(2,'Juan perez','Juan@gmail.com','40bd001563085fc35165329ea1ff5c5ecbdbbeef',2),(4,'Daniela','Daniela@gmail.com','40bd001563085fc35165329ea1ff5c5ecbdbbeef',3),(7,'Adriana','Adriana@gmail.com','123456789',2);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Al_Insertar_Usuario_BI` BEFORE INSERT ON `usuario` FOR EACH ROW BEGIN
	SET NEW.Contraseña = SHA1(NEW.Contraseña);
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Al_Insertar_Usuario_AI` AFTER INSERT ON `usuario` FOR EACH ROW BEGIN
	INSERT INTO Bitacora_Usuario(Descripcion,CorreoElectronico,IdUsuario) 
    VALUES(CONCAT('Se agrego el usuario: ', NEW.Nombre,'.'), NEW.CorreoElectronico, NEW.id);
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Al_Actualizar_Usuario_UI` AFTER UPDATE ON `usuario` FOR EACH ROW BEGIN
	SET @ROL_VIEJO = (SELECT Valor FROM ROL WHERE Id = OLD.IdRol);
	SET @ROL_NUEVO = (SELECT Valor FROM ROL WHERE Id = NEW.IdRol);
    
    IF ( @ROL_VIEJO != @ROL_NUEVO) THEN 
    BEGIN
		IF( @ROL_NUEVO < @ROL_VIEJO) THEN 
        BEGIN
			INSERT INTO Bitacora_Usuario(Descripcion,CorreoElectronico,IdUsuario) 
			VALUES(CONCAT(NEW.Nombre, ' a descendido a Usuario.'), NEW.CorreoElectronico, NEW.id);
        END;
        ELSEIF(@ROL_NUEVO > @ROL_VIEJO) THEN  
        BEGIN
			INSERT INTO Bitacora_Usuario(Descripcion,CorreoElectronico,IdUsuario) 
			VALUES(CONCAT(NEW.Nombre, 'a ascendido a Usuario VIP.'), NEW.CorreoElectronico, NEW.id);
        END;
        END IF;
    END;
	END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `vistaultrasuperperrona`
--

DROP TABLE IF EXISTS `vistaultrasuperperrona`;
/*!50001 DROP VIEW IF EXISTS `vistaultrasuperperrona`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistaultrasuperperrona` AS SELECT 
 1 AS `Nombre`,
 1 AS `Apodo`,
 1 AS `Nacionalidad`,
 1 AS `FechaNacimiento`,
 1 AS `Genero`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vw_cancionesfavoritas`
--

DROP TABLE IF EXISTS `vw_cancionesfavoritas`;
/*!50001 DROP VIEW IF EXISTS `vw_cancionesfavoritas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_cancionesfavoritas` AS SELECT 
 1 AS `Titulo`,
 1 AS `Apodo`,
 1 AS `Caratula`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'music_player'
--

--
-- Dumping routines for database 'music_player'
--
/*!50003 DROP FUNCTION IF EXISTS `fn_InicioSeion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `fn_InicioSeion`(pcorreo VARCHAR(100), pcontrasena VARCHAR(100)) RETURNS int
    DETERMINISTIC
BEGIN
	DECLARE ESTADO INT;
    
	SET @EXISTE = (SELECT COUNT(Id) FROM Usuario WHERE CorreoElectronico = pcorreo);
	
    IF(@EXISTE = 1) THEN -- EXISTE EL CORREO
    BEGIN
		SET @IdUS = (SELECT Id FROM Usuario WHERE CorreoElectronico = pcorreo);
		SET @CONTRASENA = (SELECT Contraseña FROM Usuario WHERE CorreoElectronico = pcorreo);
        IF( @CONTRASENA = SHA1(pcontrasena)) THEN
        BEGIN
			SET ESTADO = 1; -- CORREO Y CONTRASENA EXITOSO
            INSERT INTO Bitacora_Usuario(Descripcion,CorreoElectronico,IdUsuario) 
			VALUES(CONCAT('Inicio de sesión exitoso del usuario: ', pcorreo,'.'), pcorreo, @IdUs);
        END;
        ELSE
        BEGIN 
			SET ESTADO = 2; -- CONTRASENA INCORRECTA
            INSERT INTO Bitacora_Usuario(Descripcion,CorreoElectronico,IdUsuario) 
			VALUES(CONCAT('EL usuario: ', pcorreo,' intento ingresar con una contraseña incorrecta.'), pcorreo, @IdUs);
        END;
        END IF;
    END;
    
    ELSE
    BEGIN 
		SET ESTADO = 0; -- NO EXISTE EL CORREO 
    END;
    END IF;
    
	RETURN ESTADO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_EliminarCancion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EliminarCancion`(pId int)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION
BEGIN
     ROLLBACK;   -- En caso de una excepcion, se hace el Rollback.
END;

START TRANSACTION;

SET @idartista = (SELECT  IdArtista 
                  FROM cancion
                  WHERE Id = pId
                  );
                  
SET @idgenero = (SELECT IdGenero
                 FROM cancion
                 WHERE Id = pId
                 );

-- Eliminar de tabla cancion
DELETE FROM cancion WHERE Id = pId;

-- Restar 1 a el total de canciones del artista 
UPDATE artista
SET TotalCanciones = TotalCanciones - 1
WHERE Id = @idartista;

-- GENERO
-- Restar 1 a el total del genero
UPDATE genero
SET TotalCanciones = TotalCanciones -1
WHERE Id = @idgenero;


COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `vistaultrasuperperrona`
--

/*!50001 DROP VIEW IF EXISTS `vistaultrasuperperrona`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaultrasuperperrona` AS select `a`.`Nombre` AS `Nombre`,`a`.`Apodo` AS `Apodo`,`a`.`Nacionalidad` AS `Nacionalidad`,`a`.`FechaNacimiento` AS `FechaNacimiento`,`g`.`Nombre` AS `Genero` from (`artista` `a` join `genero` `g` on((`a`.`IdGenero` = `g`.`Id`))) order by `a`.`IdGenero`,`a`.`Nacionalidad` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vw_cancionesfavoritas`
--

/*!50001 DROP VIEW IF EXISTS `vw_cancionesfavoritas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_cancionesfavoritas` AS select `c`.`Titulo` AS `Titulo`,`a`.`Apodo` AS `Apodo`,`c`.`Caratula` AS `Caratula` from (`cancion` `c` join `artista` `a` on((`c`.`IdArtista` = `a`.`Id`))) order by `c`.`FechaAgregada` limit 3 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-16  9:39:16
