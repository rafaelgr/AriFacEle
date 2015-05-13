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
    public class Firma
    {

        #region [propiedades]
        private string pathFicheroEntrada;

        public string PathFicheroEntrada
        {
            get { return pathFicheroEntrada; }
            set { pathFicheroEntrada = value; }
        }
        private string pathFicheroFirmado;

        public string PathFicheroFirmado
        {
            get { return pathFicheroFirmado; }
            set { pathFicheroFirmado = value; }
        }
        private Certificado certificado;

        public Certificado Certificado
        {
            get { return certificado; }
            set { certificado = value; }
        }
        #endregion
        
        public virtual bool Firmar()
        {
            return false;
        }

        protected Document LoadXML(string path)
        {
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            dbf.setNamespaceAware(true);
            return dbf.newDocumentBuilder().parse(new BufferedInputStream(new FileInputStream(path)));
        }

    }
}
