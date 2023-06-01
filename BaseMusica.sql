-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: music_player
-- ------------------------------------------------------
-- Server version	8.0.32

CREATE DATABASE music_player;
USE music_player;

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
  PRIMARY KEY (`Id`),
  KEY `fk_Artista_Genero_idx` (`IdGenero`),
  CONSTRAINT `fk_Artista_Genero` FOREIGN KEY (`IdGenero`) REFERENCES `genero` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artista`
--

LOCK TABLES `artista` WRITE;
/*!40000 ALTER TABLE `artista` DISABLE KEYS */;
INSERT INTO `artista` VALUES (1,'Michael Jackson',1,'Rey del Pop','Estados Unidos','1958-08-29 00:00:00',2),(2,'Madonna',1,'Reina del Pop','Estados Unidos','1958-08-16 00:00:00',2),(3,'Elvis Presley',1,'El Rey del Rock','Estados Unidos','1935-01-08 00:00:00',1),(4,'Bob Marley',1,'Tuff Gong','Jamaica','1945-02-06 00:00:00',6),(5,'Beyoncé',1,'Queen Bey','Estados Unidos','1981-09-04 00:00:00',2),(6,'The Beatles',1,'The Fab Four','Reino Unido','1960-08-01 00:00:00',1),(7,'Miles Davis',1,'Prince of Darkness','Estados Unidos','1926-05-26 00:00:00',4),(8,'Ella Fitzgerald',1,'The First Lady of Song','Estados Unidos','1917-04-25 00:00:00',4),(9,'Carlos Santana',1,'El Rey de la Guitarra','Estados Unidos','1947-07-20 00:00:00',1),(10,'Frank Sinatra',1,'The Voice','Estados Unidos','1915-12-12 00:00:00',4),(11,'Queen',1,'Los campeones','Reino Unido','1970-06-27 00:00:00',1),(12,'Whitney Houston',1,'The Voice','Estados Unidos','1963-08-09 00:00:00',2),(13,'David Bowie',1,'Ziggy Stardust','Reino Unido','1947-01-08 00:00:00',1),(14,'Prince',1,'El Genio','Estados Unidos','1958-06-07 00:00:00',4),(15,'Stevie Wonder',1,'Little Stevie Wonder','Estados Unidos','1950-05-13 00:00:00',4),(16,'Aretha Franklin',1,'Queen of Soul','Estados Unidos','1942-03-25 00:00:00',4),(17,'Led Zeppelin',1,'Los Dioses del Rock','Reino Unido','1968-09-25 00:00:00',1),(18,'AC/DC',1,'Los Amos del Rock','Australia','1973-11-18 00:00:00',1),(19,'Nirvana',1,'Los Padres del Grunge','Estados Unidos','1987-01-14 00:00:00',1),(20,'Metallica',1,'Los Cuatro Jinetes','Estados Unidos','1981-10-28 00:00:00',1),(21,'U2',1,'Los Chicos de Dublín','Irlanda','1976-09-25 00:00:00',1),(22,'Rihanna',1,'Bad Gal RiRi','Barbados','1988-02-20 00:00:00',2),(23,'Eminem',1,'Slim Shady','Estados Unidos','1972-10-17 00:00:00',3),(24,'Jay-Z',1,'Hova','Estados Unidos','1969-12-04 00:00:00',3),(25,'Kanye West',1,'Yeezy','Estados Unidos','1977-06-08 00:00:00',3),(26,'Drake',1,'Champagne Papi','Canadá','1986-10-24 00:00:00',3),(27,'Taylor Swift',1,'T-Swift','Estados Unidos','1989-12-13 00:00:00',2),(28,'Ed Sheeran',1,'Ginger Jesus','Reino Unido','1991-02-17 00:00:00',2),(29,'Adele',1,'The Queen of Soul','Reino Unido','1988-05-05 00:00:00',2),(30,'Shakira',1,'La Diosa del Pop Latino','Colombia','1977-02-02 00:00:00',9),(31,'Juanes',1,'El Diablo','Colombia','1972-08-09 00:00:00',9),(32,'Gloria Estefan',1,'Queen of Latin Pop','Estados Unidos','1957-09-01 00:00:00',9),(33,'Marc Anthony',1,'El Cantante','Estados Unidos','1968-09-16 00:00:00',9),(34,'Luis Miguel',1,'El Sol','México','1970-04-19 00:00:00',9),(35,'Bob Dylan',1,'The Voice of a Generation','Estados Unidos','1941-05-24 00:00:00',1),(36,'Johnny Cash',1,'The Man in Black','Estados Unidos','1932-02-26 00:00:00',1),(37,'Elton John',1,'Rocket Man','Reino Unido','1947-03-25 00:00:00',2),(38,'Sting',1,'The Police','Reino Unido','1951-10-02 00:00:00',1),(39,'Amy Winehouse',1,'Wino','Reino Unido','1983-09-14 00:00:00',2),(40,'Janis Joplin',1,'Pearl','Estados Unidos','1943-01-19 00:00:00',1),(41,'B.B. King',1,'King of the Blues','Estados Unidos','1925-09-16 00:00:00',5),(42,'Eric Clapton',1,'Slowhand','Reino Unido','1945-03-30 00:00:00',1),(43,'Jimi Hendrix',1,'Voodoo Child','Estados Unidos','1942-11-27 00:00:00',1),(44,'Santana',1,'El Mago de la Guitarra','Estados Unidos','1947-07-20 00:00:00',1),(45,'Juan Gabriel',1,'El Divo de Juárez','México','1950-01-07 00:00:00',9),(46,'Celia Cruz',1,'La Reina de la Salsa','Cuba','1925-10-21 00:00:00',8),(47,'Rubén Blades',1,'El Poeta de la Salsa','Panamá','1948-07-16 00:00:00',8),(48,'Héctor Lavoe',1,'El Cantante de los Cantantes','Puerto Rico','1946-09-30 00:00:00',8),(49,'Gloria Trevi',1,'La Diva de la Música Latina','México','1968-02-15 00:00:00',9),(50,'José José',1,'El Príncipe de la Canción','México','1948-02-17 00:00:00',9),(51,'Frank Sinatra',1,'The Voice','Estados Unidos','1915-12-12 00:00:00',2),(52,'Barbra Streisand',1,'Babs','Estados Unidos','1942-04-24 00:00:00',2),(53,'Michael Bublé',1,'Bublé','Canadá','1975-09-09 00:00:00',2),(54,'Alicia Keys',1,'The Voice','Estados Unidos','1981-01-25 00:00:00',4),(55,'John Legend',1,'Legend','Estados Unidos','1978-12-28 00:00:00',4),(56,'Bruno Mars',1,'Bru','Estados Unidos','1985-10-08 00:00:00',2),(57,'Billie Eilish',1,'Bad Guy','Estados Unidos','2001-12-18 00:00:00',2),(58,'Lana Del Rey',1,'Queen of Sadcore','Estados Unidos','1985-06-21 00:00:00',2),(59,'Ariana Grande',1,'Grande','Estados Unidos','1993-06-26 00:00:00',2),(60,'Dua Lipa',1,'Dua Lipa','Reino Unido','1995-08-22 00:00:00',2),(61,'Camila Cabello',0,'Cabello','Cuba','1997-03-03 00:00:00',2),(62,'Ricky Martin',0,'El Rey del Pop Latino','Puerto Rico','1971-12-24 00:00:00',9),(63,'Enrique Iglesias',0,'El Rey','España','1975-05-08 00:00:00',9),(64,'Jennifer Lopez',0,'J.Lo','Estados Unidos','1969-07-24 00:00:00',9),(65,'Selena Gomez',0,'Selena','Estados Unidos','1992-07-22 00:00:00',2),(66,'Justin Bieber',0,'Biebs','Canadá','1994-03-01 00:00:00',2),(67,'Shawn Mendes',0,'Mendes Army','Canadá','1998-08-08 00:00:00',2),(68,'Harry Styles',0,'Hazza','Reino Unido','1994-02-01 00:00:00',2),(69,'Taylor Swift',0,'T-Swift','Estados Unidos','1989-12-13 00:00:00',2);
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bitacora_usuario`
--

