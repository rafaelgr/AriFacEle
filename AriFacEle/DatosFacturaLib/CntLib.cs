using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosFacturaLib;
using AriFacElec;
using AriGasolModel;
using AriAgroModel;
using AriTaxiModel;
using MySql.Data.MySqlClient;



namespace DatosFacturaLib
{
    public static class CntLib
    {
        public static Empresa getEmpresaArigesByDB(ArigesContext Ctx0, FacturaEntity ctx1)
        {

            Empresa e;
            Sparam ariEmpresa = (from p in Ctx0.Sparams
                                 select p).FirstOrDefault<Sparam>();

            if (ariEmpresa != null && !ariEmpresa.Cifempre.Equals(""))
            {

                e = (from emp in ctx1.Empresas
                     where emp.Cif == ariEmpresa.Cifempre
                     select emp).FirstOrDefault<Empresa>();
                if (e == null)
                {
                    e = new Empresa();
                }
                e.Nombre = ariEmpresa.Nomempre;
                e.Cif = ariEmpresa.Cifempre;
                ctx1.Add(e);
            }
            else
                throw new Exception("No existe ninguna empresa");

            ctx1.SaveChanges();

            return e;
        }

        public static Empresa getEmpresaGdesByDB(GdesModelo Ctx0, FacturaEntity ctx1)
        {

            Empresa e;

            Cau_FIN_FACEInvoiceHeader gdesHeader = (from h in Ctx0.Cau_FIN_FACEInvoiceHeaders
                                                    select h).FirstOrDefault<Cau_FIN_FACEInvoiceHeader>();

            
            if (gdesHeader != null && !gdesHeader.SellerTaxIdentificationNumber.Equals(""))
            {

                e = (from emp in ctx1.Empresas
                     where emp.Cif == gdesHeader.SellerTaxIdentificationNumber
                     select emp).FirstOrDefault<Empresa>();
                if (e == null)
                {
                    e = new Empresa();
                }
                e.Nombre = gdesHeader.SellerCorporateName;
                e.Cif = gdesHeader.SellerTaxIdentificationNumber;
                ctx1.Add(e);
            }
            else
                throw new Exception("No existe ninguna empresa");

            ctx1.SaveChanges();

            return e;
        }
        

        public static Empresa getEmpresaArigasolByDB(AriGasolContext ctx0, FacturaEntity ctx1)
        {

            Empresa e;
            Sempre ariEmpresa = (from p in ctx0.Sempres
                                 select p).FirstOrDefault<Sempre>();

            if (ariEmpresa != null && !ariEmpresa.Nifempre.Equals(""))
            {

                e = (from emp in ctx1.Empresas
                     where emp.Cif == ariEmpresa.Nifempre
                     select emp).FirstOrDefault<Empresa>();
                if (e == null)
                {
                    e = new Empresa();
                }
                e.Nombre = ariEmpresa.Nomempre;
                e.Cif = ariEmpresa.Nifempre;
                ctx1.Add(e);
            }
            else
                throw new Exception("No existe ninguna empresa");

            ctx1.SaveChanges();

            return e;
        }

        //David
        public static Empresa getEmpresaAriagroByDB( AriAgroCtx  ctx0, FacturaEntity ctx1)
        {

            Empresa e;
            AriAgroModel.Empresa ariEmpresa = (from p in ctx0.Empresas
                                               select p).FirstOrDefault<AriAgroModel.Empresa>();

            if (ariEmpresa != null && !ariEmpresa.Cifempre.Equals(""))
            {

                e = (from emp in ctx1.Empresas
                     where emp.Cif == ariEmpresa.Cifempre
                     select emp).FirstOrDefault<Empresa>();
                if (e == null)
                {
                    e = new Empresa();
                }
                e.Nombre = ariEmpresa.Nomempre;
                e.Cif = ariEmpresa.Cifempre;
                ctx1.Add(e);
            }
            else
                throw new Exception("No existe ninguna empresa Ariagro");

            ctx1.SaveChanges();

            return e;
        }

        public static Empresa getEmpresaAriTaxiyDB(AriTaxiContext  ctx, FacturaEntity ctx1)
        {

            Empresa e;
            SparamTaxi  ariEmpresa = (from p in ctx.SparamTaxis 
                                      select p).FirstOrDefault<SparamTaxi>();

            if (ariEmpresa != null && !ariEmpresa.Cifempre.Equals(""))
            {

                e = (from emp in ctx1.Empresas
                     where emp.Cif == ariEmpresa.Cifempre
                     select emp).FirstOrDefault<Empresa>();
                if (e == null)
                {
                    e = new Empresa();
                }
                e.Nombre = ariEmpresa.Nomempre;
                e.Cif = ariEmpresa.Cifempre;
                ctx1.Add(e);
            }
            else
                throw new Exception("No existe ninguna empresa");

            ctx1.SaveChanges();

            return e;
        }

        public static Sistema getSistema(string baseDatos, FacturaEntity ctx1)
        {
            return (from s in ctx1.Sistemas
                    where s.BaseDatos == baseDatos
                    select s).FirstOrDefault<Sistema>();
        }

        public static Cliente getCliente(int id, FacturaEntity ctx)
        {
            return (from c in ctx.Clientes
                    where c.ID == id
                    select c).FirstOrDefault<Cliente>();
        }

        public static Cliente getCliente(string login, FacturaEntity ctx)
        {
            return (from c in ctx.Clientes
                    where c.Login == login
                    select c).FirstOrDefault<Cliente>();
        }

        public static bool getClienteMoreThanOne(string login, FacturaEntity ctx)
        {
            bool r = false;
            IList<Cliente> lc = (from c in ctx.Clientes
                                 where c.Login == login
                                 select c).ToList<Cliente>();
            if (lc.Count > 1) r = true;
            return r;
        }

