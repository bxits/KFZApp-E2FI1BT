-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 01. Feb 2019 um 08:44
-- Server-Version: 10.1.21-MariaDB
-- PHP-Version: 7.0.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `kfzka`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `kfz`
--

CREATE TABLE `kfz` (
  `idkfz` int(11) NOT NULL,
  `FahrgestellNr` text,
  `Kennzeichen` text,
  `Leistung` int(11) DEFAULT NULL,
  `Typ` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `kfz`
--

INSERT INTO `kfz` (`idkfz`, `FahrgestellNr`, `Kennzeichen`, `Leistung`, `Typ`) VALUES
(1, '198231729831', 'S-KU-253', 120, 'Limousine'),
(2, '34535435', 'KA-FA-765', 75, 'Cabrio'),
(3, '2345235435', 'WN-ZU-876', 100, 'Limusine');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `kfz`
--
ALTER TABLE `kfz`
  ADD PRIMARY KEY (`idkfz`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `kfz`
--
ALTER TABLE `kfz`
  MODIFY `idkfz` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
