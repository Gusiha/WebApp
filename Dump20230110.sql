-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: lab1
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `apartment`
--

DROP TABLE IF EXISTS `apartment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `apartment` (
  `id` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apartment`
--

LOCK TABLES `apartment` WRITE;
/*!40000 ALTER TABLE `apartment` DISABLE KEYS */;
INSERT INTO `apartment` VALUES (9),(10),(12),(13);
/*!40000 ALTER TABLE `apartment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `money`
--

DROP TABLE IF EXISTS `money`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `money` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ap_id` int NOT NULL,
  `saldo` decimal(10,0) NOT NULL,
  `charges` decimal(10,0) NOT NULL,
  `payments` decimal(10,0) NOT NULL,
  `remaining` decimal(10,0) NOT NULL,
  `month_id` int NOT NULL,
  `year` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Money_fk0` (`ap_id`),
  KEY `Money_fk1` (`month_id`),
  CONSTRAINT `Money_fk0` FOREIGN KEY (`ap_id`) REFERENCES `apartment` (`id`),
  CONSTRAINT `Money_fk1` FOREIGN KEY (`month_id`) REFERENCES `time` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `money`
--

LOCK TABLES `money` WRITE;
/*!40000 ALTER TABLE `money` DISABLE KEYS */;
INSERT INTO `money` VALUES (6,10,7000,8000,6666,3334,1,2022),(10,13,7777,7777,7777,7777,1,2023),(14,10,0,5000,6000,1334,2,2022),(15,10,2000,6500,5500,16334,3,2022),(16,9,3000,2000,2000,3000,1,2022),(17,10,3,4844,4844,7837,12,2022),(18,10,4540,4500,4500,18874,4,2022),(19,10,4540,4500,3000,20374,5,2022),(20,10,4540,4500,10000,14874,6,2022),(21,10,4540,4500,4500,14874,7,2022),(22,10,4540,4500,4500,14874,8,2022),(23,10,4540,2000,4500,12374,9,2022),(24,10,4540,4500,4500,12374,10,2022),(25,10,4540,4500,4500,12374,11,2022),(26,12,2500,2000,2000,2500,1,2022),(27,12,0,5000,6000,-1000,2,2022),(28,9,0,5000,6000,-1000,2,2022);
/*!40000 ALTER TABLE `money` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `time`
--

DROP TABLE IF EXISTS `time`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `time` (
  `id` int NOT NULL AUTO_INCREMENT,
  `month_name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `month_name` (`month_name`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `time`
--

LOCK TABLES `time` WRITE;
/*!40000 ALTER TABLE `time` DISABLE KEYS */;
INSERT INTO `time` VALUES (4,'April'),(8,'August'),(12,'December'),(2,'February'),(1,'January'),(7,'July'),(6,'June'),(3,'March'),(5,'May'),(11,'November'),(10,'October'),(9,'September');
/*!40000 ALTER TABLE `time` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-10 15:31:17
