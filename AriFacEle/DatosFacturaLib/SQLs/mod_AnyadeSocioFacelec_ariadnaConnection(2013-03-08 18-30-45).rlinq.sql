-- Column was read from database as: `codclien_ariagro` integer not null
-- modify column for field codclienAriagro
ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- add column for field socio
ALTER TABLE `factura` ADD COLUMN `socio` smallint NULL
;

