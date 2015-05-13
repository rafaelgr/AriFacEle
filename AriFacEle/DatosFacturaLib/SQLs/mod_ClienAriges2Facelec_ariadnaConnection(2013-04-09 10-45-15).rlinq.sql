-- Column was read from database as: `codclien_ariagro` integer not null
-- modify column for field codclienAriagro
ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- add column for field codClienAriges2
ALTER TABLE `cliente` ADD COLUMN `cod_clien_ariges2` int NULL
;

UPDATE `cliente` SET `cod_clien_ariges2` = 0
;

ALTER TABLE `cliente` CHANGE COLUMN `cod_clien_ariges2` `cod_clien_ariges2` int NOT NULL
;

-- Column was read from database as: `cod_socio_ariagro` integer not null
-- modify column for field codSocioAriagro
ALTER TABLE `cliente` CHANGE COLUMN `cod_socio_ariagro` `cod_socio_ariagro` int NOT NULL
;

