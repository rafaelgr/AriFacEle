using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.w3c.dom;
using java.util;
using es.mityc.firmaJava.libreria.xades;
using java.security.cert;
using javax.xml.parsers;
using java.io;
using es.mityc.javasign.xml.xades.policy;
using es.mityc.javasign.trust;

namespace FirmaLib
{
    public class Validacion
    {
        public string Basica(InputStream fichero) 
        {
            string mensaje = "";
            // Se declara la estructura de datos que almacenarÃ¡ el resultado de la validaciÃ³n
            ArrayList results = null;
               
            // Se instancia el validador y se realiza la validaciÃ³n
            try 
            {
                // Se convierte el InputStream a Document
                Document doc = parseaDoc(fichero);
                if (doc == null)
                {
                    return mensaje = "Error de validaciÃ³n. No se pudo parsear la firma.";
                }

                ValidarFirmaXML vXml = new ValidarFirmaXML();
                results = vXml.validar(doc, "./", null);
            } 
            catch(Exception e)
            {
                return mensaje = e.Message;
            }

            // Se muestra por consola el resultado de la validaciÃ³n
            ResultadoValidacion result = null;
            Iterator it = results.iterator();
            while (it.hasNext()) {
                //if (it.next() is ResultadoValidacion)
                result = (ResultadoValidacion)it.next();
                Boolean isValid = result.isValidate();
                //MessageBox.Show("-----------------");
                //MessageBox.Show("--- RESULTADO ---");
                //MessageBox.Show("-----------------");
                if(isValid){
                    // El mÃ©todo getNivelValido devuelve el Ãºltimo nivel XAdES vÃ¡lido
                    return mensaje = "La firma es valida.\n" + result.getNivelValido() 
                            + "\nCertificado: " + ((X509Certificate) result.getDatosFirma().getCadenaFirma().getCertificates().get(0)).getSubjectDN()
                            + "\nFirmado el: " + result.getDatosFirma().getFechaFirma()
                            + "\nNodos firmados: " + result.getFirmados();
                } else {
                    // El mÃ©todo getLog devuelve el mensaje de error que invalidÃ³ la firma
                    return mensaje = "La firma NO es valida\n" + result.getLog();
                }
            }
            return mensaje = "Ocurrió un error durante el proceso";
        }
         
        private  static String TRUSTER_NAME = "my";  	
        protected TrustAbstract truster = null;

        public string Completa(InputStream fichero) 
        {
            string respuesta ="";
             ArrayList results = null;
             ArrayList arrayPolicies = new ArrayList (1);
             Document doc;

             try
             {
                // Se instancia el validador y se realiza la validaciÃ³n
                try 
                {
                    // Se convierte el InputStream a Document
                    doc = parseaDoc(fichero);
                    if (doc == null)
                    {
                        return respuesta = "Error de validaciÃ³n. No se pudo parsear la firma.";
                    }
                    ValidarFirmaXML vXml = new ValidarFirmaXML();
                    results = vXml.validar(doc, "./", null);
                }
                catch(Exception e)
                {
                    return respuesta = e.Message;
                }
        		
                // Se muestra por consola el resultado de la validaciÃ³n
                ResultadoValidacion result = null;
                Iterator it = results.iterator();
                while (it.hasNext())
                {
                    result = (ResultadoValidacion)it.next();
                    MyPolicy mp = new MyPolicy();
                    IValidacionPolicy policy = (mp.validaPolicy(result)).getPolicyVal();

                    arrayPolicies.add(policy);
                }

             } 
             catch (CertificateExpiredException e) 
             {
                return "Validación de política NO superada. Certificado caducado";
             } 
             catch (CertificateNotYetValidException e) 
             {
                return "Validación de política NO superada. Certificado aún no válido";
             }
     
             /**
             Validación extra de confianza de certificados
             try
             {
                 truster = TrustFactory.getInstance().getTruster(TRUSTER_NAME);
                 if (truster == null)
                 {
                     return "\nNo se encontró el validador de confianza";
                 }
             }
             catch (NullReferenceException nre) 
             { return "\nNo se encontró el validador de confianza"; }
     		**/

             //Validadores extra
             ExtraValidators validator = new ExtraValidators(arrayPolicies, null, truster);
     		
             // La siguente línea es una alternativa para realizar la misma acción anterior, en caso de que los tres argumentos de ExtraValidators fueran nulos
             		//validator.setTrusterCerts((TrustAbstract)(((TrustExtendFactory)TrustFactory.getInstance()).getSignCertsTruster("mityc")));
     
             // Se declara la estructura de datos que almacenará el resultado de la validación
             results =null;
     		
            // Se instancia el validador y se realiza la validaciÃ³n
            try 
            {
                ValidarFirmaXML vXml = new ValidarFirmaXML();
                results = vXml.validar(doc, "./", validator);
            } 
            catch(Exception e)
            {
                respuesta = e.Message;
            }

            // Se muestra por consola el resultado de la validaciÃ³n
            ResultadoValidacion resultVal = null;
            Iterator ite = results.iterator();
            while (ite.hasNext()) {
                //if (it.next() is ResultadoValidacion)
                resultVal = (ResultadoValidacion)ite.next();
                Boolean isValid = resultVal.isValidate();

                if(isValid){
                    // El mÃ©todo getNivelValido devuelve el Ãºltimo nivel XAdES vÃ¡lido
                    return respuesta += "\nLa firma es valida.\n" + resultVal.getNivelValido() 
                            + "\nCertificado: " + ((X509Certificate) resultVal.getDatosFirma().getCadenaFirma().getCertificates().get(0)).getSubjectDN()
                            + "\nFirmado el: " + resultVal.getDatosFirma().getFechaFirma()
                            + "\nNodos firmados: " + resultVal.getFirmados();
                } else {
                    // El mÃ©todo getLog devuelve el mensaje de error que invalidÃ³ la firma
                    return respuesta += "\nLa firma NO es valida\n" + resultVal.getLog();
                }
            }

             return respuesta;
        }

        private Document parseaDoc(InputStream fichero) 
        {
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            dbf.setNamespaceAware(true) ;

            DocumentBuilder db = null;
            try {
                db = dbf.newDocumentBuilder();
            } catch (ParserConfigurationException ex) {
                //MessageBox.Show("Error interno al parsear la firma");
                //ex.printStackTrace();
                return null;
            }
            
            Document doc = null;
            try {
                doc = db.parse(fichero);
            } catch (org.xml.sax.SAXException ex) {
                doc = null;
            } 
            catch (java.io.IOException ex) {
                doc = null;
            //    //MessageBox.Show("Error interno al validar firma");
            //    //ex.printStackTrace();

            }
            finally {
                dbf = null;
                db = null;
                fichero.close();
            }
            return doc;
        }

        public string ValidaBasica(string fichero)
        {
            return "Descomentar texto aqui abajo   ValidaBasica";

            /*
            File f = new File(@"C:\ProyectosNet\FacturaElectronica[Ariges]\Firma_facturaE\PruebasFirma\Ariadna\A3200002_012012.xml");
            InputStream inputStream = new FileInputStream(f);
            return Basica(inputStream);
     
             * 
             */
        }
    }
}
