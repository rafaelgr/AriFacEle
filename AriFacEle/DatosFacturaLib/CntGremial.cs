using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatosFacturaLib
{
    public static class CntGremial
    {

        public static MySqlConnection GetConnectionArigestion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GremialConnection"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public static EmpresaG GetEmpresaRdr(MySqlDataReader rdr)
        {
            EmpresaG e = new EmpresaG();
            e.Codigo = rdr.GetInt32("codigo");
            e.Nomempre= rdr.GetString("nomempre");
            e.Cifempre = rdr.GetString("cifempre");
            e.Domempre = rdr.GetString("domempre");
            e.Codpobla = rdr.GetString("codpobla");
            e.Pobempre = rdr.GetString("pobempre");
            e.Proempre = rdr.GetString("proempre");
            return e;
        }

        public static FacturaG GetFacturaRdr(MySqlDataReader rdr)
        {
            FacturaG f = new FacturaG();
            f.Numserie = rdr.GetString("numserie");
            f.Numfactu = rdr.GetInt32("numfactu");
            f.Fecfactu = rdr.GetDateTime("fecfactu");
            f.Codclien = rdr.GetInt32("codclien");
            f.Totbases = rdr.GetDecimal("totbases");
            f.Totivas = rdr.GetDecimal("totivas");
            f.Totfaccl = rdr.GetDecimal("totfaccl");
            return f;
        }

        public static ClienteG GetClienteRdr(MySqlDataReader rdr)
        {
            ClienteG c = new ClienteG();
            c.Codclien = rdr.GetInt32("codclien");
            c.Nomclien = rdr.GetString("nomclien");
            c.Nifclien = rdr.GetString("nifclien");
            if (!rdr.IsDBNull(rdr.GetOrdinal("maiclien"))) c.Maiclien = rdr.GetString("maiclien");
            return c;
        }

        public static FacIvaG GetFacIvaRdr(MySqlDataReader rdr)
        {
            FacIvaG fi = new FacIvaG();
            fi.Porciva = rdr.GetDecimal("porciva");
            fi.Baseimp = rdr.GetDecimal("baseimpo");
            fi.Imporiv = rdr.GetDecimal("impoiva");
            return fi;
        }

        public static FacLineaG GetFacLineaRdr(MySqlDataReader rdr)
        {
            FacLineaG l = new FacLineaG();
            l.Numlinea = rdr.GetInt32("numlinea");
            l.Nomconce = rdr.GetString("nomconce");
            if (!rdr.IsDBNull(rdr.GetOrdinal("ampliaci"))) l.Ampliaci = rdr.GetString("ampliaci");
            l.Cantidad = rdr.GetDecimal("cantidad");
            l.Precio = rdr.GetDecimal("precio");
            l.Importe = rdr.GetDecimal("importe");
            l.Porciva = rdr.GetDecimal("porciva");
            if (!rdr.IsDBNull(rdr.GetOrdinal("impoiva"))) l.Impoiva = rdr.GetDecimal("impoiva");
            return l;
        }

        public static FacVtoG GetFacVtoRdr(MySqlDataReader rdr)
        {
            FacVtoG fv = new FacVtoG();
            fv.Numlinea = rdr.GetInt32("numlinea");
            fv.Fecefect = rdr.GetDateTime("fecefect");
            fv.Impefect = rdr.GetDecimal("impefect");
            return fv;
        }

        public static EmpresaG GetEmpresa ()
        {
            EmpresaG e = null;
            using(MySqlConnection conn = GetConnectionArigestion())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"SELECT * FROM empresas";
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    e = GetEmpresaRdr(rdr);
                }
                rdr.Close();
                conn.Close();
            }
            return e;
        }

        public static FacturaG GetFactura(string numserie, int numfactu, DateTime fecfactu)
        {
            FacturaG f = null;
            using (MySqlConnection conn = GetConnectionArigestion())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"SELECT * FROM factcli WHERE numserie = '{0}' AND numfactu = {1} AND fecfactu = '{2:yyyy-MM-dd}'";
                sql = String.Format(sql, numserie, numfactu, fecfactu);
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    f = GetFacturaRdr(rdr);
                }
                rdr.Close();
                conn.Close();
            }
            return f;
        }

        public static ClienteG GetCliente(int codclien)
        {
            ClienteG c = null;
            using (MySqlConnection conn = GetConnectionArigestion())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"SELECT * FROM clientes WHERE codclien = {0}";
                sql = String.Format(sql, codclien);
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    c = GetClienteRdr(rdr);
                }
                rdr.Close();
                conn.Close();
            }
            return c;
        }

        public static IList<FacIvaG> GetFacIva(string numserie, int numfactu, DateTime fecfactu)
        {
            ClienteG c = null;
            IList<FacIvaG> lfi = new List<FacIvaG>();
            using (MySqlConnection conn = GetConnectionArigestion())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"SELECT * FROM factcli_totales WHERE numserie = '{0}' AND numfactu = {1} AND fecfactu = '{2:yyyy-MM-dd}'";
                sql = String.Format(sql, numserie, numfactu, fecfactu);
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        FacIvaG fi = GetFacIvaRdr(rdr);
                        lfi.Add(fi);
                    }
                }
                rdr.Close();
                conn.Close();
            }
            return lfi;
        }

        public static IList<FacLineaG> GetFacLinea(string numserie, int numfactu, DateTime fecfactu)
        {
            IList<FacLineaG> lf = new List<FacLineaG>();
            using (MySqlConnection conn = GetConnectionArigestion())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"SELECT * FROM factcli_lineas WHERE numserie = '{0}' AND numfactu = {1} AND fecfactu = '{2:yyyy-MM-dd}'";
                sql = String.Format(sql, numserie, numfactu, fecfactu);
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        FacLineaG l = GetFacLineaRdr(rdr);
                        lf.Add(l);
                    }
                }
                rdr.Close();
                conn.Close();
            }
            return lf;
        }

        public static IList<FacVtoG> GetFacVto(string numserie, int numfactu, DateTime fecfactu)
        {
            IList<FacVtoG> flv = new List<FacVtoG>();
            using (MySqlConnection conn = GetConnectionArigestion())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = @"SELECT * FROM factcli_vtos WHERE numserie = '{0}' AND numfactu = {1} AND fecfactu = '{2:yyyy-MM-dd}'";
                sql = String.Format(sql, numserie, numfactu, fecfactu);
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        FacVtoG lv = GetFacVtoRdr(rdr);
                        flv.Add(lv);
                    }
                }
                rdr.Close();
                conn.Close();
            }
            return flv;
        }
    }
}
