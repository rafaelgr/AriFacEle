using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de CntArigesSoc
/// </summary>
public static class CntArigesSoc
{
    public static MySqlConnection GetConnection()
    {
        // leer la cadena de conexion del config
        var connectionString = ConfigurationManager.ConnectionStrings["ArigesSoc"].ConnectionString;
        // crear la conexion y devolverla.
        MySqlConnection conn = new MySqlConnection(connectionString);
        return conn;
    }

    public static Asociado GetAsociado(MySqlDataReader rdr)
    {
        Asociado asociado = new Asociado();
        asociado.IdAsoc = rdr.GetInt32("IDASOC");
        asociado.Nif = rdr.GetString("NIF");
        if (!rdr.IsDBNull(rdr.GetOrdinal("NOMBRE")))
            asociado.Nombre = rdr.GetString("NOMBRE");
        if (!rdr.IsDBNull(rdr.GetOrdinal("APELLIDO1")))
            asociado.Apellido1 = rdr.GetString("APELLIDO1");
        if (!rdr.IsDBNull(rdr.GetOrdinal("APELLIDO2")))
            asociado.Apellido2 = rdr.GetString("APELLIDO2");
        if (!rdr.IsDBNull(rdr.GetOrdinal("DIRECCION")))
            asociado.Direccion = rdr.GetString("DIRECCION");
        if (!rdr.IsDBNull(rdr.GetOrdinal("CODPOSTAL")))
            asociado.CodPostal = rdr.GetString("CODPOSTAL");
        if (!rdr.IsDBNull(rdr.GetOrdinal("POBLACION")))
            asociado.Poblacion = rdr.GetString("POBLACION");
        if (!rdr.IsDBNull(rdr.GetOrdinal("PROVINCIA")))
            asociado.Provincia = rdr.GetString("PROVINCIA");
        if (!rdr.IsDBNull(rdr.GetOrdinal("FECHA_NACIMIENTO")))
            asociado.FechaNacimiento = rdr.GetDateTime("FECHA_NACIMIENTO");
        if (!rdr.IsDBNull(rdr.GetOrdinal("TELEFONO1")))
            asociado.Telefono1 = rdr.GetString("TELEFONO1");
        if (!rdr.IsDBNull(rdr.GetOrdinal("TELEFONO2")))
            asociado.Telefono2 = rdr.GetString("TELEFONO2");
        if (!rdr.IsDBNull(rdr.GetOrdinal("MOVIL")))
            asociado.Movil = rdr.GetString("MOVIL");
        if (!rdr.IsDBNull(rdr.GetOrdinal("MAIL")))
            asociado.Mail = rdr.GetString("MAIL");
        if (!rdr.IsDBNull(rdr.GetOrdinal("NOMLARGO")))
            asociado.NomLargo = rdr.GetString("NOMLARGO");
        if (!rdr.IsDBNull(rdr.GetOrdinal("IBAN")))
            asociado.Iban = rdr.GetString("IBAN");
        if (!rdr.IsDBNull(rdr.GetOrdinal("ENTIDAD")))
            asociado.Entidad = rdr.GetString("ENTIDAD");
        if (!rdr.IsDBNull(rdr.GetOrdinal("SUCURSAL")))
            asociado.Sucursal = rdr.GetString("SUCURSAL");
        if (!rdr.IsDBNull(rdr.GetOrdinal("DC")))
            asociado.Dc = rdr.GetString("DC");
        if (!rdr.IsDBNull(rdr.GetOrdinal("NUMCC")))
            asociado.Numcc = rdr.GetString("NUMCC");
        return asociado;
    }

    public static Asociado GetAsociado(int idasoc)
    {
        Asociado asociado = null;
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            string sql = @"
                        SELECT
                        IdAsoc AS IDASOC,
                        NIF AS NIF,
                        Nombre AS NOMBRE,
                        Apellido1 AS APELLIDO1,
                        Apellido2 AS APELLIDO2,
                        NomLargo as NOMLARGO,
                        Direccion AS DIRECCION,
                        Poblacion AS POBLACION,
                        Provincia AS PROVINCIA,
                        CodPostal AS CODPOSTAL,
                        FechaNac AS FECHA_NACIMIENTO,
                        Telefono1 AS TELEFONO1,
                        Telefono2 AS TELEFONO2,
                        Movil AS MOVIL,
                        Mail AS MAIL,
                        iban AS IBAN,
                        Entidad AS ENTIDAD,
                        Sucursal AS SUCURSAL,
                        Dc AS DC,
                        NUmCC AS NUMCC
                        FROM asociados
                        WHERE IdAsoc = {0};
                ";
            sql = String.Format(sql, idasoc);
            cmd.CommandText = sql;
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                asociado = GetAsociado(rdr);
            }
            conn.Close();
        }
        return asociado;
    }

}