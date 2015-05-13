-- Column was read from database as: `codclien_ariagro` integer not null
-- modify column for field codclienAriagro
ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- add column for field impGastosAFo
ALTER TABLE `factura` ADD COLUMN `imp_gastos_a_fo` numeric(20,10) NULL
;

UPDATE `factura` SET `imp_gastos_a_fo` = 0
;

ALTER TABLE `factura` CHANGE COLUMN `imp_gastos_a_fo` `imp_gastos_a_fo` numeric(20,10) NOT NULL
;

ALTER TABLE `cliente` ADD CONSTRAINT `ref_cliente_empresa` FOREIGN KEY `ref_cliente_empresa` (`id_empresa`) REFERENCES `empresa` (`id_empresa`)
;

