-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 21, 2019 at 01:13 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `powershare`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sproc_AddUser` (OUT `userID` INT, IN `firstName` VARCHAR(50), IN `userName` VARCHAR(45), IN `lastName` VARCHAR(50), IN `emailAddress` VARCHAR(50), IN `password` VARCHAR(100), IN `salt` VARCHAR(100))  BEGIN
INSERT INTO User (`firstName`,`userName`, `lastName`,
 `emailAddress`,`password`, `salt`)
 VALUES (`firstName`,`userName`, `lastName`,
 `emailAddress`,`password`, `salt`);
     SET userID = last_insert_id();
End$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sproc_UserByID` (IN `userID` INT)  BEGIN
Select * from user
Where user.userID=userID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sproc_UserGetAll` ()  BEGIN
select * from user;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sproc_UserGetByUserName` (IN `userName` VARCHAR(128))  BEGIN
SELECT * FROM User
WHERE User.userName = userName;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `location`
--

CREATE TABLE `location` (
  `userID` int(20) NOT NULL,
  `longitude` double NOT NULL,
  `latitude` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_bin;

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `isAnAdmin` tinyint(1) NOT NULL,
  `userID` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_bin;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userID` int(20) NOT NULL,
  `firstName` varchar(20) COLLATE utf32_bin NOT NULL,
  `userName` varchar(20) COLLATE utf32_bin DEFAULT NULL,
  `lastName` varchar(20) COLLATE utf32_bin NOT NULL,
  `emailAddress` varchar(30) COLLATE utf32_bin NOT NULL,
  `phoneNumber` bigint(10) NOT NULL,
  `karmaPoints` int(10) NOT NULL,
  `password` varchar(150) COLLATE utf32_bin NOT NULL,
  `salt` varchar(100) COLLATE utf32_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_bin;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userID`, `firstName`, `userName`, `lastName`, `emailAddress`, `phoneNumber`, `karmaPoints`, `password`, `salt`) VALUES
(1, 'Kishor', ' 23r', 'Simkhada', 'test@t.com', 2082405833, 5, 'bhjhcdjhgj647', 's'),
(2, 'a', 'a', 'a', 'a', 0, 0, 'UwSJuGriYzIPrz9/vl0w', '27nhcIQ79taRFp8nq5X/YA0hMJP7Q/chX9Ll37kCXC9Hj'),
(3, 'b', 'b', 'b', 'b', 0, 0, 'DfO3q6HehbbUaBDIiP5m', '918Vdak1EGNQziVT9YhGJfyqdIlbKGapdOCeGypyj32VA'),
(4, 'alan', 'pokhalan', 'pokhrel', 'test@t.com', 0, 0, 'U+PtQydjihFbLQrMoQdl', 'TiqQiQtdvwGf7ok6nRjTLaouRkxGiMwoWNoah037mKelx'),
(5, 'test', 'test', 'test', 'test@t.com', 0, 0, 'DQycNPxprUkRsliKngpt', 'wWqm97JAXmxU/k5NSQJEnc8U7k1gudqISFQ2NLFujuDo+'),
(6, 'hack', 'hack', 'hack', 'hack', 0, 0, 'TlCmlqXCheRNCZdVUKNNA3N7e+JDNqcjNLEkO1qLOsRH+IR+Oxf+WMmDa4kN3tu8', 'xzMWM/zTka5Imx7cfJSasuI4HdeGSjxK/4e+unYVkTl87'),
(7, 't', 't', 't', 't', 0, 0, '2OpNRykXzRZyis0NjPw27nqEculfryS/QCorg9pSow1Yma/5mnNjH79QouAtv0Dn', 'Vl5E8745CgemUGNZ7k2ZqykQPC3KqqYPzhsmIRb/7KslVN7yuB');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userID` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
