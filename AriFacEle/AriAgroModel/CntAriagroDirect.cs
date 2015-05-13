using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace AriAgroModel
{
    public static class CntAriagroDirect
    {
        public static MySqlConnection GetConnection()
        {
            // leer la cadena de conexion del config
            var connectionString = ConfigurationManager.ConnectionStrings["AriagroDirecto"].ConnectionString;
            // crear la conexion y devolverla.
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public static IList<Vcampo> GetVCampos(int codsocio)
        {
            IList<Vcampo> lcampos = new List<Vcampo>();
            if (codsocio == 0) return lcampos;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"
                        SELECT 
                        codcampo AS CODCAMPO,
                        rc.codsocio AS CODSOCIO, 
                        rs.nomsocio AS NOMSOCIO,
                        MID(rp.codpobla,1,2) AS PROVINCIA,
                        rpu.codsigpa AS MUNICIPIO,
                        rc.poligono AS POLIGONO,
                        rc.parcela AS PARCELA,
                        rc.recintos AS RECINTO,
                        rc.fecaltas AS FECHA_ALTA,
                        rc.fecbajas AS FECHA_BAJA,
                        rc.supsigpa AS SUPERFICIE,
                        v.nomvarie AS VARIEDAD,
                        rc.longitud AS LONGITUD,
                        rc.latitud AS LATITUD,
                        par.codparti AS CODPARTI,
                        par.nomparti AS NOMPARTI,
                        sit.codsitua AS CODSITUA,
                        sit.nomsitua AS NOMSITUA,
                        rc.nrocampo AS NROCAMPO
                        FROM rcampos AS rc
                        LEFT JOIN rsocios AS rs ON rs.codsocio = rc.codsocio
                        LEFT JOIN variedades AS v ON v.codvarie = rc.codvarie
                        LEFT JOIN rpartida AS rp ON rp.codparti = rc.codparti
                        LEFT JOIN rpueblos AS rpu ON rpu.codpobla = rp.codpobla
                        LEFT JOIN rpartida AS par ON par.codparti = rc.codparti
                        LEFT JOIN rsituacioncampo AS sit ON sit.codsitua = rc.codsitua
                        WHERE rc.codsocio = {0}
                        AND rc.fecbajas IS NULL;
                ";
                sql = String.Format(sql, codsocio);
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        lcampos.Add(GetVCampo(rdr));
                    }
                }
                conn.Close();
            }
            return lcampos;
        }
        public static Vcampo GetVCampo(MySqlDataReader rdr)
        {
            Vcampo campo = new Vcampo();
            campo.Codcampo = rdr.GetInt32("CODCAMPO");
            campo.Codsocio = rdr.GetInt32("CODSOCIO");
            campo.Nomsocio = rdr.GetString("NOMSOCIO");
            campo.Provincia = int.Parse(rdr.GetString("PROVINCIA"));
            campo.Municipio = rdr.GetInt32("MUNICIPIO");
            campo.Poligono = rdr.GetInt32("POLIGONO");
            campo.Parcela = rdr.GetInt32("PARCELA");
            campo.Recinto = rdr.GetInt32("RECINTO");
            campo.Fecalta = rdr.GetDateTime("FECHA_ALTA");
            if (!rdr.IsDBNull(rdr.GetOrdinal("FECHA_BAJA")))
                campo.Fecbaja = rdr.GetDateTime("FECHA_BAJA");
            campo.Supsigpa = rdr.GetDecimal("SUPERFICIE");
            campo.Nomvarie = rdr.GetString("VARIEDAD");
            if (!rdr.IsDBNull(rdr.GetOrdinal("LATITUD")))
                campo.Latitud = rdr.GetDecimal("LATITUD");
            if (!rdr.IsDBNull(rdr.GetOrdinal("LONGITUD")))
                campo.Longitud = rdr.GetDecimal("LONGITUD");
            if (!rdr.IsDBNull(rdr.GetOrdinal("CODPARTI")))
                campo.Codparti = rdr.GetInt32("CODPARTI");
            if (!rdr.IsDBNull(rdr.GetOrdinal("CODSITUA")))
                campo.Codsitua = rdr.GetInt32("CODSITUA");
            if (!rdr.IsDBNull(rdr.GetOrdinal("NOMPARTI")))
                campo.Nomparti = rdr.GetString("NOMPARTI");
            if (!rdr.IsDBNull(rdr.GetOrdinal("NOMSITUA")))
                campo.Nomsitua = rdr.GetString("NOMSITUA");
            if (!rdr.IsDBNull(rdr.GetOrdinal("NROCAMPO")))
                campo.NroCampo = rdr.GetInt32("NROCAMPO");
            return campo;
        }

        public static Vcampo GetVCampo(int codcampo)
        {
            Vcampo campo = null;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"
                        SELECT 
                        codcampo AS CODCAMPO,
                        rc.codsocio AS CODSOCIO, 
                        rs.nomsocio AS NOMSOCIO,
                        MID(rp.codpobla,1,2) AS PROVINCIA,
                        rpu.codsigpa AS MUNICIPIO,
                        rc.poligono AS POLIGONO,
                        rc.parcela AS PARCELA,
                        rc.recintos AS RECINTO,
                        rc.fecaltas AS FECHA_ALTA,
                        rc.fecbajas AS FECHA_BAJA,
                        rc.supsigpa AS SUPERFICIE,
                        v.nomvarie AS VARIEDAD,
                        rc.longitud AS LONGITUD,
                        rc.latitud AS LATITUD,
                        par.codparti AS CODPARTI,
                        par.nomparti AS NOMPARTI,
                        sit.codsitua AS CODSITUA,
                        sit.nomsitua AS NOMSITUA,
                        rc.nrocampo AS NROCAMPO
                        FROM rcampos AS rc
                        LEFT JOIN rsocios AS rs ON rs.codsocio = rc.codsocio
                        LEFT JOIN variedades AS v ON v.codvarie = rc.codvarie
                        LEFT JOIN rpartida AS rp ON rp.codparti = rc.codparti
                        LEFT JOIN rpueblos AS rpu ON rpu.codpobla = rp.codpobla
                        LEFT JOIN rpartida AS par ON par.codparti = rc.codparti
                        LEFT JOIN rsituacioncampo AS sit ON sit.codsitua = rc.codsitua
                        WHERE rc.codcampo = {0};
                ";
                sql = String.Format(sql, codcampo);
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    campo = GetVCampo(rdr);
                }
                conn.Close();
            }
            return campo;
        }
    }
}
