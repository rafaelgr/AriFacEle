using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de CntAriges
/// </summary>
public static class CntAriges
{
    public static MySqlConnection GetConnection()
    {
        // leer la cadena de conexion del config
        var connectionString = ConfigurationManager.ConnectionStrings["ArigesWeb"].ConnectionString;
        // crear la conexion y devolverla.
        MySqlConnection conn = new MySqlConnection(connectionString);
        return conn;
    }

    public static int GetNumConta()
    {
        int numconta = 0;
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            string sql = @"SELECT numconta FROM spara1";
            cmd.CommandText = sql;
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                numconta = rdr.GetInt32("numconta"); ;
            }
            conn.Close();
        }
        return numconta;
    }

    public static Articulo GetArticulo(MySqlDataReader rdr)
    {
        Articulo a = new Articulo();
        a.CodArtic = rdr.GetString("CODARTIC");
        a.NomArtic = rdr.GetString("NOMARTIC");
        a.PVP = rdr.GetDecimal("PVP");
        return a;
    }


    public static IList<Articulo> GetArticulosWeb()
    {
        IList<Articulo> la = new List<Articulo>();
        // primero obtener la contabilidad de la que sacar
        // el IVA
        int numconta = GetNumConta();
        if (numconta == 0) return la;
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            string sql = @"
                SELECT
                a.codartic AS CODARTIC,
                a.nomartic AS NOMARTIC,
                a.preciove AS PRECIOVE,
                ti.porceiva AS PORCEIVA,
                ROUND(a.preciove + ((a.preciove * ti.porceiva) / 100),2) AS PVP
                FROM sartic AS a
                LEFT JOIN conta{0}.tiposiva AS ti ON ti.codigiva=a.codigiva
                WHERE oftweb = 1;
                ";
            sql = String.Format(sql, numconta);
            cmd.CommandText = sql;
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    la.Add(GetArticulo(rdr));
                }
            }
            conn.Close();
        }
        return la;
    }
}