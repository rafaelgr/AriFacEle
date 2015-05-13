-- DatosFacturaLib.Firma
CREATE TABLE `firma` (
    `tsa_user` varchar(255) NULL,           -- tsaUser
    `tsa_url` varchar(255) NULL,            -- tsaUrl
    `tsa_pass` varchar(255) NULL,           -- tsaPass
    `posicion_y0` INTEGER NULL,             -- posicionY0
    `posicion_y_y` INTEGER NULL,            -- posicionYY
    `posicion_x0` INTEGER NULL,             -- posicionX0
    `posicion_x_x` INTEGER NULL,            -- posicionXX
    `motivo` varchar(255) NULL,             -- motivo
    `lugar` varchar(255) NULL,              -- lugar
    `logo_path` varchar(255) NULL,          -- logoPath
    `id_firma` INTEGER AUTO_INCREMENT NOT NULL, -- idFirma
    `certificado_path` varchar(255) NULL,   -- certificadoPath
    `certificado_pass` varchar(255) NULL,   -- certificadoPass
    CONSTRAINT `pk_firma` PRIMARY KEY (`id_firma`)
) ENGINE = InnoDB;

