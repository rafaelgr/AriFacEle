using java.security;
using java.io;
using java.util;
using java.security.cert;
using javax.xml.parsers;

using es.mityc.javasign.pkstore;
using es.mityc.javasign.pkstore.keystore;
using es.mityc.javasign.trust;
using es.mityc.javasign.xml.xades.policy;
using es.mityc.firmaJava.libreria.xades;
using es.mityc.javasign.xml.refs;
using es.mityc.firmaJava.libreria.utilidades;
using es.mityc.javasign.certificate.ocsp;

using org.w3c.dom;
using sviudes.blogspot.com;
using System.IO;
using System;

namespace FirmaLib
{
    public class FirmaC:Firma
    {
        private string ts;
        private string truster;

        public string Truster
        {
            get { return truster; }
            set { truster = value; }
        }
        private string oscp;

        public string Oscp
        {
            get { return oscp; }
            set { oscp = value; }
        }

        public string Ts
        {
            get { return ts; }
            set { ts = value; }
        }

        public override bool Firmar()
        {
            PrivateKey privateKey;
            Provider provider;

            X509Certificate certificate = this.Certificado.LoadCertificate(out privateKey, out provider);

            //Si encontramos el certificado...  
            if (certificate != null)
            {
                ////Política de firma (Con las librerías JAVA, esto se define en tiempo de ejecución)---------  
                TrustFactory.instance = es.mityc.javasign.trust.TrustExtendFactory.newInstance();
                TrustFactory.truster = es.mityc.javasign.trust.MyPropsTruster.getInstance();
                PoliciesManager.POLICY_SIGN = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();
                PoliciesManager.POLICY_VALIDATION = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();

                //Crear datos a firmar----------------------------------------------------------------------  
                DataToSign dataToSign = createDataToSign_T();

                //Firmar------------------------------------------------------------------------------------  
                FirmaXML fx = createFirmaXML();

                Object[] res = fx.signFile(certificate, dataToSign, privateKey, provider);
                Document docSigned = dataToSign.getDocument();
                
                //Guardar el fichero firmado----------------------------------------------------------------  
                FileOutputStream outputStream = new FileOutputStream(PathFicheroFirmado);
                UtilidadTratarNodo.saveDocumentToOutputStream((Document)res[0], outputStream, true);
                outputStream.close();

                return true;
            }
            else
                return false;
        }
        private DataToSign createDataToSign_T()
        {
            DataToSign dataToSign = new DataToSign();
            dataToSign.setXadesFormat(EnumFormatoFirma.XAdES_C);
            // Validador de confianza de certificados
            TrustAbstract truster = TrustFactory.getInstance().getTruster(this.truster);
            if (truster == null) throw new Exception("No se ha encontrado el validador de confianza");
            
            // Se establece el validador OCSP a utilizar
            dataToSign.setCertStatusManager(new OCSPLiveConsultant(this.oscp, truster));
            dataToSign.setEsquema(XAdESSchemas.XAdES_132);
            dataToSign.setXMLEncoding("UTF-8");
            dataToSign.setEnveloped(true);
            // Da errror, desde que estuvimos mirando lo de Martin
            dataToSign.addObject(new ObjectToSign(new AllXMLToSign(), "Descripcion del documento", null, "text/xml", null));
           
           
            dataToSign.setDocument(LoadXML(PathFicheroEntrada));

            return dataToSign;
        }

        protected FirmaXML createFirmaXML()
        {
            FirmaXML firmaXML = new FirmaXML();
            firmaXML.setTSA(this.ts);
            return firmaXML;
        }
    }
}
