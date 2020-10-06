/*Database: MYSQL*/

CREATE SCHEMA lubydatabase;

CREATE TABLE `lubydatabase`.`desenvolvedores` (
  `des_id` INT NOT NULL AUTO_INCREMENT,
  `des_nome` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`des_id`));

CREATE TABLE `lubydatabase`.`lancamentos` (
  `lan_id` INT NOT NULL AUTO_INCREMENT,
  `lan_inicio` DATETIME NOT NULL,
  `lan_fim` DATETIME NOT NULL,
  `lan_desenvolvedor` INT NOT NULL,
  PRIMARY KEY (`lan_id`),
  CONSTRAINT `des`
    FOREIGN KEY (`lan_desenvolvedor`)
    REFERENCES `lubydatabase`.`desenvolvedores` (`des_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

CREATE TABLE `lubydatabase`.`projetos` (
  `pro_id` INT NOT NULL AUTO_INCREMENT,
  `pro_nome` VARCHAR(45) NOT NULL,
  `pro_responsavel` INT NOT NULL,
  PRIMARY KEY (`pro_id`),
  CONSTRAINT `responsavel`
    FOREIGN KEY (`pro_responsavel`)
    REFERENCES `lubydatabase`.`desenvolvedores` (`des_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);
