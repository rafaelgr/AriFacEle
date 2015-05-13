-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- add column for field descripcion
ALTER TABLE `sistema` ADD COLUMN `descripcion` varchar(255) NULL
;

