-- Column was read from database as: `es_fra_cliente` tinyint not null
-- modify column for field esFraCliente
ALTER TABLE `factura` CHANGE COLUMN `es_fra_cliente` `es_fra_cliente` bit NOT NULL
;

