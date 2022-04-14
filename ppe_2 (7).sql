-- Adminer 4.7.1 MySQL dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOM` varchar(20) DEFAULT NULL,
  `PRENOM` varchar(20) DEFAULT NULL,
  `ID_LOGIN` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `LOGIN_RH` (`ID_LOGIN`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `admin` (`ID`, `NOM`, `PRENOM`, `ID_LOGIN`) VALUES
(1,	'Nook',	'Tom',	5),
(2,	'Morand',	'Nicolas',	6);

DROP TABLE IF EXISTS `login`;
CREATE TABLE `login` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ID_LOGIN` int(11) DEFAULT NULL,
  `NOM_UTILISATEUR` varchar(15) DEFAULT NULL,
  `MOT_DE_PASSE` varchar(50) DEFAULT NULL,
  `ID_STATUT` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID_LOGIN` (`ID_LOGIN`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `login` (`ID`, `ID_LOGIN`, `NOM_UTILISATEUR`, `MOT_DE_PASSE`, `ID_STATUT`) VALUES
(1,	1,	'a',	'b',	1),
(2,	2,	'CF',	'cloclo',	1),
(5,	5,	'TNook',	'Tom.Nook',	2);

DROP TABLE IF EXISTS `medecin`;
CREATE TABLE `medecin` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOM` varchar(15) DEFAULT NULL,
  `PRENOM` varchar(15) DEFAULT NULL,
  `ADRESSE` varchar(100) DEFAULT NULL,
  `TELEPHONE` varchar(10) DEFAULT NULL,
  `ID_SPECIALITE` int(11) DEFAULT NULL,
  `POINTS_UTILISATEUR` int(11) DEFAULT NULL,
  `NB_VISITE` int(11) DEFAULT NULL,
  `ID_LOGIN` int(11) DEFAULT NULL,
  `ID_REGION` int(11) DEFAULT NULL,
  `DATE_ARRIVEE` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID_SPECIALITE` (`ID_SPECIALITE`),
  KEY `ID_REGION` (`ID_REGION`),
  KEY `ID_LOGIN` (`ID_LOGIN`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `medecin` (`ID`, `NOM`, `PRENOM`, `ADRESSE`, `TELEPHONE`, `ID_SPECIALITE`, `POINTS_UTILISATEUR`, `NB_VISITE`, `ID_LOGIN`, `ID_REGION`, `DATE_ARRIVEE`) VALUES
(1,	'Gateau',	'Pepito',	'Avenue des champs',	'0123456789',	1,	28,	17,	1,	4,	'2010-08-14'),
(2,	'Faustus',	'Claude',	'Rue du paradis',	'0663370152',	1,	57,	38,	2,	11,	'2014-06-17');

DROP TABLE IF EXISTS `region`;
CREATE TABLE `region` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOM` varchar(50) DEFAULT NULL,
  `NB_PLACE` int(11) DEFAULT NULL,
  `NB_PLACE_DISPO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `region` (`ID`, `NOM`, `NB_PLACE`, `NB_PLACE_DISPO`) VALUES
(4,	'Pays de la Loire',	60,	-1),
(2,	'Bretagne',	5,	0),
(3,	'Normandie',	8,	1),
(5,	'Île-de-France',	8,	-9),
(6,	'Hauts-de-France',	1,	-4),
(7,	'Grand Est',	4,	-4),
(8,	'Centre-Val de Loire',	5,	4),
(9,	'Bourgogne-Franche-Comté',	4,	-1),
(10,	'Nouvelle-Aquitaine',	8,	3),
(11,	'Mayotte',	8,	2),
(12,	'Occitanie',	5,	1),
(13,	'La Réunion',	4,	2),
(14,	'Guyane',	4,	1),
(15,	'Corse',	7,	2),
(16,	'Martinique',	7,	5),
(17,	'Guadeloupe',	8,	5),
(1,	'Auvergne-Rhône-Alpes',	10,	5);

DROP TABLE IF EXISTS `specialite`;
CREATE TABLE `specialite` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOM` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `specialite` (`ID`, `NOM`) VALUES
(1,	'Allergologie'),
(2,	'Cardiologie'),
(3,	'Gastro-entérologie'),
(4,	'Chirurgie'),
(5,	'Gynecologie'),
(6,	'Hematologie'),
(7,	'Immunologie'),
(8,	'Neurologie'),
(9,	'Pediatrie'),
(10,	'Psychiatrie'),
(11,	'Andrologie');

DROP TABLE IF EXISTS `statut`;
CREATE TABLE `statut` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TITRE` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `statut` (`ID`, `TITRE`) VALUES
(1,	'Medecin'),
(2,	'RH');

DROP TABLE IF EXISTS `voeux`;
CREATE TABLE `voeux` (
  `ID_MEDECIN` int(11) DEFAULT NULL,
  `ID_REGION` int(11) DEFAULT NULL,
  `ORDRE_PRIORITE` int(11) DEFAULT NULL,
  KEY `ID_REGION` (`ID_REGION`),
  KEY `ID_MEDECIN` (`ID_MEDECIN`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `voeux` (`ID_MEDECIN`, `ID_REGION`, `ORDRE_PRIORITE`) VALUES
(1,	7,	1),
(1,	8,	2),
(1,	14,	3),
(2,	3,	3),
(2,	2,	2),
(2,	1,	1);

-- 2020-06-16 22:50:18
