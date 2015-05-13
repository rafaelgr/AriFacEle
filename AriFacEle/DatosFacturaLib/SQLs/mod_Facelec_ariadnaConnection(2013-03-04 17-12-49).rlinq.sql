-- add column for field codclien_ariagro
ALTER TABLE `cliente` ADD COLUMN `codclien_ariagro` int NULL
;

UPDATE `cliente` SET `codclien_ariagro` = 0
;

ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

