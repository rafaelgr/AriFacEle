using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using FirmaLib;

using AriFacElec;
using AriGasolModel;
using AriAgroModel;
using AriTaxiModel;
using DatosFacturaLib;
using FacturaE;
using System.Security.Cryptography;



namespace AriFacEleWiS
{
    public static class oFacturae
    {
        private static String TRUSTER_NAME = "my";
        private static String URL_OCSP = "http://myocspserver:81";
        private static String URL_TSA = "http://tsa.safelayer.com:8093";
        private static Certificado certificado;

        private static String ficheroXML = @"c:\temp\FacturaE.xml";
        private static String ficheroXSIG = @"c:\temp\FacturaE.xsig";
        private static String Firmado;
        private static String SinFirmar;

        // encriptación
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public static string generarFacturaeGdes(DateTime fecha, DatosFacturaLib.Firma firma, string gdesRef, string pathDest, string sistemaGdes, GdesModelo ctx5, FacturaEntity ctx1)
        {
            CntFacturacion cf = new CntFacturacion();

            Cau_FIN_FACEInvoiceHeader gdesHeader = (from h in ctx5.Cau_FIN_FACEInvoiceHeaders
                                                    where h.ID == gdesRef
                                                    select h).FirstOrDefault<Cau_FIN_FACEInvoiceHeader>();

            Facturae facturasE = cf.GenerarFacturaGdes(gdesHeader, ctx5);

            //Crear fichero FacturaE
            XmlSerializer serializer = new XmlSerializer(typeof(Facturae));
            FileStream fs = new FileStream(ficheroXML, FileMode.Create);
            serializer.Serialize(fs, facturasE);
            fs.Close();

            SinFirmar = String.Format(@"{0}\xml\{1}_{2}.xml", pathDest, "GDES", gdesRef);
            Firmado = String.Format(@"{0}\xml\{1}_{2}.xsig", pathDest, "GDES", gdesRef);

            System.IO.File.Copy(ficheroXML, SinFirmar, true);

            string firmar = ConfigurationSettings.AppSettings["Firmar"];
            if (firmar.ToUpper().Equals("S"))
            {
                //Firmar fichero
                certificado = new Certificado();
                //if (sistemaGdes != "")
                //{
                //    certificado.PathCertificado = String.Format(firma.Certificado_path, sistemaGdes);
                //    certificado.Pass = Decrypt(firma.Certificado_pass);
                //}
                //else
                //{
                //    certificado.PathCertificado = firma.Certificado_path;
                //    certificado.Pass = firma.Certificado_pass;
                //}
                // si es GDES ya vienen los campos bien
                certificado.PathCertificado = firma.Certificado_path;
                certificado.Pass = firma.Certificado_pass;
                FirmarConEPES();
            }

            return SinFirmar;
        }


        public static string generarFacturaeAriGes(string iban, DateTime fecha, DatosFacturaLib.Firma firma, int numFactura, string letra, string pathDest, ArigesContext ctx0, FacturaEntity ctx1)
        {
            CntFacturacion cf = new CntFacturacion();

            string codTipom = FacturaE.CntFacturacion.getCodtipom(letra, ctx0);
            Scafac fac = (from f in ctx0.Scafacs
                          where numFactura == f.Numfactu && f.Codtipom == codTipom && f.Fecfactu == fecha
                          select f).FirstOrDefault<Scafac>();

            Facturae facturasE = cf.GenerarFacturaAriGes(fac, ctx0, iban);

            //Crear fichero FacturaE
            XmlSerializer serializer = new XmlSerializer(typeof(Facturae));
            FileStream fs = new FileStream(ficheroXML, FileMode.Create);
            serializer.Serialize(fs, facturasE);
            fs.Close();

            SinFirmar = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xml", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);
            Firmado = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xsig", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);

            System.IO.File.Copy(ficheroXML, SinFirmar, true);

            string firmar = ConfigurationSettings.AppSettings["Firmar"];
            if (firmar.ToUpper().Equals("S"))
            {
                //Firmar fichero
                certificado = new Certificado();
                certificado.PathCertificado = firma.Certificado_path;
                certificado.Pass = firma.Certificado_pass;
                FirmarConEPES();
            }

            return SinFirmar;
        }

        public static string generarFacturaeAriTaxi(DateTime fecha, DatosFacturaLib.Firma firma, int numFactura, string letra, string pathDest, AriTaxiContext ctx0, FacturaEntity ctx1)
        {
            if (letra != "A" && letra != "B" && letra != "P") return ""; // solo procesamos de todos los tipos los de factura de cliente
            CntFacturacion cf = new CntFacturacion();

            string codTipom = FacturaE.CntFacturacion.getCodtipom(letra, ctx0);
            uint nfac = (uint)numFactura;
            Scafaccli fac = (from f in ctx0.Scafacclis
                             where f.Numfactu == nfac && f.Codtipom == codTipom && f.Fecfactu == fecha
                             select f).FirstOrDefault<Scafaccli>();

            Facturae facturasE = cf.GenerarFacturaAriTaxi(fac, ctx0);

            //Crear fichero FacturaE
            XmlSerializer serializer = new XmlSerializer(typeof(Facturae));
            FileStream fs = new FileStream(ficheroXML, FileMode.Create);
            serializer.Serialize(fs, facturasE);
            fs.Close();

            SinFirmar = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xml", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);
            Firmado = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xsig", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);

            System.IO.File.Copy(ficheroXML, SinFirmar, true);

            string firmar = ConfigurationSettings.AppSettings["Firmar"];
            if (firmar.ToUpper().Equals("S"))
            {
                //Firmar fichero
                certificado = new Certificado();
                certificado.PathCertificado = firma.Certificado_path;
                certificado.Pass = firma.Certificado_pass;
                FirmarConEPES();
            }

            return SinFirmar;
        }





