using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriFtp;
using System.Configuration;
using System.Text.RegularExpressions;
using DatosFacturaLib;

namespace AriFacEleWiS
{
    public static partial class CntWiS
    {
        public static void InitFtp(FTP ftp)
        {
            ftp.server = ConfigurationSettings.AppSettings["ftp_server"];
            ftp.port = int.Parse(ConfigurationSettings.AppSettings["ftp_port"]);
            ftp.user = ConfigurationSettings.AppSettings["ftp_usr"];
            ftp.pass = ConfigurationSettings.AppSettings["ftp_pass"];
            //ftp.PassiveMode = false;
            try
            {
                ftp.ChangeDir(ConfigurationSettings.AppSettings["ftp_dir"]);
            }
            catch (Exception e)
            {
                LogOrConsole(String.Format("No existe el directorio, se creará por defecto: {0}",e.Message),3);
                ftp.MakeDir(ConfigurationSettings.AppSettings["ftp_dir"]);
            }

        }
        public static void CopyFiles()
        {
            string fileName = "";
            bool notificar = false;
            int numfacturas = 0;
            string sourcePath = ConfigurationSettings.AppSettings["Source_Path"];
            if (ConfigurationSettings.AppSettings["notificar"] == "S") notificar = true;
            //comprobamos que existe el directorio origen
            if (System.IO.Directory.Exists(sourcePath))
            {
                //obtenemos los ficheros a procesar
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                if (files.Count() > 0 )
                    LogOrConsole("Registrando facturas: " + files.Length + " ficheros.",2);
                //copiamos o sobreescribimos los ficheros que se encuentran en el directorio origen
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    try
                    {
                        LogOrConsole(String.Format("Procesando {0} --> ",fileName),2);
                        registrarFactura(fileName, s);
                        System.IO.File.Delete(s);
                        LogOrConsole(String.Format("--> {0} Procesado ", fileName), 2);
                        numfacturas++;
                    }
                    catch (Exception e)
                    {
                        LogOrConsole(e.Message,4);
                    }
                }
            }
            else
            {
                LogOrConsole("El directorio origen no existe",3);
            }
            try
            {
                if (notificar && numfacturas > 0)
                {
                    // abrir la conexión
                    FacturaEntity ctx = new FacturaEntity("FacturaEntity");
                    Plantilla p = CntLib.getPlantilla(2, ctx);
                    EmailGen email = new EmailGen();
                    email.MadarEmailGen("[ARIFACE] Facturas disponibles", String.Format(p.Contenido, numfacturas));

                }
            }
            catch (Exception e)
            {
                LogOrConsole(e.Message, 4);
            }

        }
        public static void UpLoadInvoice(string command, FTP ftp)
        {
            string file = Regex.Replace(command, "put ", "");

            if (!ftp.IsConnected)
            {
                InitFtp(ftp);
            }
            // open an upload
            ftp.OpenUpload(file, System.IO.Path.GetFileName(file));
            while (ftp.DoUpload() > 0) { }
        }
    }
}
