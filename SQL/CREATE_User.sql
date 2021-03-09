CREATE TABLE `User` (
  `User_ID` int NOT NULL AUTO_INCREMENT,
  `First_Name` varchar(45) NOT NULL,
  `Last_Name` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `User_Name` varchar(45) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Is_locked` tinyint NOT NULL DEFAULT '0',
  `Failed_Attempts` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`User_ID`),
  UNIQUE KEY `User_Name_UNIQUE` (`User_Name`)
) 