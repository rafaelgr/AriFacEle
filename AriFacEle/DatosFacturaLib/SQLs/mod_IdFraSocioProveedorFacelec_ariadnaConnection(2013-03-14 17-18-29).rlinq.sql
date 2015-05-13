-- Column was read from database as: `codclien_ariagro` integer not null
-- modify column for field codclienAriagro
ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- Column was read from database as: `es_fra_cliente` integer not null
-- modify column for field esFraCliente
ALTER TABLE `factura` CHANGE COLUMN `es_fra_cliente` `es_fra_cliente` tinyint NOT NULL
;

-- add column for field letraIdFraProve
ALTER TABLE `factura` ADD COLUMN `letra_id_fra_prove` varchar(255) NULL
;