        public static Cliente getClienteByEmail(string email, FacturaEntity ctx)
        {
            return (from c in ctx.Clientes
                    where c.Email == email
                    select c).FirstOrDefault<Cliente>();
        }

        public static Cliente getCliente(bool comoSocio, int Codigo, FacturaEntity ctx)
        {

            if (comoSocio)

                return (from c in ctx.Clientes
                        where c.CodSocioAriagro == Codigo 
                        select c).FirstOrDefault<Cliente>();
            else
                return (from c in ctx.Clientes
                        where c.CodTeletaxi ==Codigo 
                        select c).FirstOrDefault<Cliente>();
        
        }


        public static bool liberarfacturas(int idCliente, string directorio, FacturaEntity ctx1)
        {
            string urlaux = String.Format("Documentos\\{0:000000}", idCliente);
            string url = directorio + urlaux;
            if (System.IO.Directory.Exists(url))
            {
                System.IO.Directory.Delete(url, true);
                return true;
            }
            return false;
        }

        public static Factura getFactura(int id, FacturaEntity ctx)
        {
            return (from f in ctx.Facturas
                    where f.Id_factura == id
                    select f).FirstOrDefault<Factura>();
        }

        public static string DevuelveNombreFichero(string ElPath ,Factura fac)
        {
                        //A partir de una factura montara el nombre del fichero en disco
            string serieSocio;
            if (!fac.EsFraCliente)
            {
                if (fac.Cliente.CodSocioAritaxi != null && fac.Cliente.CodSocioAritaxi != 0)
                    serieSocio = string.Format(@"{0:000000}{1}", fac.Cliente.CodSocioAritaxi, fac.Num_serie);
                else
                    serieSocio = string.Format(@"{0:000000}{1}", fac.Cliente.CodSocioAriagro, fac.Num_serie);
            }
            else
                serieSocio = fac.Num_serie;
            return String.Format(ElPath + "{0}{1}_{2:00}{3:0000}{4}.pdf", serieSocio, fac.Num_factura, fac.Fecha.Value.Month, fac.Fecha.Value.Year, fac.LetraIdFraProve);

        }

