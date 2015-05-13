ALTER TABLE `cliente` DROP FOREIGN KEY `ref_cliente_empresa`
;

-- Column was read from database as: `codclien_ariagro` integer not null
-- modify column for field codclien_ariagro
ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- add column for field empresa
ALTER TABLE `cliente` ADD COLUMN `id_empresa2` INTEGER NULL
;

ALTER TABLE `cliente` ADD CONSTRAINT `ref_cliente_empresa` FOREIGN KEY `ref_cliente_empresa` (`id_empresa2`) REFERENCES `empresa` (`id_empresa`)
;

-- Index 'idx_cliente_id_empresa2' was not detected in the database. It will be created
ALTER TABLE `cliente` ADD INDEX `idx_cliente_id_empresa2`(`id_empresa2`)
;

