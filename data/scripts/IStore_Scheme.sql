-- MySQL Script generated by MySQL Workbench
-- Thu Oct 29 17:52:31 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema IStoreDB
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `IStoreDB` ;

-- -----------------------------------------------------
-- Schema IStoreDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `IStoreDB` DEFAULT CHARACTER SET utf8 ;
USE `IStoreDB` ;

-- -----------------------------------------------------
-- Table `IStoreDB`.`categories`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`categories` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`categories` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `parent_id` INT NULL DEFAULT NULL,
  `title` NVARCHAR(256) NOT NULL,
  `active` TINYINT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`products`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`products` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`products` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` NVARCHAR(256) NOT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `price` DOUBLE UNSIGNED NOT NULL,
  `image` TEXT NULL,
  `category_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_product_category_idx` (`category_id` ASC) VISIBLE,
  CONSTRAINT `fk_products_categories`
    FOREIGN KEY (`category_id`)
    REFERENCES `IStoreDB`.`categories` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`userroles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`userroles` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`userroles` (
  `id` INT NOT NULL,
  `title` NVARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`users` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `credentials` NVARCHAR(1024) NOT NULL,
  `email` NVARCHAR(512) NOT NULL,
  `passwordhash` NVARCHAR(256) NOT NULL,
  `birthday` NVARCHAR(512) NOT NULL,
  `comment` TEXT NULL DEFAULT NULL,
  `userrole_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_user_user_role1_idx` (`userrole_id` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  CONSTRAINT `fk_users_userroles`
    FOREIGN KEY (`userrole_id`)
    REFERENCES `IStoreDB`.`userroles` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE);


-- -----------------------------------------------------
-- Table `IStoreDB`.`comments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`comments` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`comments` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `parent_id` INT NULL DEFAULT NULL,
  `text` MEDIUMTEXT NOT NULL,
  `time` DATETIME NOT NULL,
  `user_id` INT NULL DEFAULT NULL,
  `product_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_comment_product_idx` (`product_id` ASC) VISIBLE,
  INDEX `fk_comment_user_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_comments_products`
    FOREIGN KEY (`product_id`)
    REFERENCES `IStoreDB`.`products` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_comments_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `IStoreDB`.`users` (`id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`log`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`log` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`log` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `time` DATETIME NOT NULL,
  `severity` NVARCHAR(50) NOT NULL,
  `logger` TINYTEXT NOT NULL,
  `message` MEDIUMTEXT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`suppliers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`suppliers` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`suppliers` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` NVARCHAR(256) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`supplier_products`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`supplier_products` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`supplier_products` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `supplier_id` INT NOT NULL,
  `product_id` INT NOT NULL,
  `deliverydays` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_supplier products_supplies1_idx` (`supplier_id` ASC) VISIBLE,
  INDEX `fk_supplier products_products1_idx` (`product_id` ASC) VISIBLE,
  UNIQUE INDEX `unique_product_supplier_combination` (`supplier_id` ASC, `product_id` ASC) VISIBLE,
  CONSTRAINT `fk_supplier_products_suppliers`
    FOREIGN KEY (`supplier_id`)
    REFERENCES `IStoreDB`.`suppliers` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_supplier_products_products`
    FOREIGN KEY (`product_id`)
    REFERENCES `IStoreDB`.`products` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`settings`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`settings` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`settings` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `settingkey` TEXT NOT NULL,
  `settingvalue` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`discounts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`discounts` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`discounts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `category_id` INT NOT NULL,
  `amountpercent` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_discounts_categories_idx` (`category_id` ASC) VISIBLE,
  UNIQUE INDEX `category_id_UNIQUE` (`category_id` ASC) VISIBLE,
  CONSTRAINT `fk_discounts_categories`
    FOREIGN KEY (`category_id`)
    REFERENCES `IStoreDB`.`categories` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`orders`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`orders` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`orders` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `address` TEXT NOT NULL,
  `paymenttype` NVARCHAR(128) NOT NULL,
  `total` DOUBLE NOT NULL DEFAULT 0,
  `status` NVARCHAR(128) NOT NULL,
  `orderdate` DATETIME NOT NULL,
  `deliverydate` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_order_details_users_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_order_details_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `IStoreDB`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `IStoreDB`.`order_items`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IStoreDB`.`order_items` ;

CREATE TABLE IF NOT EXISTS `IStoreDB`.`order_items` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `product_id` INT NOT NULL,
  `qty` INT NOT NULL,
  `order_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_order_items_products_idx` (`product_id` ASC) VISIBLE,
  INDEX `fk_odrer_items_order_details_idx` (`order_id` ASC) VISIBLE,
  CONSTRAINT `fk_order_items_products`
    FOREIGN KEY (`product_id`)
    REFERENCES `IStoreDB`.`products` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_odrer_items_orders`
    FOREIGN KEY (`order_id`)
    REFERENCES `IStoreDB`.`orders` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