LOCK TABLES `bitacora_usuario` WRITE;
/*!40000 ALTER TABLE `bitacora_usuario` DISABLE KEYS */;
INSERT INTO `bitacora_usuario` VALUES (1,'Se agrego el usuario: Jorge Fabian.','Jorge@gmail.com','2023-05-28 16:28:42',1),(2,'Se agrego el usuario: Juan Gutierrez.','Juan@gmail.com','2023-05-28 16:28:42',2),(3,'Se agrego el usuario: Ana Rodriguez.','Ana@gmail.com','2023-05-28 16:28:42',3),(4,'Inicio de sesión exitoso del usuario: Jorge@gmail.com.','Jorge@gmail.com','2023-05-31 16:34:43',1),(5,'Ana Rodriguez a descendido a Usuario.','Ana@gmail.com','2023-06-01 09:32:54',3),(6,'Ana Rodrigueza ascendido a Usuario VIP.','Ana@gmail.com','2023-06-01 09:33:30',3);
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
  PRIMARY KEY (`Id`),
  KEY `fk_Musica_Artista` (`IdArtista`),
  KEY `fk_Musica_Genero` (`IdGenero`),
  KEY `fk_Musica_Usuario` (`IdUsuario`),
  CONSTRAINT `fk_Musica_Artista` FOREIGN KEY (`IdArtista`) REFERENCES `artista` (`Id`),
  CONSTRAINT `fk_Musica_Genero` FOREIGN KEY (`IdGenero`) REFERENCES `genero` (`Id`),
  CONSTRAINT `fk_Musica_Usuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cancion`