        public static string GenerarFacturaeAriGasol(string iban, DateTime fecha, DatosFacturaLib.Firma firma, int numFactura, string letra, string pathDest, AriGasolContext ctx2, FacturaEntity ctx1)
        {
            CntFacturacion cf = new CntFacturacion();

            //char l = letra[0];
            Schfac fac = (from f in ctx2.Schfacs
                          where f.Numfactu == numFactura && f.Letraser == letra && f.Fecfactu == fecha
                          select f).FirstOrDefault<Schfac>();

            Facturae facturasE = cf.GenerarFacturaAriGasol(fac, ctx2, iban);

            //Crear fichero FacturaE
            XmlSerializer serializer = new XmlSerializer(typeof(Facturae));
            FileStream fs = new FileStream(ficheroXML, FileMode.Create);
            serializer.Serialize(fs, facturasE);
            fs.Close();

            SinFirmar = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xml", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);
            Firmado = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xsig", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);
            System.IO.File.Copy(ficheroXML, SinFirmar, true);

            string firmar = ConfigurationSettings.AppSettings["Firmar"];
            if (firmar.ToUpper().Equals("S"))
            {
                //Firmar fichero
                certificado = new Certificado();
                certificado.PathCertificado = firma.Certificado_path;
                certificado.Pass = firma.Certificado_pass;
                FirmarConEPES();
            }

            return SinFirmar;
        }



        /*
        public static string GenerarFacturaeAriAgro(DateTime fecha, DatosFacturaLib.Firma firma, int numFactura, string letra, string pathDest, AriAgroCtx ctx0, FacturaEntity ctx1)
        {
            CntFacturacion cf = new CntFacturacion();


            //string codTipom = FacturaE.CntFacturacion.getCodtipom(letra, ctx0);
            string codTipom = CntLib.GetAriagroCodtipom(letra, ctx0, ctx1);
            
            Scafac fac = (from f in ctx0.Scafacs
                          where numFactura == f.Numfactu && f.Codtipom == codTipom && f.Fecfactu == fecha
                          select f).FirstOrDefault<Scafac>();

            Facturae facturasE = cf.GenerarFacturaAriGes(fac, ctx0);

            //Crear fichero FacturaE
            XmlSerializer serializer = new XmlSerializer(typeof(Facturae));
            FileStream fs = new FileStream(ficheroXML, FileMode.Create);
            serializer.Serialize(fs, facturasE);
            fs.Close();

            Firmado = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xml", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);

            string firmar = ConfigurationSettings.AppSettings["Firmar"];
            if (firmar.ToUpper().Equals("S"))
            {
                //Firmar fichero
                certificado = new Certificado();
                certificado.PathCertificado = firma.Certificado_path;
                certificado.Pass = firma.Certificado_pass;
                FirmarConEPES();
            }
            else
            {
                System.IO.File.Copy(ficheroXML, Firmado, true);
            }

            return Firmado;
        }

        */


        private static void FirmarConEPES()
        {
            FirmaEPES f = new FirmaEPES();
            f.PathFicheroEntrada = ficheroXML;
            f.PathFicheroFirmado = Firmado;
            f.Certificado = certificado;
            if (!f.Firmar())
                throw new Exception("Error: No se ha podido generar la firma para el fichero facturaE");
        }

        private static void FirmarConT()
        {
            FirmaT fT = new FirmaT();
            fT.Certificado = certificado;
            fT.Ts = URL_TSA;
            fT.PathFicheroEntrada = ficheroXML;
            fT.PathFicheroFirmado = Firmado;
            if (!fT.Firmar())
                throw new Exception("Error: No se ha podido generar la firma para el fichero facturaE");
        }

        private static void FirmarConC()
        {
            FirmaC fC = new FirmaC();
            fC.Certificado = certificado;
            fC.Oscp = URL_OCSP;
            fC.Truster = TRUSTER_NAME;
            fC.Ts = URL_TSA;
            fC.PathFicheroEntrada = ficheroXML;
            fC.PathFicheroFirmado = Firmado;
            if (!fC.Firmar())
                throw new Exception("Error: No se ha podido generar la firma para el fichero facturaE");
        }

        private static void FirmarConXL()
        {
            FirmaXL fXL = new FirmaXL();
            fXL.Certificado = certificado;
            fXL.OCSP = URL_OCSP;
            fXL.Truster = TRUSTER_NAME;
            fXL.TS = URL_TSA;
            fXL.PathFicheroEntrada = ficheroXML;
            fXL.PathFicheroFirmado = Firmado;
            if (!fXL.Firmar())
                throw new Exception("Error: No se ha podido generar la firma para el fichero facturaE");
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
