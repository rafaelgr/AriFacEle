using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

namespace FirmaLib
{
    public class FirmaXL:Firma
    {
        #region propiedades
        private string ts;

        public string TS
        {
            get { return ts; }
            set { ts = value; }
        }
        private string ocsp;

        public string OCSP
        {
            get { return ocsp; }
            set { ocsp = value; }
        }
        private string truster;

        public string Truster
        {
            get { return truster; }
            set { truster = value; }
        }
        #endregion
       
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
                DataToSign dataToSign = createDataToSign();

                //Firmar------------------------------------------------------------------------------------  
                FirmaXML fx = createFirmaXML();

                Object[] res = fx.signFile(certificate, dataToSign, privateKey, provider);
                Document docSigned = dataToSign.getDocument();
                
                //Guardar el fichero firmado----------------------------------------------------------------  
                FileOutputStream outputStream = new FileOutputStream(this.PathFicheroFirmado);
                UtilidadTratarNodo.saveDocumentToOutputStream((Document)res[0], outputStream, true);
                outputStream.close();

                return true;

            }
            return false;
        }

        private DataToSign createDataToSign()
        {
            FileInputStream fichero = new java.io.FileInputStream(this.PathFicheroEntrada);
            DataToSign dataToSign = new DataToSign();
            dataToSign.setXadesFormat(EnumFormatoFirma.XAdES_XL);
            dataToSign.setXAdESXType(DataToSign.XADES_X_TYPES.TYPE_1);
            //Política de firma (Con las librerías JAVA, esto se define en tiempo de ejecución)---------  
            TrustAbstract truster = TrustFactory.getInstance().getTruster(this.truster);
            if (truster == null) throw new Exception("No se ha encontrado el validador de confianza");

            dataToSign.setCertStatusManager(new OCSPLiveConsultant(this.ocsp, truster));
            dataToSign.setEsquema(XAdESSchemas.XAdES_132);
            dataToSign.setXMLEncoding("UTF-8");
            dataToSign.setEnveloped(true);
            dataToSign.addObject(new ObjectToSign(new AllXMLToSign(), "Documento de ejemplo", null, "text/xml", null));
            Document docToSign = parseaDoc(fichero);
            dataToSign.setDocument(docToSign);
            return dataToSign;
        }

        private FirmaXML createFirmaXML()
        {
            FirmaXML firmaXML = new FirmaXML();// createFirmaXML();
            firmaXML.setTSA(this.ts);
            return firmaXML;
        }

        private Document parseaDoc(InputStream fichero)
        {

            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            dbf.setNamespaceAware(true);

            DocumentBuilder db = null;
            try
            {
                db = dbf.newDocumentBuilder();
            }
            catch (ParserConfigurationException ex)
            {
                //MessageBox.Show("Error interno al parsear la firma");
                //ex.printStackTrace();
                //return null;
            }

            Document doc = null;
            try
            {
                doc = db.parse(fichero);
                return doc;
            }
            catch (org.xml.sax.SAXException ex)
            {
                doc = null;
            }
            catch (java.io.IOException ex)
            {
                //MessageBox.Show("Error interno al validar firma");
                //ex.printStackTrace();
            }
            finally
            {
                dbf = null;
                db = null;
            }

            return null;
        }

        
    }
}
