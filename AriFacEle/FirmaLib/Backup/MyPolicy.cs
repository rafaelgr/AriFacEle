using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using es.mityc.javasign.xml.xades.policy;
using java.security.cert;
using java.util;
using org.w3c.dom;
using es.mityc.firmaJava.libreria.xades;


namespace FirmaLib
{
    public class MyPolicy : IValidacionPolicy
    {
        public String getIdentidadPolicy() {
  		return "Política de ejemplo";
  	}
  
  	/**
  	 * <p>Se valida que el certificado empleado en la firma se encuentre en el periodo de validez.</p>
  	 * 
  	 * @param element Nodo de firma
  	 * @param resultadoValidacion Estructura de datos de resultado de validación 
  	 */
  	public PolicyResult validaPolicy(Element element, ResultadoValidacion resultadovalidacion) 
    {
  		PolicyResult pr = new PolicyResult();
        ResultadoValidacion rv = resultadovalidacion;
        
        X509Certificate cert = (X509Certificate) resultadovalidacion.getDatosFirma().getCadenaFirma().getCertificates().get(0);
  		
        try {
  			cert.checkValidity(new Date());
  			pr.setResult(PolicyResult.StatusValidation.valid);
        //    System.out.println("Validación de política superada.");
        } catch (CertificateExpiredException e) 
        {
        //    pr.setResult(PolicyResult.StatusValidation.invalid);
        //    pr.setDescriptionResult(e.getMessage());
        //    System.out.println("Validación de política NO superada. Certificado caducado");
        } catch (CertificateNotYetValidException e) 
        {
        //    pr.setResult(PolicyResult.StatusValidation.invalid);
        //    pr.setDescriptionResult(e.getMessage());
        //    System.out.println("Validación de política NO superada. Certificado aún no válido");
        }
  		
  		    return pr;
        }
    
    public PolicyResult validaPolicy(ResultadoValidacion resultadovalidacion)
    {
        
        ResultadoValidacion rv = resultadovalidacion;

        X509Certificate cert = (X509Certificate)resultadovalidacion.getDatosFirma().getCadenaFirma().getCertificates().get(0);

        //try
        //{
            cert.checkValidity(new Date());
            PolicyResult pr = new PolicyResult();
            if (rv.getDatosFirma().getPoliticas().size() > 0)
            {
                pr = (PolicyResult)rv.getDatosFirma().getPoliticas().get(0);
                pr.setResult(PolicyResult.StatusValidation.valid);
            }
            //    System.out.println("Validación de política superada.");
        //}
        //catch (CertificateExpiredException e)
        //{
        //    //    pr.setResult(PolicyResult.StatusValidation.invalid);
        //    //    pr.setDescriptionResult(e.getMessage());
        //    //    System.out.println("Validación de política NO superada. Certificado caducado");
        //}
        //catch (CertificateNotYetValidException e)
        //{
        //    //    pr.setResult(PolicyResult.StatusValidation.invalid);
        //    //    pr.setDescriptionResult(e.getMessage());
        //    //    System.out.println("Validación de política NO superada. Certificado aún no válido");
        //}

        return pr;
    }
    }
}
