using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using FirmaLib;

using AriFacElec;
using DatosFacturaLib;
using FacturaE;



namespace AriFacSrv
{
    public static class oFacturae
    {
        private static String TRUSTER_NAME = "my";
        private static String URL_OCSP = "http://myocspserver:81";
        private static String URL_TSA = "http://tsa.safelayer.com:8093";
        private static Certificado certificado;

        private static String ficheroXML = @"c:\temp\FacturaE.xml";
        private static String Firmado;

        public static string generarFacturae(DatosFacturaLib.Firma firma, int numFactura, string letra, string pathDest, ArigesContext ctx0, FacturaEntity ctx1)
        {
            CntFacturacion cf = new CntFacturacion();

            string codTipom = FacturaE.CntFacturacion.getCodtipom(letra, ctx0);
            Scafac fac = (from f in ctx0.Scafacs
                                where numFactura == f.Numfactu && f.Codtipom == codTipom
                          select f).FirstOrDefault<Scafac>();

            Facturae facturasE = cf.GenerarFactura(fac, ctx0);

            //Crear fichero FacturaE
            XmlSerializer serializer = new XmlSerializer(typeof(Facturae));
            FileStream fs = new FileStream(ficheroXML, FileMode.Create);
            serializer.Serialize(fs, facturasE);
            fs.Close();

            //Firmar fichero
            certificado = new Certificado();
            certificado.PathCertificado = firma.Certificado_path;
            certificado.Pass = firma.Certificado_pass;

            Firmado = String.Format(@"{0}\xml\{1}{2}_{3:00}{4:0000}.xml", pathDest, letra, numFactura, fac.Fecfactu.Month, fac.Fecfactu.Year);

            FirmarConEPES();

            return Firmado;
        }

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
    }

}
