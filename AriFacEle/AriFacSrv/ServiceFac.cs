using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using AriFacElec;
using DatosFacturaLib;
using AriFtp;
using System.Configuration;
using System.Drawing;

namespace AriFacSrv
{
    public partial class ServiceFac : ServiceBase
    {
        static string sourcePath;

        static ArigesContext ctx0;
        static FacturaEntity ctx1;
        EventLog eventLog1;
        static FTP ftp;
        private Empresa empresa;
        public System.Timers.Timer myTimer;
        DatosFacturaLib.Firma firma;

        public ServiceFac()
        {
            InitializeComponent();

            string registro = "Application";
            string equipo = Environment.MachineName;
            string programa;

            programa = "AriFacEle";
            eventLog1 = new EventLog(registro, equipo, programa);

            ctx0 = new ArigesContext("arigesEntity");
            ctx1 = new FacturaEntity("FacturaEntity");
        }
        
        protected override void OnStart(string[] args)
        {
            //Arranca el servicio
            eventLog1.WriteEntry("AriFacEleSrv [Arranque del servicio]", EventLogEntryType.SuccessAudit);

            //obtenemos el directorio origen sobre el que el servicio consultara las facturas.
            sourcePath = ConfigurationSettings.AppSettings["Source_Path"];

            //instanciamos el FTP
            ftp = new FTP();
            InitFtp();

            //Timer para el control del tiempo entre llamadas.
            myTimer = new System.Timers.Timer();
            //Intervalo de tiempo entre llamadas.
            myTimer.Interval = 3000;
            //Evento a ejecutar cuando se cumple el tiempo.
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            //Habilitar el Timer.
            myTimer.Start();
        }

        protected override void OnStop()
        {
            // se detiene el servicio
            eventLog1.WriteEntry("AriFacEleSrv [Fin del servicio]", EventLogEntryType.SuccessAudit);
            //liberamos todos los recursos
            ctx0.Dispose();
            ctx1.Dispose();
            eventLog1 = null;
            ftp.Disconnect();
        }

        void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Detiene el Timer
            myTimer.Stop();
            //llama al Servicio
            CopyFiles();
            //habilita el Timer nuevamente.
            myTimer.Start();
        }


        private void CopyFiles()
        {
            string fileName = "";

            //comprobamos que existe el directorio origen
            if (System.IO.Directory.Exists(sourcePath))
            {
                //obtenemos los ficheros a procesar
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                eventLog1.WriteEntry("Registrando " + files.Length + " ficheros.", EventLogEntryType.Information);

                //copiamos o sobreescribimos los ficheros que se encuentran en el directorio origen
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    try
                    {
                        eventLog1.WriteEntry(fileName, EventLogEntryType.Information);
                        registrarFactura(fileName, s);
                        System.IO.File.Delete(s);
                        eventLog1.WriteEntry("Correcto.", EventLogEntryType.SuccessAudit);
                    }
                    catch (Exception e)
                    {
                        eventLog1.WriteEntry(e.Message, EventLogEntryType.Error);
                    }
                }
            }
            else
            {
                eventLog1.WriteEntry("El directorio origen no existe", EventLogEntryType.Warning);
            }

        }

        private void registrarFactura(string fichero, string sourceFile)
        {
            if (!fichero.Split('.')[1].ToUpper().Equals("PDF"))
                throw new FormatException("El archivo " + fichero + ", tiene un formato no válido");

            //identificamos la factura obteniendo los datos del nombre del fichero.
            string[] datos = fichero.Split('_');
            string bd = datos[0];
            string numSerie = datos[1];
            int numfact = int.Parse(datos[2]);
            string stfecha = datos[3].Split('.')[0];
            DateTime fecha = new DateTime(int.Parse(stfecha.Substring(0, 4)), int.Parse(stfecha.Substring(4, 2)), int.Parse(stfecha.Substring(6, 2)));

            empresa = CntLib.getEmpresaArigesByDB(ctx0, ctx1);

            string repositorioLocal = System.IO.Path.GetDirectoryName(sourceFile);

            string destFile = System.IO.Path.Combine(String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), fichero);
            //Si la ruta destino no existe la creamos
            if (!System.IO.Directory.Exists(String.Format(@"{0}\{1}\xml", repositorioLocal, empresa.Cif)))
            {
                System.IO.Directory.CreateDirectory(String.Format(@"{0}\{1}\xml", repositorioLocal, empresa.Cif));
            }
            string ficheroDest = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(destFile), String.Format(@"{0}{1}_{2:00}{3:0000}.pdf", numSerie, numfact, fecha.Month, fecha.Year));

            firmarFactura(sourceFile, destFile);
            int idFactura = CntLib.guardarFactura(numSerie, numfact, fecha, empresa, ctx0, ctx1);

            string FicheroXml = oFacturae.generarFacturae(firma, numfact, numSerie, String.Format(@"{0}\{1}", repositorioLocal, empresa.Cif), ctx0, ctx1);

            System.IO.File.Copy(destFile, ficheroDest, true);
            System.IO.File.Delete(destFile);

            //subimos los ficheros al servidor
            UpLoadInvoice(ficheroDest);
            UpLoadInvoice(FicheroXml);

        }

        #region[métodos FTP]
        public static void InitFtp()
        {
            ftp.server = ConfigurationSettings.AppSettings["ftp_server"];
            ftp.port = int.Parse(ConfigurationSettings.AppSettings["ftp_port"]);
            ftp.user = ConfigurationSettings.AppSettings["ftp_usr"];
            ftp.pass = ConfigurationSettings.AppSettings["ftp_pass"];
            try
            {
                ftp.ChangeDir(ConfigurationSettings.AppSettings["ftp_dir"]);
            }
            catch (Exception e)
            {
                ftp.MakeDir(ConfigurationSettings.AppSettings["ftp_dir"]);
            }

        }
        
        

        private void firmarFactura(string sourceFile, string destFile)
        {
            firma = new Firma();

            FirmaPDF.FirmaPDF f = new FirmaPDF.FirmaPDF();

            f.certificado = ConfigurationSettings.AppSettings["Certificado_path"];
            firma.Certificado_path = f.certificado;
            f.passCert = ConfigurationSettings.AppSettings["Certificado_pass"];
            firma.Certificado_pass = f.passCert;

            f.firmado = destFile;
            f.original = sourceFile;

            f.location = ConfigurationSettings.AppSettings["Lugar"];
            f.pathImagen = ConfigurationSettings.AppSettings["Logo_path"];
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
        private static void UpLoadInvoice(string command)
        {
            string file = Regex.Replace(command, "put ", "");

            if (!ftp.IsConnected)
            {
                InitFtp();
            }
            // open an upload
            ftp.OpenUpload(file, System.IO.Path.GetFileName(file));
            while (ftp.DoUpload() > 0) { }
        }
        #endregion


    }
}
