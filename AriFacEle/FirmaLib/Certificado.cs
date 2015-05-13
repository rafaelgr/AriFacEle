using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using java.security.cert;
using java.security;
using java.io;
using es.mityc.javasign.pkstore.keystore;
using sviudes.blogspot.com;
using es.mityc.javasign.pkstore;
using java.util;

namespace FirmaLib
{
    public class Certificado
    {
        private string pathCertificado;

        public string PathCertificado
        {
            get { return pathCertificado; }
            set { pathCertificado = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public X509Certificate LoadCertificate(out PrivateKey privateKey, out Provider provider)
        {
            X509Certificate certificate = null;
            provider = null;
            privateKey = null;

            //Cargar certificado de fichero PFX  
            KeyStore ks = KeyStore.getInstance("PKCS12");
            ks.load(new BufferedInputStream(new FileInputStream(this.pathCertificado)), this.pass.ToCharArray());
            IPKStoreManager storeManager = new KSStore(ks, new PassStoreKS(this.pass));
            List certificates = storeManager.getSignCertificates();

            //Si encontramos el certificado...  
            if (certificates.size() == 1)
            {
                certificate = (X509Certificate)certificates.get(0);

                // Obtención de la clave privada asociada al certificado  
                privateKey = storeManager.getPrivateKey(certificate);

                // Obtención del provider encargado de las labores criptográficas  
                provider = storeManager.getProvider(certificate);
            }

            return certificate;
        }

        public static X509Certificate LoadCertificate(string path, string password, out PrivateKey privateKey, out Provider provider)
        {
            X509Certificate certificate = null;
            provider = null;
            privateKey = null;

            //Cargar certificado de fichero PFX  
            KeyStore ks = KeyStore.getInstance("PKCS12");
            ks.load(new BufferedInputStream(new FileInputStream(path)), password.ToCharArray());
            IPKStoreManager storeManager = new KSStore(ks, new PassStoreKS(password));
            List certificates = storeManager.getSignCertificates();

            //Si encontramos el certificado...  
            if (certificates.size() == 1)
            {
                certificate = (X509Certificate)certificates.get(0);

                // Obtención de la clave privada asociada al certificado  
                privateKey = storeManager.getPrivateKey(certificate);

                // Obtención del provider encargado de las labores criptográficas  
                provider = storeManager.getProvider(certificate);
            }

            return certificate;
        }
    }
}
