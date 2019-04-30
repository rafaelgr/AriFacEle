using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using AriFacElec;
using AriGasolModel;
using AriAgroModel;
using AriTaxiModel;
using DatosFacturaLib;
using System.Configuration;
using AriFtp;
using System.Timers;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace AriFacEleWiS
{
    /// <summary>
    /// CntWiS es una clase de control que maneja las funciones de soporte
    /// del servicio windows de que se trate.
    /// </summary>
    public static partial class CntWiS
    {
        static string message;
        static string sSource = "Ariadna Electronic Invoice Service";
        static string sLog = "Application";
        static string sEvent = "AriFacEleWiS";
        static bool logAvailabel = true; 

        static string sourcePath;
        static FTP ftp;

        static DatosFacturaLib.Empresa empresa;
        static Timer myTimer;
        static DatosFacturaLib.Firma firma;

        static ArigesContext ctx0;
        static FacturaEntity ctx1;
        static AriGasolContext ctx2;
        static AriAgroCtx ctx3;
        static ArigesContext ctx0_2;    //Alzira  Telefonia va a un ariges y ventas a otro
        static AriTaxiContext ctx4;
        static GdesModelo ctx5; // Nuevas modificaciones para GDES

        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";


        public static void myOnStart(string[] args)
        {
            // open mylog in order to write int it down.
            

            // it controls if the source exists
            try
            {
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);
            }
            catch (Exception ex)
            {
                logAvailabel = false;
                LogOrConsole(String.Format("Fallo de log: {0}", ex.Message), 4);
            }

            // show version number in log
            string v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            message = String.Format("ARIFACE SERVICE VRS {0}", v);
            LogOrConsole(message, 1);

            // connect to databases
            try
            {
                ctx1 = new FacturaEntity("FacturaEntity");

                string tieneAriges = ConfigurationSettings.AppSettings["TieneAriges"];
                // aunque parezca incorrecto no lo es, porque antes se abría siempre por
                // defecto. Si ahora el parámetro no se ha incluido el comportamiento sería como
                // en el caso de la versión anterior.
                if (tieneAriges == null) tieneAriges = "S";
                if (tieneAriges == "S")
                    ctx0 = new ArigesContext("arigesEntity");



                string tieneGdes = ConfigurationSettings.AppSettings["TieneGdes"];
                if (tieneGdes == null) tieneGdes = "N";
                if (tieneGdes == "S")
                    ctx5 = new GdesModelo("GdesConnection");


                string tieneArigasol = ConfigurationSettings.AppSettings["TieneArigasol"];
                if (tieneArigasol == null) tieneArigasol = "N"; 
                if (tieneArigasol=="S")
                    ctx2 = new AriGasolContext("arigasolEntity");


                string tieneAriagro = ConfigurationSettings.AppSettings["TieneAriagro"];
                if (tieneAriagro == null) tieneArigasol = "N"; 
                if (tieneAriagro=="S")
                    ctx3 = new AriAgroCtx("Ariagro4Connection");

                string tieneTeleTaxi = ConfigurationSettings.AppSettings["TieneTeleTaxi"];
                if (tieneTeleTaxi == null) tieneTeleTaxi = "N";
                if (tieneTeleTaxi == "S")
                    ctx4 = new AriTaxiContext("AritaxiConnection");
        
                
                string dosArigesDistintos = ConfigurationSettings.AppSettings["DosArigesDistintos"];
                if (dosArigesDistintos == null) dosArigesDistintos = "N"; 
                if (dosArigesDistintos=="S")
                    ctx0_2 = new ArigesContext("arigesDos");

            }
            catch(Exception ex)
            {
                LogOrConsole(String.Format("Fallo conexión: {0}", ex.Message),4);
            }

            // start ftp 
            try
            {

                //Si al final del proceso hace FTP o lo copia todo en un repositorio
                string enviarFTP = ConfigurationSettings.AppSettings["EnviarAlFtp"];
                if (enviarFTP == null) enviarFTP = "N";
                if (enviarFTP.ToUpper().Equals("S"))
                {
                    ftp = new FTP();
                    InitFtp(ftp);
                }
            }
            catch (Exception ex)
            {
                LogOrConsole(String.Format("Fallo inicialización FTP: {0}", ex.Message),4);
            }

            // start message.
            message = String.Format("Start AriFacEleWis (CntWis)", DateTime.Now);
            LogOrConsole(message,1);
        }
        
        public static void myOnStop()
        {
            // stop message.
            message = String.Format("Stop AriFacEleWis (CntWis)", DateTime.Now);
            LogOrConsole(message,1);
        }

        public static void LogOrConsole(string message, int type)
        {
            EventLogEntryType eletype = EventLogEntryType.SuccessAudit;
            switch (type)
            {
                case 1:
                    eletype = EventLogEntryType.SuccessAudit;
                    break;
                case 2:
                    eletype = EventLogEntryType.Information;
                    break;
                case 3:
                    eletype = EventLogEntryType.Warning;
                    break;
                case 4:
                    eletype = EventLogEntryType.Error;
                    break;
            }
            if (logAvailabel)
                EventLog.WriteEntry(sSource, message, eletype);
            else
            {
                Console.WriteLine(message);
                Console.ReadLine();
            }
        }

        public static void registrarFactura(string fichero, string sourceFile)
        {
            /*
                Los archvos vendran con el nombre:
                ariagro4_B_18_20130130
                aplicac 
                letra serie
                         nºfact
                                fecha formato yyyymmdd
            */
            if (!fichero.Split('.')[1].ToUpper().Equals("PDF"))
                throw new FormatException("El archivo " + fichero + ", tiene un formato no válido, no es PDF");



            //Si al final del proceso hace FTP o lo copia todo en un repositorio
            string enviarFTP = ConfigurationSettings.AppSettings["EnviarAlFtp"];
            // asumimos que si el parámetro no está presente significa que no
            if (enviarFTP == null) enviarFTP = "N"; 

            //identificamos la factura obteniendo los datos del nombre del fichero.
            string[] datos = fichero.Split('_');
            string bd = datos[0];
            string numSerie = datos[1];     // Para aritaxi, para las facturas de socio va format(codsocio,"000000") + letraser

            int numfact = 0;
            string stfecha = "";
            DateTime fecha = DateTime.Now;

            // este cuidado es ahora necesario porque en el caso de GDES hay sólo dos elementos
            if (datos.Count() > 2)
            {
                numfact = int.Parse(datos[2]);
                stfecha = datos[3].Split('.')[0];
                fecha = new DateTime(int.Parse(stfecha.Substring(0, 4)), int.Parse(stfecha.Substring(4, 2)), int.Parse(stfecha.Substring(6, 2)));
            }
            else
            {
                // caso GDES el número de serie hay que cortarlo porque nos llevamos el ".pdf"
                numSerie = datos[1].Split('.')[0];
            }

            // identificamos el sistema al que pertenece la base de datos.
            Sistema sistema = CntLib.getSistema(bd, ctx1);
            if (sistema == null)
            {
                LogOrConsole(String.Format("El sistema correspondiente a la bd {0} no está dado de alta", bd), 3);
                return;
            }

             // Ariges No tendra nada,
             //ariagro y aritaxi      F: Fra cliente,    S:   Socio    
             // + el codtipomn real  --> NO hara falta ir a la stipom
            string letraDeFactura = "";
            string codtipomParaAriagroTaxi = "";

            if (datos.Count() > 4)
            {

                //Sigifica que detras de la fecha trae el     S socio    F cliente
                //
                // Guardaremos las facturas las de cliente NORMAL pero las de socio añadiremos un S al final
                string letra = datos[4].Substring(0,1).ToUpper();  //COGEMOS EL PRIMER CARCTER
                
                if (letra.IndexOf("SF")==0)
                    letraDeFactura = "";
                else
                {
                    letraDeFactura = letra;
                }
                

                //Abril 2013 ,El dia de mi cumpleaños ;)
                //Ademas ded la letra envia tb eL codtipom
                if (datos[4].Length > 1) codtipomParaAriagroTaxi = datos[4].Substring(1,3);   //codtipom len=3


                //Haremos un raise si, letra o codtipom=''
                if (codtipomParaAriagroTaxi == "" || letraDeFactura == "")
                {
                    codtipomParaAriagroTaxi = "Error obteneindo letra/codtipom para S-F " + codtipomParaAriagroTaxi + " / " + letraDeFactura;
                    LogOrConsole(String.Format("El sistema correspondiente a la bd {0} no está dado de alta", bd), 3);
                    return;
                }

            }


            switch (sistema.Nombre)
            {
                case "AriGes":
                    empresa = CntLib.getEmpresaArigesByDB(ctx0, ctx1);
                    break;
                case "AriGasol":
                    empresa = CntLib.getEmpresaArigasolByDB(ctx2, ctx1);
                    break;
                //David
                case "AriAgro":
                    empresa = CntLib.getEmpresaAriagroByDB (ctx3, ctx1);
                    break;
                case "AriGesDos":
                    empresa = CntLib.getEmpresaArigesByDB(ctx0_2, ctx1);
                    break;
                case "AriTaxi":
                    empresa = CntLib.getEmpresaAriTaxiyDB(ctx4, ctx1);
                    break;
                case "GDES":
                    empresa = CntLib.getEmpresaGdesByDB(ctx5, ctx1);
                    break;
                default:
                    break;
            }

            string repositorioLocal = System.IO.Path.GetDirectoryName(sourceFile);
            
            string destFile = System.IO.Path.Combine(String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), fichero);
            //Si la ruta destino no existe la creamos
            if (!System.IO.Directory.Exists(String.Format(@"{0}\{1}\xml", repositorioLocal, empresa.Cif)))
            {
                System.IO.Directory.CreateDirectory(String.Format(@"{0}\{1}\xml", repositorioLocal, empresa.Cif));
            }

            //Ahora solo tiene la carpeta
            string xmlDestino = ctx1.Repositorios.FirstOrDefault<Repositorio>().Path;   //por si NO hace FTP, que hara un file copy sobre el repositorio
            //xmlDestino = "C:\\FicherosFacElectronicas";
            





            int idFactura = 0;
            int idSocio = 0;   //para las facturas de "proveedor".  El nombre lo genera con el codigo de socio
            switch (sistema.Nombre)
            {
                case "AriGes":
                    idFactura = CntLib.GuardarFacturaAriGes(true,numSerie, numfact, fecha, empresa, ctx0, ctx1, sistema);
                    break;
                case "AriGesDos":
                    idFactura = CntLib.GuardarFacturaAriGes(false, numSerie, numfact, fecha, empresa, ctx0_2, ctx1, sistema);
                    break;
                
                case "AriGasol":
                    idFactura = CntLib.GuardarFacturaAriGasol(numSerie, numfact, fecha, empresa, ctx2, ctx1, sistema);
                    break;

                case "GDES":
                    idFactura = CntLib.GuardarFacturaGdes(numSerie, empresa, ctx5, ctx1, sistema);
                    break;

                
                case "AriAgro":
                    switch (letraDeFactura)
                    {
                        case "F":
                            //Facturas de clientes normales de ariagro
                            idFactura = CntLib.FacturaAriAgroCliente(numSerie, numfact, fecha, empresa, ctx3, ctx1, sistema, codtipomParaAriagroTaxi);
                            break;
                        case "S":
                                //Facturas de socios. Son en preoveedores
                            idFactura = CntLib.FacturaAriAgroSocio(numSerie, numfact, fecha, empresa, ctx3, ctx1, sistema, ref(idSocio), codtipomParaAriagroTaxi);
                            break;

                        default :
                            //habra que lanzar un raise
                            break;
                    }
                    break;

                case "AriTaxi":
                    /*    FALTA.      codtipomParaAriagroTaxi  codtipomParaAriagroTaxi codtipomParaAriagroTaxi   */ 
                    switch (letraDeFactura)
                    {
                        case "F":
                            //Facturas de clientes normales 
                            idFactura = CntLib.FacturaAriTaxiCliente(numSerie, numfact, fecha, empresa, ctx4, ctx1, sistema);
                            break;
                        case "S":
                            //Facturas de socios. Son en preoveedores
                            //En numerie traera 
                            idFactura = CntLib.FacturaAriTaxiSocio(numSerie, numfact, fecha, empresa, ctx4, ctx1, sistema, ref(idSocio));
                            break;
                        case "C":
                            //Cuotas de socios
                            idFactura = CntLib.FacturaAriTaxiCuotas(numSerie, numfact, fecha, empresa, ctx4, ctx1, sistema);
                            break;

                        default:
                            //habra que lanzar un raise
                            break;
                    }
                     

                    break;


                default:
                    break;
            }



            // ************************************************************************************************************************************
            //TipoFactura llevara una letra o "". Si es letra sera para id. del tipo fra socios
            //
            // Si cambiamos algo aqui hay que:
            //      1.- Mantener la compatibilidad con lo que habia (ariges, arigasol...
            //      2.- Cambia el metodo: DevuelveNombreFichero
            // ************************************************************************************************************************************
            //  Este trozo estaba, antes de 11-Abril-2013, por arriba de la generacion de factura, y no tenia lo del socio para las  
            string nombreficherodestino;
            string nombreficherodestinoXML;
            string nombreficherodestinoXSIG;
            bool hayFirma = false;
            if (letraDeFactura == "S")
            {
                string SerieSocio;
                if (sistema.Nombre == "AriAgro")
                    SerieSocio = string.Format(@"{0:000000}{1}", idSocio, numSerie);
                else
                   SerieSocio=numSerie ;



                nombreficherodestino = String.Format(@"{0}{1}_{2:00}{3:0000}{4}.pdf", SerieSocio, numfact, fecha.Month, fecha.Year, letraDeFactura);
            }
            else
                nombreficherodestino = String.Format(@"{0}{1}_{2:00}{3:0000}{4}.pdf", numSerie, numfact, fecha.Month, fecha.Year, letraDeFactura);

            // el caso de GDES es especial porque ya incluye una referencia única
            if (sistema.Nombre == "GDES")
            {
                nombreficherodestino = String.Format(@"{0}_{1}.pdf", sistema.Nombre, numSerie);
            }
            
            // Hay que leer la factura para sacar el sistema (GDES)
            DatosFacturaLib.Factura factura = (from f in ctx1.Facturas
                                               where f.Id_factura == idFactura
                                               select f).FirstOrDefault<DatosFacturaLib.Factura>();
            string sistemaGdes = "";
            if (factura != null && factura.SistemaGdes != null)
            {
                sistemaGdes = factura.SistemaGdes;
            }
            string iban = factura.Cliente.Iban;
            if (iban == null) iban = "";
            string ficheroDest = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(destFile), nombreficherodestino);
            string ficheroDestCopy = ctx1.Repositorios.FirstOrDefault<Repositorio>().Path;   //por si NO hace FTP, que haga un file copy sobre el repositorio
            //ficheroDestCopy = "C:\\FicherosFacElectronicas";
            ficheroDestCopy = System.IO.Path.Combine(ficheroDestCopy, nombreficherodestino);

            string firmar = ConfigurationSettings.AppSettings["Firmar"];   //Esta firma es meter el bmp en el pdf
            if (firmar.ToUpper().Equals("S"))
                firmarFactura(sourceFile, destFile, sistemaGdes, empresa);
            else
                System.IO.File.Copy(sourceFile, destFile, true);
            if (firmar.ToUpper().Equals("S")) hayFirma = true;

            // obtener la factura a partir de su identificador
            DatosFacturaLib.Factura fac = (from f in ctx1.Facturas
                                           where f.Id_factura == idFactura
                                           select f).FirstOrDefault<DatosFacturaLib.Factura>();


            string FicheroXml = "";
            string FicheroXSIG = "";
            switch (sistema.Nombre)
            {
                case "AriGes":
                    FicheroXml = oFacturae.generarFacturaeAriGes(iban, fecha, firma, numfact, numSerie, String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), ctx0, ctx1);
                    if (firmar.ToUpper().Equals("S")) FicheroXSIG = FicheroXml.Replace(".xml", ".xsig");
                    break;
                case "AriGesDos":
                    FicheroXml = oFacturae.generarFacturaeAriGes(iban, fecha, firma, numfact, numSerie, String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), ctx0_2, ctx1);
                    if (firmar.ToUpper().Equals("S")) FicheroXSIG = FicheroXml.Replace(".xml", ".xsig");
                    break;
                case "AriGasol":
                    FicheroXml = oFacturae.GenerarFacturaeAriGasol(iban, fecha, firma, numfact, numSerie, String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), ctx2, ctx1);
                    if (firmar.ToUpper().Equals("S")) FicheroXSIG = FicheroXml.Replace(".xml", ".xsig");
                    break;
                case "AriTaxi":
                    FicheroXml = oFacturae.generarFacturaeAriTaxi(iban, fecha, firma, numfact, numSerie, letraDeFactura, String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), ctx4, ctx1);
                    if (firmar.ToUpper().Equals("S")) FicheroXSIG = FicheroXml.Replace(".xml", ".xsig");
                    break;
                case "GDES":
                    FicheroXml = oFacturae.generarFacturaeGdes(fecha, firma, numSerie, String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif),fac.SistemaGdes, ctx5, ctx1);
                    if (firmar.ToUpper().Equals("S")) FicheroXSIG = FicheroXml.Replace(".xml", ".xsig");
                    break;
                case "AriAgro":
                    //No hacemos, de momento, la facturae
                    //FicheroXml = oFacturae.generarFacturaeAriGasol(fecha, firma, numfact, numSerie, String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), ctx2, ctx1);
                   
                    break;
                default:
                    break;
            }



                  
            if (enviarFTP.ToUpper().Equals("S"))
            {
                System.IO.File.Copy(destFile,  ficheroDest, true);
                System.IO.File.Delete(destFile);

                //subimos los ficheros al servidor
                UpLoadInvoice(ficheroDest, ftp);

                if (FicheroXml!="")
                    UpLoadInvoice(FicheroXml, ftp);
                if (FicheroXSIG != "")
                    UpLoadInvoice(FicheroXSIG, ftp);
            }
            else
            {

                //PDF
                System.IO.File.Copy(destFile, ficheroDestCopy, true);
                System.IO.File.Delete(destFile);

                if (FicheroXml != "")
                {
                    //Hya que copiar el XML
                    nombreficherodestinoXML = nombreficherodestino.Replace(".pdf", ".xml");
                    ficheroDestCopy = System.IO.Path.Combine(xmlDestino, nombreficherodestinoXML);
                    System.IO.File.Copy( FicheroXml,  ficheroDestCopy, true);
                    System.IO.File.Delete(FicheroXml);
                }
                if (FicheroXSIG != "")
                {
                    //Hay que copiar el XSIG (firmado)
                    nombreficherodestinoXSIG = nombreficherodestino.Replace(".pdf", ".xsig");
                    ficheroDestCopy = System.IO.Path.Combine(xmlDestino, nombreficherodestinoXSIG);
                    System.IO.File.Copy(FicheroXSIG, ficheroDestCopy, true);
                    System.IO.File.Delete(FicheroXSIG);
                }
                 
            }
        }

        public static void firmarFactura(string sourceFile, string destFile, string sistemaGdes, DatosFacturaLib.Empresa empresa)
        {
            firma = new Firma();

            string _certificado;
            string _passcert;
            string _pathimagen;
            FirmaPDF.FirmaPDF f = new FirmaPDF.FirmaPDF();
            if (sistemaGdes != "")
            {
                f.certificado = String.Format(ConfigurationSettings.AppSettings["Certificado_path"], sistemaGdes);
            }
            else
            {
                f.certificado = ConfigurationSettings.AppSettings["Certificado_path"];
                _certificado = ConfigurationSettings.AppSettings[empresa.Cif + "_path"];
                if (_certificado != null)
                {
                    f.certificado = _certificado;
                }
            }
            firma.Certificado_path = f.certificado;
            if (sistemaGdes != "")
            {
                f.passCert = Decrypt(ConfigurationSettings.AppSettings["Certificado_pass"]);
            }
            else
            {
                f.passCert = ConfigurationSettings.AppSettings["Certificado_pass"];
                _passcert = ConfigurationSettings.AppSettings[empresa.Cif + "_pass"];
                if (_passcert != null)
                {
                    f.passCert = _passcert;
                }
            }
            firma.Certificado_pass = f.passCert;

            f.firmado = destFile;
            f.original = sourceFile;

            f.location = ConfigurationSettings.AppSettings["Lugar"];
            f.pathImagen = ConfigurationSettings.AppSettings["Logo_path"];
            _pathimagen = ConfigurationSettings.AppSettings[empresa.Cif + "_Logo_path"];
            f.reason = ConfigurationSettings.AppSettings["Motivo"];
            f.posicion = new Rectangle(int.Parse(ConfigurationSettings.AppSettings["Posicion_x0"]), int.Parse(ConfigurationSettings.AppSettings["Posicion_y0"]), int.Parse(ConfigurationSettings.AppSettings["Posicion_x_x"]), int.Parse(ConfigurationSettings.AppSettings["Posicion_y_y"]));
            f.visualizarFirma = true;

            //f.tsa = ConfigurationSettings.AppSettings["Tsa_url"];
            //f.usertsa = ConfigurationSettings.AppSettings["Tsa_user"];
            //f.passtsa = ConfigurationSettings.AppSettings["Tsa_pass"];

            try
            {
                f.Firma();
            }
            catch (Exception e)
            { throw new Exception("Error al firmar:" + destFile + "\n\n" + e.StackTrace); }
        }

        public static void MarkAsConsole()
        {
            logAvailabel = false;
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

    }
}
