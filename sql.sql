SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema BankBD
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema BankBD
-- -----------------------------------------------------
DROP DATABASE IF EXISTS BankBD;
CREATE DATABASE IF NOT EXISTS `BankBD` DEFAULT CHARACTER SET utf8 ;
USE `BankBD` ;

-- -----------------------------------------------------
-- Table `BankBD`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BankBD`.`Client` (
  `id` INT UNSIGNED NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `FirstName` VARCHAR(45) NOT NULL,
  `Patronymic` VARCHAR(45) NOT NULL,
  `PhoneNumber` VARCHAR(20) NOT NULL,
  `Address` VARCHAR(90) NOT NULL,
  `BankAccount` VARCHAR(20) NOT NULL,
  `SumAccount` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

INSERT Client VALUES (1,'Матвеев','Артём','Андреевич','+7(911)885-42-15','Новоселов Переулок,12,Санкт-Петербург','42176412000000007485', 15000),
(2,'Панов','Богдан','Даниилович','+7(900)067-45-78','П. Краснодарский,24,Санкт-Петербург','41577896000000004999', 100000),
(3,'Ткачев','Кирилл','Егорович','+7(914)071-74-56','Спартака Улица,31,Санкт-Петербург','51782044000000007778', 35478),
(4,'Савин','Савва','Тимофеевич','+7(914)071-77-45','Кирочная ул., 21, Санкт-Петербург','44127741000000007774', 78945),
(5,'Горлов','Иван','Егорович','+7(900)885-47-47','Конная ул., 58, Санкт-Петербург','51046895000000001445',345789);



-- -----------------------------------------------------
-- Table `BankBD`.`Department`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BankBD`.`Department` (
  `id` INT UNSIGNED NOT NULL,
  `Name` VARCHAR(90) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

INSERT Department VALUES (1, 'Кредитный отдел'), (2, 'Ипотечный отдел'), 
(3, 'Отдел по работе с клиентами'), (4, 'Отдел кассовых операций'); 

-- -----------------------------------------------------
-- Table `BankBD`.`Employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BankBD`.`Employee` (
  `id` INT UNSIGNED NOT NULL,
  `FirstName` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `Patronymic` VARCHAR(45) NOT NULL,
  `Department_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Employee_Department1_idx` (`Department_id` ASC) VISIBLE,
  CONSTRAINT `fk_Employee_Department1`
    FOREIGN KEY (`Department_id`)
    REFERENCES `BankBD`.`Department` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

INSERT Employee VALUES (1,'Баженов','Илья','Олегович', 1),(2,'Ковалева','Мария','Ивановна', 2),
(3,'Орлов','Денис','Кириллович', 3),(4,'Потапова','Ева','Ильинична', 4), 
(5,'Лобанов','Евгений','Львович', 1),(6,'Акимов','Адам','Максимович', 2);

-- -----------------------------------------------------
-- Table `BankBD`.`Contract`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BankBD`.`Contract` (
  `id` INT UNSIGNED NOT NULL,
  `Information` VARCHAR(255) NOT NULL,
  `StartDate` DATE NOT NULL,
  `EndDate` DATE NOT NULL,
  `EmployeeID` INT UNSIGNED NOT NULL,
  `Client_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Contract_Employee1_idx` (`EmployeeID` ASC) VISIBLE,
  INDEX `fk_Contract_Client1_idx` (`Client_id` ASC) VISIBLE,
  CONSTRAINT `fk_Contract_Employee1`
    FOREIGN KEY (`EmployeeID`)
    REFERENCES `BankBD`.`Employee` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Contract_Client1`
    FOREIGN KEY (`Client_id`)
    REFERENCES `BankBD`.`Client` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

INSERT Contract VALUES (1,'Дог. Кредит (1) - Матвеев Артём Андреевич','2023-05-22','2025-05-22',1,1),(2,'Дог. Ипотека (2) - Панов Богдан Даниилович','2023-05-06','2033-05-06',2,2),
(3,'Дог. Кредит (3) - Ткачев Кирилл Егорович','2023-05-22','2026-05-22',5,3),(4,'Дог. Ипотека (4) - Савин Савва Тимофеевич','2023-05-06','2038-05-06',6,4);

-- -----------------------------------------------------
-- Table `BankBD`.`Credit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BankBD`.`Credit` (
  `id` INT UNSIGNED NOT NULL,
  `Sum` INT NOT NULL,
  `Percent` INT UNSIGNED NOT NULL,
  `Contract_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `Contract_id`),
  INDEX `fk_Credit_Contract1_idx` (`Contract_id` ASC) VISIBLE,
  CONSTRAINT `fk_Credit_Contract1`
    FOREIGN KEY (`Contract_id`)
    REFERENCES `BankBD`.`Contract` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

INSERT Credit VALUES(1, 10000, 10, 1), (3, 30000, 5, 3);
-- -----------------------------------------------------
-- Table `BankBD`.`Mortgage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BankBD`.`Mortgage` (
  `id` INT UNSIGNED NOT NULL,
  `Sum` INT NOT NULL,
  `Percent` INT UNSIGNED NOT NULL,
  `Contract_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `Contract_id`),
  INDEX `fk_Mortgage_Contract1_idx` (`Contract_id` ASC) VISIBLE,
  CONSTRAINT `fk_Mortgage_Contract1`
    FOREIGN KEY (`Contract_id`)
    REFERENCES `BankBD`.`Contract` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

INSERT Mortgage VALUES(2, 5000000, 1, 2), (4, 10000000, 1, 4);
-- -----------------------------------------------------
-- Table `BankBD`.`Operation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BankBD`.`Operation` (
  `id` INT UNSIGNED NOT NULL,
  `Sum` INT UNSIGNED NOT NULL,
  `Recipient_ClientID` INT UNSIGNED NOT NULL,
  `Date` DATETIME NOT NULL,
  `Client_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Operation_Client1_idx` (`Client_id` ASC) VISIBLE,
  CONSTRAINT `fk_Operation_Client1`
    FOREIGN KEY (`Client_id`)
    REFERENCES `BankBD`.`Client` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

INSERT Operation VALUES(1, 1500, 2, '2023-05-06 14:47:12', 1);

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
