ALTER TABLE `factura` DROP FOREIGN KEY `ref_factura_sistema`
;

-- Index 'idx_factura_sistema_id' was detected in the database but with a different configuration. It will be recreated
ALTER TABLE `factura` DROP INDEX `idx_factura_sistema_id`
;

-- Column was read from database as: `codclien_ariagro` integer not null
-- modify column for field codclienAriagro
ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- Column was read from database as: `sistema_id` integer null
-- modify column for field sistema
UPDATE `factura`
   SET `sistema_id` = 0
 WHERE `sistema_id` IS NULL
;

ALTER TABLE `factura` CHANGE COLUMN `sistema_id` `sistema_id` integer NOT NULL
;

ALTER TABLE `factura` ADD CONSTRAINT `ref_factura_sistema` FOREIGN KEY `ref_factura_sistema` (`sistema_id`) REFERENCES `sistema` (`sistema_id`)
;

-- Index 'idx_factura_sistema_id' was detected in the database but with a different configuration. It will be recreated
ALTER TABLE `factura` ADD INDEX `idx_factura_sistema_id`(`sistema_id`)
;