--

LOCK TABLES `cancion` WRITE;
/*!40000 ALTER TABLE `cancion` DISABLE KEYS */;
INSERT INTO `cancion` VALUES (1,'Thriller',0,1,'2023-05-31 19:36:40',2,1,'05:57'),(2,'Like a Virgin',0,2,'2023-05-31 19:36:40',2,1,'03:08'),(3,'Hound Dog',1,3,'2023-05-31 19:36:40',1,1,'02:15'),(4,'One Love',0,4,'2023-05-31 19:36:40',6,1,'02:51'),(5,'Single Ladies (Put a Ring on It)',1,5,'2023-05-31 19:36:40',2,1,'03:13'),(6,'Hey Jude',1,6,'2023-05-31 19:36:40',1,1,'07:11'),(7,'So What',1,7,'2023-05-31 19:36:40',4,1,'09:22'),(8,'Summertime',1,8,'2023-05-31 19:36:40',4,1,'04:57'),(9,'Smooth',1,9,'2023-05-31 19:36:40',1,1,'04:55'),(10,'My Way',1,10,'2023-05-31 19:36:40',4,1,'04:34'),(11,'Bohemian Rhapsody',1,11,'2023-05-31 19:36:40',1,1,'05:55'),(12,'I Will Always Love You',1,12,'2023-05-31 19:36:40',2,1,'04:31'),(13,'Heroes',1,13,'2023-05-31 19:36:40',1,1,'06:08'),(14,'Purple Rain',1,14,'2023-05-31 19:36:40',4,1,'08:42'),(15,'Superstition',1,15,'2023-05-31 19:36:40',4,1,'04:26'),(16,'Respect',1,16,'2023-05-31 19:36:40',4,1,'02:29'),(17,'Stairway to Heaven',0,17,'2023-05-31 19:36:40',1,1,'08:02'),(18,'Highway to Hell',0,18,'2023-05-31 19:36:40',1,1,'03:28'),(19,'Smells Like Teen Spirit',0,19,'2023-05-31 19:36:40',1,1,'05:01'),(20,'Enter Sandman',0,20,'2023-05-31 19:36:40',1,1,'05:29'),(21,'With or Without You',0,21,'2023-05-31 19:36:40',1,1,'04:56'),(22,'Umbrella',0,22,'2023-05-31 19:36:40',2,1,'04:35'),(23,'Lose Yourself',0,23,'2023-05-31 19:36:40',3,1,'05:26'),(24,'99 Problems',0,24,'2023-05-31 19:36:40',3,1,'03:55'),(25,'God\'s Plan',0,25,'2023-05-31 19:36:40',3,1,'03:18'),(26,'Blank Space',0,26,'2023-05-31 19:36:40',2,1,'03:51'),(27,'Shape of You',0,27,'2023-05-31 19:36:40',2,1,'03:54'),(28,'Rolling in the Deep',0,28,'2023-05-31 19:36:40',2,1,'03:48'),(29,'Waka Waka (This Time for Africa)',0,29,'2023-05-31 19:36:40',9,1,'03:21'),(30,'La Camisa Negra',0,30,'2023-05-31 19:36:40',9,1,'03:36'),(31,'Conga',0,31,'2023-05-31 19:36:40',9,1,'04:15'),(32,'Livin\' la Vida Loca',0,32,'2023-05-31 19:36:40',9,1,'04:03'),(33,'Por Debajo de la Mesa',0,33,'2023-05-31 19:36:40',9,1,'04:10'),(34,'Like a Rolling Stone',0,34,'2023-05-31 19:36:40',1,1,'06:13'),(35,'Ring of Fire',0,35,'2023-05-31 19:36:40',1,1,'02:37'),(36,'Your Song',0,36,'2023-05-31 19:36:40',2,1,'04:02'),(37,'Every Breath You Take',0,37,'2023-05-31 19:36:40',1,1,'04:13'),(38,'Rehab',0,38,'2023-05-31 19:36:40',2,1,'03:35'),(39,'Piece of My Heart',0,39,'2023-05-31 19:36:40',1,1,'04:14'),(40,'The Thrill Is Gone',0,40,'2023-05-31 19:36:40',5,1,'05:25'),(41,'Tears in Heaven',0,41,'2023-05-31 19:36:40',1,1,'04:36'),(42,'Purple Haze',0,42,'2023-05-31 19:36:40',1,1,'02:50'),(43,'Black Magic Woman',0,43,'2023-05-31 19:36:40',1,1,'03:17'),(44,'Querida',0,44,'2023-05-31 19:36:40',9,1,'04:39'),(45,'La Vida Es un Carnaval',0,45,'2023-05-31 19:36:40',8,1,'04:38'),(46,'Pedro Navaja',0,46,'2023-05-31 19:36:40',8,1,'07:26'),(47,'El Cantante',0,47,'2023-05-31 19:36:40',8,1,'10:22'),(48,'Culpable o No',0,48,'2023-05-31 19:36:40',9,1,'03:54'),(49,'La Incondicional',0,49,'2023-05-31 19:36:40',9,1,'04:27'),(50,'Like a Rolling Stone',0,50,'2023-05-31 19:36:40',1,1,'06:13'),(51,'Hotline Bling',0,51,'2023-05-31 19:36:40',3,1,'04:27'),(52,'Despacito',0,52,'2023-05-31 19:36:40',9,1,'03:49'),(53,'Sorry',0,53,'2023-05-31 19:36:40',2,1,'03:21'),(54,'Havana',0,54,'2023-05-31 19:36:40',2,1,'03:36'),(55,'Watermelon Sugar',0,55,'2023-05-31 19:36:40',2,1,'02:54'),(56,'Senorita',0,56,'2023-05-31 19:36:40',2,1,'03:11'),(57,'Someone Like You',0,57,'2023-05-31 19:36:40',2,1,'04:45'),(58,'Rolling in the Deep',0,58,'2023-05-31 19:36:40',2,1,'03:48'),(59,'La Tortura',0,59,'2023-05-31 19:36:40',9,1,'03:35'),(60,'El Triste',0,60,'2023-05-31 19:36:40',9,1,'03:59');
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
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genero`
--

LOCK TABLES `genero` WRITE;
/*!40000 ALTER TABLE `genero` DISABLE KEYS */;
INSERT INTO `genero` VALUES (1,'Rock',18),(2,'Pop',16),(3,'Hip Hop',4),(4,'Jazz',6),(5,'Blues',1),(6,'Reggae',1),(7,'Country',0),(8,'Folk',3),(9,'Salsa',11),(10,'Cumbia',0),(11,'Merengue',0),(12,'Bachata',0),(13,'R&B',0),(14,'Soul',0),(15,'Funk',0),(16,'Disco',0),(17,'Electrónica',0),(18,'House',0),(19,'Techno',0),(20,'Dance',0),(21,'Trap',0),(22,'Reggaeton',0),(23,'Gospel',0),(24,'Clásica',0),(25,'Ópera',0),(26,'Metal',0),(27,'Punk',0),(28,'Indie',0),(29,'Alternativo',0),(30,'Rap',0);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Jorge Fabian','Jorge@gmail.com','40bd001563085fc35165329ea1ff5c5ecbdbbeef',1),(2,'Juan Gutierrez','Juan@gmail.com','40bd001563085fc35165329ea1ff5c5ecbdbbeef',2),(3,'Ana Rodriguez','Ana@gmail.com','40bd001563085fc35165329ea1ff5c5ecbdbbeef',3);
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-01 10:33:19
