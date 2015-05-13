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
    public class FirmaEPES:Firma
    {
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
                DataToSign dataToSign = createDataToSign_EPES();

                //Firmar------------------------------------------------------------------------------------  
                FirmaXML fx = new FirmaXML();

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

        //public bool Firmar(X509Certificate certificate, string pass)
        //{
        //    PrivateKey privateKey;
        //    Provider provider;

        //    //X509Certificate certificate = this.Certificado.LoadCertificate(out privateKey, out provider);
            
        //    //Si encontramos el certificado...  
        //    if (certificate != null)
        //    {
        //        ////Política de firma (Con las librerías JAVA, esto se define en tiempo de ejecución)---------  
        //        TrustFactory.instance = es.mityc.javasign.trust.TrustExtendFactory.newInstance();
        //        TrustFactory.truster = es.mityc.javasign.trust.MyPropsTruster.getInstance();
        //        PoliciesManager.POLICY_SIGN = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();
        //        PoliciesManager.POLICY_VALIDATION = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();

        //        //Crear datos a firmar----------------------------------------------------------------------  
        //        DataToSign dataToSign = createDataToSign_EPES();

        //        //Firmar------------------------------------------------------------------------------------  
        //        FirmaXML fx = new FirmaXML();

        //        KeyStore ks = KeyStore.getInstance("PKCS12");
        //        //ks.load(new java.security.KeyStore.LoadStoreParameter());// new BufferedInputStream(new FileInputStream(this.pathCertificado)), this.pass.ToCharArray());
        //        IPKStoreManager storeManager;
        //        if (!pass.Equals(null))
        //        {
        //            //ks.load(new BufferedInputStream(new FileInputStream(this.pathCertificado)), this.pass.ToCharArray());
        //            storeManager = new KSStore(ks, new PassStoreKS(pass));
        //        }
        //        else
        //            storeManager = new KSStore(ks, new DefaultPassStoreKS());
        //        List certificates = storeManager.getSignCertificates();

        //        //Si encontramos el certificado...  
        //        if (certificates.size() == 1)
        //        {
        //            certificate = (X509Certificate)certificates.get(0);

        //            // Obtención de la clave privada asociada al certificado  
        //            privateKey = storeManager.getPrivateKey(certificate);

        //            // Obtención del provider encargado de las labores criptográficas  
        //            provider = storeManager.getProvider(certificate);


        //            Object[] res = fx.signFile(certificate, dataToSign, privateKey, provider);
        //            Document docSigned = dataToSign.getDocument();
        //            //Guardar el fichero firmado----------------------------------------------------------------  
        //            FileOutputStream outputStream = new FileOutputStream(PathFicheroFirmado);
        //            UtilidadTratarNodo.saveDocumentToOutputStream((Document)res[0], outputStream, true);
        //            outputStream.close();

        //            return true;
        //        }
        //        else 
        //            return false;

        //    }
        //    else
        //        return false;
        //}

        private DataToSign createDataToSign_EPES()
        {
            DataToSign dataToSign = new DataToSign();
            dataToSign.setXadesFormat(EnumFormatoFirma.XAdES_BES);
            dataToSign.setEsquema(XAdESSchemas.XAdES_132);
            dataToSign.setPolicyKey("implied"); //Da igual lo que pongamos aquí, la política de firma se define arriba  
            dataToSign.setAddPolicy(true);
            dataToSign.setXMLEncoding("UTF-8");
            dataToSign.setEnveloped(true);
            dataToSign.addObject(new ObjectToSign(new AllXMLToSign(), "Descripcion del documento", null, "text/xml", null));
            dataToSign.setDocument(LoadXML(PathFicheroEntrada));

            return dataToSign;
        }
    }
}
