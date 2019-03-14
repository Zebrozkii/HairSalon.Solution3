-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 14, 2019 at 07:03 PM
-- Server version: 5.7.23
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jimmy_zebroski`
--
CREATE DATABASE IF NOT EXISTS `jimmy_zebroski` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `jimmy_zebroski`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `clients_specialty`
--

CREATE TABLE `clients_specialty` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialty`
--

CREATE TABLE `specialty` (
  `id` int(11) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialty`
--

INSERT INTO `specialty` (`id`, `specialty`) VALUES
(7, 'jimmy'),
(8, 'Connor'),
(9, 'Connor');

-- --------------------------------------------------------

--
-- Table structure for table `stylist`
--

CREATE TABLE `stylist` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylist`
--

INSERT INTO `stylist` (`id`, `name`) VALUES
(119, 'Jimmy');

-- --------------------------------------------------------

--
-- Table structure for table `stylist_clients`
--

CREATE TABLE `stylist_clients` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `clients_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `stylist_specialty`
--

CREATE TABLE `stylist_specialty` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylist_specialty`
--

INSERT INTO `stylist_specialty` (`id`, `stylist_id`, `specialty_id`) VALUES
(2, 29, 5),
(3, 39, 6),
(4, 74, 5),
(5, 75, 6),
(6, 79, 10),
(7, 78, 11),
(8, 0, 1),
(9, 0, 1),
(10, 0, 1),
(11, 0, 1),
(12, 0, 1),
(13, 0, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `clients_specialty`
--
ALTER TABLE `clients_specialty`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialty`
--
ALTER TABLE `specialty`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylist`
--
ALTER TABLE `stylist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylist_clients`
--
ALTER TABLE `stylist_clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylist_specialty`
--
ALTER TABLE `stylist_specialty`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `clients_specialty`
--
ALTER TABLE `clients_specialty`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `specialty`
--
ALTER TABLE `specialty`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `stylist`
--
ALTER TABLE `stylist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=120;

--
-- AUTO_INCREMENT for table `stylist_clients`
--
ALTER TABLE `stylist_clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stylist_specialty`
--
ALTER TABLE `stylist_specialty`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