        public static int GuardarFacturaGdes(string numSerie, Empresa empresa, GdesModelo ctxGdes, FacturaEntity ctx1, Sistema s)
        {
            Factura fac;
            Cliente cli;
            bool usaDepartamentos = false;
            // Obtener la cabecera de la factura del sistema GDES
            Cau_FIN_FACEInvoiceHeader gdesHeader = (from h in ctxGdes.Cau_FIN_FACEInvoiceHeaders
                                                    where h.ID == numSerie
                                                    select h).FirstOrDefault<Cau_FIN_FACEInvoiceHeader>();

            if (gdesHeader != null)
            {
                //Linka por sistemId tb
                fac = (from f in ctx1.Facturas
                       where f.CodDirecGdes == gdesHeader.ID && f.Sistema.SistemaId == s.SistemaId
                       select f).FirstOrDefault<Factura>();

                cli = (from c in ctx1.Clientes
                       where c.CodGdes == gdesHeader.BuyerTaxIdentificationNumber
                       select c).FirstOrDefault<Cliente>();

                // comprobaciones necesarias
                VerificarNif(gdesHeader.BuyerTaxIdentificationNumber, gdesHeader.BuyerCorporateName, ctx1);
                VerificarUsuario(gdesHeader.BuyerTaxIdentificationNumber, ctx1);
                // si usa departamentos
                usaDepartamentos = false;

                // Si la factura ya existe la borramos previamente
                // porque si no tenemos un problema para darla de alta.
                if (fac != null)
                {
                    ctx1.Delete(fac);
                    ctx1.SaveChanges();
                    fac = null;
                }


                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = gdesHeader.BuyerTaxIdentificationNumber;
                        fac.Cliente.Email = "";
                        fac.Cliente.Login = gdesHeader.BuyerTaxIdentificationNumber;


                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                }
                fac.Cliente.CodGdes = gdesHeader.BuyerTaxIdentificationNumber;
                fac.Cliente.Cif = gdesHeader.BuyerTaxIdentificationNumber;
                fac.Cliente.Empresa = empresa;
                fac.Cliente.Nombre = gdesHeader.BuyerCorporateName;
                fac.Cliente.F_nueva = true;
                fac.Cliente.OrganoGestorCodigo = gdesHeader.CODIGOORGANOGESTOR;
                fac.Cliente.UnidadTramitadoraCodigo = gdesHeader.CODIGOUNIDADTRAMITADORA;
                fac.Cliente.OficinaContableCodigo = gdesHeader.CODIGOOFICINACONTABLE;
                fac.Cliente.Iban = gdesHeader.IBAN;

                fac.OrganoGestorCodigo = gdesHeader.CODIGOORGANOGESTOR;
                fac.UnidadTramitadoraCodigo = gdesHeader.CODIGOUNIDADTRAMITADORA;
                fac.OficinaContableCodigo = gdesHeader.CODIGOOFICINACONTABLE;
                fac.Sistema = s;
                fac.EsFraCliente = true;
                fac.LetraIdFraProve = "";  // Esto solo para ariagro
                fac.ImpRetencion = 0; // por si acaso
                fac.SistemaGdes = gdesHeader.DATAAREAID;

                fac.Nueva = true;
                fac.CodDirecGdes = gdesHeader.ID;

                fac.Base_total = gdesHeader.TotalGrossAmountBeforeTaxes;
                fac.Cuota_total = gdesHeader.TotalTaxOutputs;
                fac.Fecha = gdesHeader.IssueDate;
                fac.Num_factura = 0;
                fac.Num_serie = gdesHeader.InvoiceNumber;
                fac.Ttal = gdesHeader.TotalAmount;
                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con la referencia" + numSerie);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }


        public static int GuardarFacturaAriGes(bool EsAriges1,string numSerie, int numfactura, DateTime fecha, Empresa empresa, ArigesContext ctxAriges, FacturaEntity ctx1, Sistema s)
        {
            Factura fac;
            Cliente cli;
            bool usaDepartamentos = false;
            bool yaEstaba = false;
            string codtipom = getCodtipom(numSerie, ctxAriges);
            Scafac ariFactura = (from c in ctxAriges.Scafacs
                                 where c.Numfactu == numfactura && c.Codtipom == codtipom && c.Fecfactu == fecha
                                 select c).FirstOrDefault<Scafac>();
           
            if (ariFactura != null)
            {
                //Linka por sistemId tb
                fac = (from f in ctx1.Facturas
                       where f.Num_factura == ariFactura.Numfactu && f.Num_serie == numSerie.ToString() && f.Sistema.SistemaId  == s.SistemaId && f.Fecha == ariFactura.Fecfactu
                       select f).FirstOrDefault<Factura>();
                if (fac != null)
                {
                    ctx1.Delete(fac);
                    ctx1.SaveChanges();
                }
                fac = null;
                cli = (from c in ctx1.Clientes
                       where c.Cif == ariFactura.Sclien.Nifclien
                       //&& c.coddirec_ariges == ariFactura.Coddirec
                       select c).FirstOrDefault<Cliente>();

                // comprobaciones necesarias
                VerificarNif(ariFactura.Sclien.Nifclien, ariFactura.Sclien.Nomclien, ctx1);
                VerificarUsuario(ariFactura.Sclien.Nifclien, ctx1);
                // si usa departamentos
                usaDepartamentos = UsaDepartamento(ctxAriges);
                if (usaDepartamentos && ariFactura.Coddirec != null)
                {
                    VerificarDepartamento((int)ariFactura.Sclien.Codclien, (int)ariFactura.Coddirec, ctxAriges, ctx1);
                }


                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = ariFactura.Sclien.Pasclien;
                        fac.Cliente.Email = ariFactura.Sclien.Maiclie1;
                        fac.Cliente.Login = ariFactura.Sclien.Nifclien;

                        //fac.Cliente.coddirec_ariges = (int)ariFactura.Coddirec;


                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                }
                 if (EsAriges1)
                {
                    fac.Cliente.CodclienAriges = ariFactura.Sclien.Codclien;
                    fac.Cliente.CodClienAriges2 = 0;
           
                }
                else
                {
                    fac.Cliente.CodclienAriges = 0;
                    fac.Cliente.CodClienAriges2 = ariFactura.Sclien.Codclien;
                }
                fac.Cliente.Cif = ariFactura.Sclien.Nifclien;
                fac.Cliente.Empresa = empresa;
                fac.Cliente.Nombre = ariFactura.Sclien.Nomclien;
                fac.Cliente.F_nueva = true;
                fac.Sistema = s;
                fac.EsFraCliente = true;
                fac.LetraIdFraProve = "";  // Esto solo para ariagro
                fac.ImpRetencion = 0; // por si acaso

                fac.Nueva = true;
                if (usaDepartamentos && ariFactura.Coddirec != null) fac.coddirec_ariges = (int)ariFactura.Coddirec;
                fac.Base_total = ariFactura.Brutofac;
                fac.Cuota_total = 0;
                if (ariFactura.Imporiv1 != new decimal() && !ariFactura.Imporiv1.Equals(null))
                    fac.Cuota_total += ariFactura.Imporiv1;
                if (ariFactura.Imporiv2 != new decimal() && ariFactura.Imporiv2 != null)
                    fac.Cuota_total += ariFactura.Imporiv2;
                if (ariFactura.Imporiv3 != new decimal() && ariFactura.Imporiv3 != null)
                    fac.Cuota_total += ariFactura.Imporiv3;
                fac.Fecha = ariFactura.Fecfactu;
                fac.Num_factura = ariFactura.Numfactu;
                fac.Num_serie = numSerie.ToString();
                fac.Ttal = ariFactura.Totalfac;
                if (ariFactura.Coddirec != null)
                    fac.coddirec_ariges = (int)ariFactura.Coddirec;
                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con número" + numfactura);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }

        public static int GuardarFacturaAriGasol(string numSerie, int numfactura, DateTime fecha, Empresa empresa, AriGasolContext ctx2, FacturaEntity ctx1, Sistema s)
        {
            Factura fac;
            Cliente cli;
            
            //Antes Julio 2013.   Ahora puede tener mas de un carcater
            //char letra = numSerie[0];

            //Schfac ariFactura = (from c in ctx2.Schfacs
            //                     where c.Numfactu == numfactura && c.Letraser == letra && c.Fecfactu == fecha
            //                     select c).FirstOrDefault<Schfac>();

            Schfac ariFactura = (from c in ctx2.Schfacs
                                 where c.Numfactu == numfactura && c.Letraser == numSerie && c.Fecfactu == fecha
                                 select c).FirstOrDefault<Schfac>();




            if (ariFactura != null)
            {
                //Tb join por sistemaID
                fac = (from f in ctx1.Facturas
                       where f.Num_factura == ariFactura.Numfactu && f.Num_serie == numSerie.ToString() && f.Sistema.SistemaId == s.SistemaId 
                       select f).FirstOrDefault<Factura>();

                cli = (from c in ctx1.Clientes
                       where c.Cif == ariFactura.Ssocio.Nifsocio
                       select c).FirstOrDefault<Cliente>();
                // comprobaciones necesarias
                VerificarNif(ariFactura.Ssocio.Nifsocio, ariFactura.Ssocio.Nomsocio, ctx1);
                VerificarUsuario(ariFactura.Ssocio.Nifsocio, ctx1);

                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = ariFactura.Ssocio.Nifsocio;
                        fac.Cliente.Email = ariFactura.Ssocio.Maisocio;
                        fac.Cliente.Login = ariFactura.Ssocio.Nifsocio;
                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                }

                fac.Cliente.CodclienArigasol = ariFactura.Ssocio.Codsocio;
                fac.Cliente.Cif = ariFactura.Ssocio.Nifsocio;
                fac.Cliente.Empresa = empresa;
                fac.Cliente.Nombre = ariFactura.Ssocio.Nomsocio;
                
                fac.Cliente.F_nueva = true;
                fac.EsFraCliente = true;
                fac.LetraIdFraProve = "";  // Esto solo para ariagro
                fac.ImpRetencion = 0; // por si acaso
                fac.Nueva = true;

                fac.Base_total = 0;
                if (ariFactura.Baseimp1 != null) fac.Base_total += ariFactura.Baseimp1;
                if (ariFactura.Baseimp2 != null) fac.Base_total += ariFactura.Baseimp2;
                if (ariFactura.Baseimp3 != null) fac.Base_total += ariFactura.Baseimp3;

                fac.Cuota_total = 0;
                if (ariFactura.Impoiva1 != null) fac.Cuota_total += ariFactura.Impoiva1;
                if (ariFactura.Impoiva2 != null) fac.Cuota_total += ariFactura.Impoiva2;
                if (ariFactura.Impoiva3 != null) fac.Cuota_total += ariFactura.Impoiva3;

                fac.Fecha = ariFactura.Fecfactu;
                fac.Num_factura = ariFactura.Numfactu;
                fac.Num_serie = numSerie.ToString();
                fac.Ttal = ariFactura.Totalfac;
                fac.Sistema = s;

                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con número" + numfactura);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }

        //*******************************************************************
        #region  Ariagro

        public static int FacturaAriAgroCliente(string numSerie, int numfactura, DateTime fecha, Empresa empresa,AriAgroCtx  ctx3, FacturaEntity ctx1, Sistema s,string elCodtipom)
        {
            Factura fac;
            Cliente cli;


            // string codtipom = GetAriagroCodtipom(numSerie, ctx3,ctx1);    Como lo trae el nombre del fichero, YA no lo calculo


            
            AriAgroModel.Factura ariFactura = (from c in ctx3.Facturas
                                               where c.Numfactu == (uint)numfactura && c.Codtipom == elCodtipom && c.Fecfactu == fecha
                                               select c).FirstOrDefault<AriAgroModel.Factura>();
            
            if (ariFactura != null)
            {
                //El codtipom para este tipo de facturas es IMPORTANTISIMO
                //LIncara pues por sistema ID y codtipom
                fac = (from f in ctx1.Facturas
                       where f.Num_factura == ariFactura.Numfactu && f.Num_serie == numSerie.ToString()
                        && f.Sistema.SistemaId == s.SistemaId && f.vCodtipom == elCodtipom 
                       select f).FirstOrDefault<Factura>();

                cli = (from c in ctx1.Clientes
                       where c.Cif == ariFactura.Cliente.Cifclien
                       select c).FirstOrDefault<Cliente>();
                // comprobaciones necesarias
                VerificarNif(ariFactura.Cliente.Cifclien, ariFactura.Cliente.Nomclien, ctx1);
                VerificarUsuario(ariFactura.Cliente.Cifclien, ctx1);

                if (fac != null)
                {
                    ctx1.Delete(fac);
                    ctx1.SaveChanges();
                    fac = null;
                }

                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = ariFactura.Cliente.Cifclien;
                        fac.Cliente.Email = ariFactura.Cliente.Maiclie1;
                        fac.Cliente.Login = ariFactura.Cliente.Cifclien;
                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                    fac.vCodtipom = elCodtipom;
                }

                fac.Cliente.CodclienAriagro = (int)ariFactura.Cliente.Codclien ;
                fac.Cliente.Cif = ariFactura.Cliente.Cifclien;
                fac.Cliente.Empresa = empresa;
                fac.Cliente.Nombre = ariFactura.Cliente.Nomclien ;
                fac.Cliente.F_nueva = true;
                fac.EsFraCliente = true;
                fac.LetraIdFraProve = "F";  // Facturas normales de cliente en ariagro
                fac.ImpRetencion = 0; // por si acaso
                fac.Nueva = true;

                fac.Base_total = 0;
                if (ariFactura.Baseimp1 != null) fac.Base_total += ariFactura.Baseimp1;
                if (ariFactura.Baseimp2 != null) fac.Base_total += ariFactura.Baseimp2;
                if (ariFactura.Baseimp3 != null) fac.Base_total += ariFactura.Baseimp3;

                fac.Cuota_total = 0;
                if (ariFactura.Impoiva1 != null) fac.Cuota_total += ariFactura.Impoiva1;
                if (ariFactura.Impoiva2 != null) fac.Cuota_total += ariFactura.Impoiva2;
                if (ariFactura.Impoiva3 != null) fac.Cuota_total += ariFactura.Impoiva3;

                //Igual que en ARiges, puede haber recargo equivalencia
                //`imporec1` `imporec2` `imporec3`
                if (ariFactura.Imporec1 != null) fac.Cuota_total += ariFactura.Imporec1;
                if (ariFactura.Imporec2 != null) fac.Cuota_total += ariFactura.Imporec2;
                if (ariFactura.Imporec3 != null) fac.Cuota_total += ariFactura.Imporec3;

                fac.Fecha = ariFactura.Fecfactu;

                fac.Num_factura = (int)ariFactura.Numfactu;
                fac.Num_serie = numSerie.ToString();
                fac.Ttal = ariFactura.Totalfac;
                fac.Sistema = s;


                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con número" + numfactura);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }

        public static int FacturaAriAgroSocio(string numSerie, int numfactura, DateTime fecha, Empresa empresa, AriAgroCtx ctx3, FacturaEntity ctx1, Sistema s, ref int Codsocio, string elCodTipom)
        {
            Factura fac;
            Cliente cli;


            //string codtipom = GetAriagroCodtipom(numSerie, ctx3, ctx1);   Como lo trae el nombre del fichero, YA no lo calculo


            AriAgroModel.Rfactsoc  ariFactura = (from c in ctx3.Rfactsocs
                                                 where c.Numfactu == (uint)numfactura && c.Codtipom == elCodTipom && c.Fecfactu == fecha
                                                 select c).FirstOrDefault<AriAgroModel.Rfactsoc>();

            if (ariFactura != null)
            {
                //Linka por sistema y codtipom
                fac = (from f in ctx1.Facturas
                       where f.Num_factura == ariFactura.Numfactu && f.Num_serie == numSerie.ToString()
                         && f.Sistema.SistemaId == s.SistemaId && f.vCodtipom == elCodTipom 
                       select f).FirstOrDefault<Factura>();

                cli = (from c in ctx1.Clientes
                       where c.Cif == ariFactura.Rsocio.Nifsocio
                       select c).FirstOrDefault<Cliente>();

                // comprobaciones necesarias
                VerificarNif(ariFactura.Rsocio.Nifsocio, ariFactura.Rsocio.Nomsocio, ctx1);
                VerificarUsuario(ariFactura.Rsocio.Nifsocio, ctx1);

                if (fac != null)
                {
                    ctx1.Delete(fac);
                    ctx1.SaveChanges();
                    fac = null;
                }


                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = ariFactura.Rsocio.Nifsocio;
                        fac.Cliente.Email = ariFactura.Rsocio.Maisocio ;
                        fac.Cliente.Login = ariFactura.Rsocio.Nifsocio;
                        fac.Cliente.Nombre = ariFactura.Rsocio.Nomsocio;
                        fac.Cliente.Cif = ariFactura.Rsocio.Nifsocio;
                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                    fac.vCodtipom = elCodTipom;
                }

                fac.Cliente.CodSocioAriagro  = (int)ariFactura.Rsocio.Codsocio ;
                Codsocio = fac.Cliente.CodSocioAriagro;  // Lo devuelve de la funcion pq con el construira el nombre
                fac.Cliente.Empresa = empresa;

                //lo hago arriba y solo si es nuevo
                //fac.Cliente.Nombre = ariFactura.Rsocio.Nomsocio; 
                //fac.Cliente.Cif = ariFactura.Rsocio.Nifsocio;
                fac.Cliente.TieneFacturaPROV = true;
                fac.Cliente.F_nueva = true;
                fac.EsFraCliente = false;
                fac.LetraIdFraProve = "S";  // Facturas socio
  
                fac.Nueva = true;

                // `baseimpo` `imporiva`  `impreten` `impapor` `totalfac`
                fac.Base_total = ariFactura.Baseimpo  ;
      
                fac.Cuota_total = ariFactura.Imporiva   ;
                fac.ImpGastosAFo = 0;
                fac.ImpRetencion = 0;
                if (ariFactura.Impreten != null)
                    fac.ImpRetencion = (decimal)ariFactura.Impreten;
                if (ariFactura.Impapor != null)
                    fac.ImpGastosAFo = (decimal)ariFactura.Impapor;

                fac.Fecha = ariFactura.Fecfactu;

                fac.Num_factura = (int)ariFactura.Numfactu;
                fac.Num_serie = numSerie.ToString();
                fac.Ttal = ariFactura.Totalfac;
                fac.Sistema = s;

                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con número" + numfactura);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }

        #endregion
        // ******************************************************************

        #region  Aritaxi

        public static int FacturaAriTaxiCliente(string numSerie, int numfactura, DateTime fecha, Empresa empresa,AriTaxiContext   ctxT, FacturaEntity ctx1, Sistema s)
        {
            Factura fac;
            Cliente cli;
           
            string codtipom = getCodTipomTeletaxi(numSerie, ctxT);

            AriTaxiModel.Scafaccli  ariFactura = (from c in ctxT.Scafacclis 
                                               where c.Numfactu == (uint)numfactura && c.Codtipom == codtipom && c.Fecfactu == fecha
                                                  select c).FirstOrDefault<AriTaxiModel.Scafaccli>();

            if (ariFactura != null)
            {
                fac = (from f in ctx1.Facturas
                       where f.Num_factura == ariFactura.Numfactu && f.Num_serie == numSerie.ToString() && f.Fecha ==fecha
                       select f).FirstOrDefault<Factura>();
                if (fac != null)
                {
                    // eliminar la factura porque la vamos a crear.
                    ctx1.Delete(fac);
                    ctx1.SaveChanges();
                    fac = null;
                }
                //abril 2013
                // Linkara por nif y CODCLIEN teletaxi

                cli = (from c in ctx1.Clientes
                       where c.Cif == ariFactura.Scliente.Nifclien  && c.CodTeletaxi == ariFactura.Codclien 
                       select c).FirstOrDefault<Cliente>();

                // comprobaciones necesarias
                VerificarNif(ariFactura.Scliente.Nifclien, ariFactura.Scliente.Nomclien, ctx1);
                VerificarUsuario(ariFactura.Scliente.Nifclien, ctx1);

                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = ariFactura.Scliente.Nifclien ;
                        fac.Cliente.Email = ariFactura.Scliente.Maiclie1 ;
                        fac.Cliente.Login = ariFactura.Scliente.Nifclien;
                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                }

                fac.Cliente.CodTeletaxi =(int)( ariFactura.Codclien);
                fac.Cliente.Cif = ariFactura.Scliente.Nifclien;
                fac.Cliente.Empresa = empresa;
                fac.Cliente.Nombre = ariFactura.Scliente.Nomclien ;
                fac.Cliente.F_nueva = true;
                //
                fac.Cliente.OrganoGestorCodigo = ariFactura.Scliente.OrganoGestor;
                fac.Cliente.UnidadTramitadoraCodigo = ariFactura.Scliente.UnidadTramitadora;
                fac.Cliente.OficinaContableCodigo = ariFactura.Scliente.OficinaContable;
                fac.Cliente.OrganoProponente = ariFactura.Scliente.OrganoProponente;
                fac.Cliente.Email = ariFactura.Scliente.Maiclie1;
                fac.Cliente.Iban = ariFactura.Scliente.Iban.ToString() + ariFactura.Scliente.Codbanco.ToString() + ariFactura.Scliente.Codsucur.ToString() + ariFactura.Scliente.Digcontr.ToString() + ariFactura.Scliente.Cuentaba.ToString();

                // Nuevos campos a actualizar
                fac.EsFraCliente = true;
                fac.LetraIdFraProve = "F";  // Facturas normales de cliente en teletaxi
                fac.ImpRetencion = 0; // por si acaso
                fac.Nueva = true;

                fac.Base_total = 0;
                if (ariFactura.Baseimp1 != null) fac.Base_total += ariFactura.Baseimp1;
                if (ariFactura.Baseimp2 != null) fac.Base_total += ariFactura.Baseimp2;
                if (ariFactura.Baseimp3 != null) fac.Base_total += ariFactura.Baseimp3;

                fac.Cuota_total = 0;
                if (ariFactura.Imporiv1 != null) fac.Cuota_total += ariFactura.Imporiv1;
                if (ariFactura.Imporiv2 != null) fac.Cuota_total += ariFactura.Imporiv2;
                if (ariFactura.Imporiv3 != null) fac.Cuota_total += ariFactura.Imporiv3;

                //Igual que en ARiges, puede haber recargo equivalencia
                //`imporec1` `imporec2` `imporec3`
                if (ariFactura.Imporiv1re != null) fac.Cuota_total += ariFactura.Imporiv1re;
                if (ariFactura.Imporiv2re != null) fac.Cuota_total += ariFactura.Imporiv2re;
                if (ariFactura.Imporiv3re != null) fac.Cuota_total += ariFactura.Imporiv3re;

                fac.Fecha = ariFactura.Fecfactu;

                fac.Num_factura = (int)ariFactura.Numfactu;
                fac.Num_serie = numSerie.ToString();
                fac.Ttal = ariFactura.Totalfac;
                fac.Sistema = s;


                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con número" + numfactura);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }

        public static int FacturaAriTaxiCuotas(string numSerie, int numfactura, DateTime fecha, Empresa empresa, AriTaxiContext ctxT, FacturaEntity ctx1, Sistema s)
        {
            Factura fac;
            Cliente cli;

            string codtipom = getCodTipomTeletaxi(numSerie, ctxT);

            AriTaxiModel.Scafacuota ariCuota = (from c in ctxT.Scafacuotas
                                                 where c.Numfactu == (uint)numfactura && c.Codtipom == codtipom && c.Fecfactu == fecha
                                                 select c).FirstOrDefault<AriTaxiModel.Scafacuota>();

            if (ariCuota != null)
            {
                fac = (from f in ctx1.Facturas
                       where f.Num_factura == ariCuota.Numfactu && f.Num_serie == numSerie.ToString() && f.Fecha == fecha
                       select f).FirstOrDefault<Factura>();
                //abril 2013
                // Linkara por nif y CODCLIEN teletaxi

                cli = (from c in ctx1.Clientes
                       where c.Cif == ariCuota.Sclien.Nifclien && c.CodSocioAritaxi == ariCuota.Sclien.Codclien
                       select c).FirstOrDefault<Cliente>();

                // comprobaciones necesarias
                VerificarNif(ariCuota.Sclien.Nifclien, ariCuota.Sclien.Nomclien, ctx1);
                VerificarUsuario(ariCuota.Sclien.Nifclien, ctx1);

                if (fac != null)
                {
                    ctx1.Delete(fac);
                    ctx1.SaveChanges();
                    fac = null;
                }


                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = ariCuota.Sclien.Nifclien;
                        fac.Cliente.Email = ariCuota.Sclien.Maiclie1;
                        fac.Cliente.Login = ariCuota.Sclien.Codclien.ToString();
                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                }

                fac.Cliente.CodSocioAritaxi = (int)ariCuota.Sclien.Codclien;
                fac.Cliente.Cif = ariCuota.Sclien.Nifclien;
                fac.Cliente.Empresa = empresa;
                fac.Cliente.Nombre = ariCuota.Sclien.Nomclien;
                fac.Cliente.F_nueva = true;
                fac.EsFraCliente = true;
                fac.LetraIdFraProve = "C";  // Facturas de cuotas
                fac.ImpRetencion = 0; // por si acaso
                fac.Nueva = true;

                fac.Base_total = 0;
                if (ariCuota.Baseimp1 != null) fac.Base_total += ariCuota.Baseimp1;
                if (ariCuota.Baseimp2 != null) fac.Base_total += ariCuota.Baseimp2;
                if (ariCuota.Baseimp3 != null) fac.Base_total += ariCuota.Baseimp3;

                fac.Cuota_total = 0;
                if (ariCuota.Imporiv1 != null) fac.Cuota_total += ariCuota.Imporiv1;
                if (ariCuota.Imporiv2 != null) fac.Cuota_total += ariCuota.Imporiv2;
                if (ariCuota.Imporiv3 != null) fac.Cuota_total += ariCuota.Imporiv3;

                //Igual que en ARiges, puede haber recargo equivalencia
                //`imporec1` `imporec2` `imporec3`
                if (ariCuota.Imporiv1re != null) fac.Cuota_total += ariCuota.Imporiv1re;
                if (ariCuota.Imporiv2re != null) fac.Cuota_total += ariCuota.Imporiv2re;
                if (ariCuota.Imporiv3re != null) fac.Cuota_total += ariCuota.Imporiv3re;

                fac.Fecha = ariCuota.Fecfactu;

                fac.Num_factura = (int)ariCuota.Numfactu;
                fac.Num_serie = numSerie.ToString();
                fac.Ttal = ariCuota.Totalfac;
                fac.Sistema = s;


                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con número" + numfactura);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }


        public static int FacturaAriTaxiSocio(string numSerie, int numfactura, DateTime fecha, Empresa empresa, AriTaxiContext ctxT, FacturaEntity ctx1, Sistema s, ref int Codsocio)
        {
            Factura fac;
            Cliente cli;
            uint codSocio;


            // format(codsocio,"000000") + letraser
            codSocio = Convert.ToUInt16(numSerie.Substring(0, 6));
            numSerie = numSerie.Substring(6);  



            string codtipom = getCodTipomTeletaxi(numSerie, ctxT);

      


            AriTaxiModel.Sfactusoc  ariFactura = (from c in ctxT.Sfactusocs 
                                                where c.Numfactu == (uint)numfactura && c.Codtipom == codtipom && c.Fecfactu == fecha
                                                  && c.Codsocio ==codSocio 
                                                  select c).FirstOrDefault<AriTaxiModel.Sfactusoc>();

            if (ariFactura != null)
            {


                //30Abr2013
                // LINKAMOS tambien por codsocio. Si no existe se creara un nuevo socio
                // ya que puede existir dos socios (codsocio distintos) pero con el mismo nif
                // Por lo tanto al lincar por codsocio si no existe creara uno nuevo
              /*  cli = (from c in ctx1.Clientes
                       where c.Cif == ariFactura.Sclien.Nifclien
                       select c).FirstOrDefault<Cliente>();

                */

                cli = (from c in ctx1.Clientes
                       where c.Cif == ariFactura.Sclien.Nifclien && c.CodSocioAritaxi == codSocio
                       select c).FirstOrDefault<Cliente>();
                // Para evitar problemas hay que dar de alta al cliente ya
                if (cli == null)
                {
                    cli = new Cliente();

                    cli.Contraseña = ariFactura.Sclien.Nifclien;
                    cli.Email = ariFactura.Sclien.Maiclie1;
                    cli.Login = ariFactura.Sclien.Codclien.ToString();
                    cli.Nombre = ariFactura.Sclien.Nomclien;
                    cli.Cif = ariFactura.Sclien.Nifclien;
                    cli.CodSocioAritaxi = (int)codSocio;
                    ctx1.Add(cli);
                    ctx1.SaveChanges();
                }
                
                
                /*
                 * como linka por codsocio, no hace falta este control
                if (cli != null)
                {
                    if (cli.CodSocioAriagro > 0)
                    {
                        if (cli.CodSocioAriagro != codSocio)
                        {
                            throw new Exception("para ese NIF: " + cli.Cif + " no es el socio: " + codSocio);
                        }
                    }
                }
                */
                if (cli == null)
                {
                    fac = (from f in ctx1.Facturas
                           where f.Num_factura == ariFactura.Numfactu && f.Num_serie == numSerie.ToString() && f.Fecha == ariFactura.Fecfactu
                           select f).FirstOrDefault<Factura>();
                }
                else
                {
                    fac = (from f in ctx1.Facturas
                           where f.Num_factura == ariFactura.Numfactu && f.Num_serie == numSerie.ToString() && f.Fecha == ariFactura.Fecfactu && f.Cliente.ID == cli.ID
                           select f).FirstOrDefault<Factura>();
                }


                // comprobaciones necesarias
                VerificarNif(ariFactura.Sclien.Nifclien, ariFactura.Sclien.Nomclien, ctx1);
                VerificarUsuario(ariFactura.Sclien.Nifclien, ctx1);

                if (fac != null)
                {
                    ctx1.Delete(fac);
                    ctx1.SaveChanges();
                    fac = null;
                }

                if (fac == null)
                {
                    fac = new Factura();

                    if (cli == null)
                    {
                        fac.Cliente = new Cliente();

                        fac.Cliente.Contraseña = ariFactura.Sclien.Nifclien;
                        fac.Cliente.Email = ariFactura.Sclien.Maiclie1 ;
                        fac.Cliente.Login = ariFactura.Sclien.Codclien.ToString();
                        fac.Cliente.Nombre = ariFactura.Sclien.Nomclien ;
                        fac.Cliente.Cif = ariFactura.Sclien.Nifclien;
                        fac.Cliente.CodSocioAritaxi = (int)codSocio;
                    }
                    else
                    {
                        fac.Cliente = cli;
                    }
                }

                // fac.Cliente.CodSocioAriagro   = (int)ariFactura.Codsocio ;   //Cuando es SOCIO coje este valor
                // Codsocio = fac.Cliente.CodSocioAriagro;  // Lo devuelve de la funcion pq con el construira el nombre
                Codsocio = (int)ariFactura.Codsocio;  // Lo devuelve de la funcion pq con el construira el nombre
               
                fac.Cliente.Empresa = empresa;

                //lo hago arriba y solo si es nuevo
                //fac.Cliente.Nombre = ariFactura.Rsocio.Nomsocio; 
                //fac.Cliente.Cif = ariFactura.Rsocio.Nifsocio;
                fac.Cliente.TieneFacturaPROV = true;
                fac.Cliente.F_nueva = true;
                fac.EsFraCliente = false;
                fac.LetraIdFraProve = "S";  // Facturas socio

                fac.Nueva = true;

                // `baseimpo` `imporiva`  `impreten` `impapor` `totalfac`
                fac.Base_total = ariFactura.Baseiva1 ;

                fac.Cuota_total = ariFactura.Impoiva1 ;
                fac.ImpGastosAFo = 0;
                fac.ImpRetencion = 0;
                if (ariFactura.Impreten  != null)
                    fac.ImpRetencion = (decimal)ariFactura.Impreten;
             

                fac.Fecha = ariFactura.Fecfactu;

                fac.Num_factura = (int)ariFactura.Numfactu;
                fac.Num_serie = numSerie.ToString();
                fac.Ttal = ariFactura.Totalfac;
                fac.Sistema = s;


                ctx1.Add(fac);
            }
            else
                throw new Exception("No existe ninguna factura con número" + numfactura);

            ctx1.SaveChanges();

            return fac.Id_factura;
        }

        #endregion  


        //public static Firma obtenerFirma(Empresa e, FacturaEntity ctx1)
        //{
        //    Firma f = (from emp in ctx1.Empresas
        //               select emp).FirstOrDefault<Empresa>().Firmas.FirstOrDefault<Firma>();
        //    return f;
        //}

        private static string getCodtipom(string numSerie, ArigesContext ctx0)
        {
            string codTipom = (from s in ctx0.Stipoms
                               where s.Letraser == numSerie
                               select s).First<Stipom>().Codtipom;
            return codTipom;
        }


        private static string getCodTipomTeletaxi(string numSerie, AriTaxiContext ctxx)
        {
            string codTipom = (from s in ctxx.StipomTaxis 
                               where s.Letraser == numSerie
                               select s).First<StipomTaxi>().Codtipom;
            return codTipom;
        }
        


        public static Plantilla  getPlantilla(int id, FacturaEntity ctx)
        {
            return (from p in ctx.Plantillas 
                    where p.Plantilla_id  == id
                    select p).FirstOrDefault<Plantilla>();
        }


        //A partir de un CTX devolvera la cadena de conexion
        public static string DevuelveCadenaConexionMysql(string CadenaDeConexion,string vServer,String vDatabase)
        {
            int i, j;
            string s = CadenaDeConexion;
            i = s.IndexOf("User Id=");
            j = s.IndexOf(";", i);
            i = i + 8; //8 de la cadena 
            j = j - i;
            string user = s.Substring(i, j);
            i = s.IndexOf("password=");
            j = s.IndexOf(";", i);
            i = i + 9; //9 de la cadena y uno de la posicion
            j = j - i;
            string password = s.Substring(i, j);
            return "SERVER=" + vServer +
                ";DATABASE=" + vDatabase +
                ";UID=" + user +
                ";PASSWORD=" + password + ";";
        }

        public static string GetAriagroCodtipom(string numSerie, AriAgroCtx ctx1, FacturaEntity ctx0)
        {
            //Por algun motivo que no se entodavia, ctx3 no me da el password con el connection string
            string myConString = DevuelveCadenaConexionMysql(ctx0.Connection.ConnectionString, ctx1.Connection.DataSource, ctx1.Connection.Database);


            MySqlConnection connection = new MySqlConnection(myConString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;

            connection.Open();



            command.CommandText = "SELECT codtipom FROM usuarios.stipom WHERE letraser='" + numSerie + "'";
            Reader = command.ExecuteReader();
            string codtipom = "";
            while (Reader.Read())   //Para cada registro
            {
                codtipom = Reader.GetValue(0).ToString(); //NumConta
            }
            Reader.Close();

            connection.Close();
            return codtipom;
        }
        
        // En esta región vamos a incluir las funciones relacionadas con las nuevas tablas
        // para AriFAce: nifbase, usuario, departamento
        #region AriFace

        public static void VerificarNif(string nif, string nombre, FacturaEntity ctx)
        {
            // buscamos si ya existe un registro
            Nifbase nb = (from n in ctx.Nifbases
                          where n.Nif == nif
                          select n).FirstOrDefault<Nifbase>();
            if (nb == null)
            {
                // sólo hacemos algo si no existe.
                nb = new Nifbase()
                {
                    Nif=nif,
                    Nombre= nombre
                };
                ctx.Add(nb);
                ctx.SaveChanges();
            }
        }

        public static void VerificarUsuario(string nif, FacturaEntity ctx)
        {
            // comprobar si existe alguno así
            Usuario usu = (from u in ctx.Usuarios
                           where u.Nif == nif
                           select u).FirstOrDefault<Usuario>();
            if (usu == null)
            {
                Usuario u = new Usuario();
                u.Nif = nif;
                u.Nombre = String.Format("USU {0}",u.Nif);
                u.Login = nif;
                u.Password = nif;
                // si se crea por defecto es de la empresa raiz
                u.ClienteId = 0;
                u.DepartamentoId = 0;
                ctx.Add(u);
                ctx.SaveChanges();
            }
        }

        public static bool UsaDepartamento(ArigesContext ctx)
        {
            bool res = false;
            Spara1 parametros = ctx.Spara1.FirstOrDefault<Spara1>();
            if (parametros != null)
            {
                if (parametros.Haydepar == 1) res = true;
            }
            return res;
        }

        public static void VerificarDepartamento(int codclien, int coddirec, ArigesContext ctx0, FacturaEntity ctx)
        {
            // verificar si el departamento ya existe
            Departamento dp = (from d in ctx.Departamentos
                               where d.Codclien == codclien && d.Coddirec == coddirec
                               select d).FirstOrDefault<Departamento>();
            if (dp == null)
            {
                string nombre = "------";
                // buscamos el nombre del departamento
                Sdirec sd = (from d in ctx0.Sdirecs
                             where d.Codclien == (short)codclien && d.Coddirec == (short)coddirec
                             select d).FirstOrDefault<Sdirec>();
                if (sd != null) nombre = sd.Nomdirec;
                // montamos el departamento de AriFace
                dp = new Departamento();
                dp.Coddirec = coddirec;
                dp.Codclien = codclien;
                dp.Nombre = nombre;
                ctx.Add(dp);
                ctx.SaveChanges();
            }

        }

        #endregion 
    }
}
