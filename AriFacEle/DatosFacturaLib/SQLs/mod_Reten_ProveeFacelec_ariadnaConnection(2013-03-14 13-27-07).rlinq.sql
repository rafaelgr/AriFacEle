-- Column was read from database as: `codclien_ariagro` integer not null
-- modify column for field codclienAriagro
ALTER TABLE `cliente` CHANGE COLUMN `codclien_ariagro` `codclien_ariagro` int NOT NULL
;

-- Column was read from database as: `codclien__arigasol` integer not null
-- modify column for field codclien_Arigasol
ALTER TABLE `cliente` CHANGE COLUMN `codclien__arigasol` `codclien__arigasol` int NOT NULL
;

-- add column for field tieneFacturaPROV
ALTER TABLE `cliente` ADD COLUMN `tiene_factura_p_r_o_v` tinyint NULL
;

UPDATE `cliente` SET `tiene_factura_p_r_o_v` = 0
;

ALTER TABLE `cliente` CHANGE COLUMN `tiene_factura_p_r_o_v` `tiene_factura_p_r_o_v` tinyint NOT NULL
;

-- add column for field esFraCliente
ALTER TABLE `factura` ADD COLUMN `es_fra_cliente` int NULL
;

UPDATE `factura` SET `es_fra_cliente` = 0
;

ALTER TABLE `factura` CHANGE COLUMN `es_fra_cliente` `es_fra_cliente` int NOT NULL
;

-- add column for field impRetencion
ALTER TABLE `factura` ADD COLUMN `imp_retencion` numeric(20,10) NULL
;

UPDATE `factura` SET `imp_retencion` = 0
;

ALTER TABLE `factura` CHANGE COLUMN `imp_retencion` `imp_retencion` numeric(20,10) NOT NULL
;

-- dropping unknown column `socio`
ALTER TABLE `factura` DROP COLUMN `socio`
;

