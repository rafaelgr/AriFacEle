﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using DatosFacturaLib;


/// <summary>
/// Summary description for Email
/// </summary>
public class EmailAlz
{
    MailMessage correo = new MailMessage();
    SmtpClient smtp;
    ArrayList adjuntos;

    public EmailAlz()
    {
    }


    public EmailAlz(string mail )
    {
        correo.From = new MailAddress(ConfigurationSettings.AppSettings["mail_address"]);
        correo.To.Add(mail);
        correo.Bcc.Add(ConfigurationSettings.AppSettings["mail_address"]);

    }
    public void EstablecerAdjuntos(ArrayList ListaAdjuntos)
    {
        adjuntos = ListaAdjuntos;
    }
    private void servidor()
    {
        smtp = new SmtpClient(ConfigurationSettings.AppSettings["mail_server"]);
        smtp.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["mail_usr"], ConfigurationSettings.AppSettings["mail_pass"]);
        smtp.Port = int.Parse(ConfigurationSettings.AppSettings["mail_port"]);

        smtp.EnableSsl = bool.Parse(ConfigurationSettings.AppSettings["mail_ssl"]);
    }


    //David. Añadir adjuntos de la carpeta
    public void AnyadirAdjuntos()
    {


        if (adjuntos != null)
        {
            if (adjuntos.Count > 0)
            {
                foreach (string fileName in adjuntos)
                {
                    Attachment data = new Attachment(fileName);
                    // Add time stamp information for the file.
                    // Add the file attachment to this e-mail message.
                    correo.Attachments.Add(data);
                }
            }
        }

        /*

        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(vPath);
        foreach (string fileName in fileEntries)
        {
            Attachment data = new Attachment(fileName);
            // Add time stamp information for the file.
            // Add the file attachment to this e-mail message.
            correo.Attachments.Add(data);

        }


        */


    }

    public void mandarMail(Cliente cli, FacturaEntity ctx1)
    {
        Cliente c = CntLib.getCliente(cli.ID, ctx1);
        string cuerpo;
        correo.Subject = "Aviso de disponibilidad de la factura electrónica [EFACT]";

        AnyadirAdjuntos();

        //Antes de David
        /*
        string cuerpo ="<table style='font-size: 14px; font-weight: normal; font-style: normal; font-family: Arial, Helvetica, sans-serif; background-color: #F9F5EC'>"+
        "<tr><td><img alt='logo' src='"+ConfigurationSettings.AppSettings["url_logo"]+"' /></td>" +
        "<td align='right' style='font-family: Arial, Helvetica, sans-serif; font-size: 16px; color: #3550D7; font-weight: bold'>Disponibilidad de Factura Electrónica</td></tr>"+
        "<tr><td><br /><br />Notificación de emisión de facturas de " + c.Nombre + " <br /><br /></td></tr>" +
        "<tr><td><hr style='color: #FFCC99' /></td></tr>" +
        "<tr><td><br /><br />Estimado Cliente :<br /><br /></td></tr>"+
        "<tr><td colspan='2'>Le informamos que tiene a su disposición nuevas Facturas Electrónicas* con firma digital.Puede descargarlas en los enlaces siguientes:</td></tr>";
        foreach (Factura item in c.Facturas)
	    {
            string link = "http://facturae.alzicoop.com?Factura=" + item.Id_factura;
            if ((bool)item.Nueva)
                cuerpo += "<tr><td><a href='" + link + "'>Factura: " + item.Num_serie + item.Num_factura.ToString() + "</a></td></tr>";
	    }
        cuerpo+="<tr><td colspan='2'>Con este servicio, ahora puede consultar, descargar, imprimir o solicitar un duplicado en papel de su factura, de forma cómoda, rápida y sencilla.<br /><br /></td></tr>"+
            "<tr><td colspan='2'>IMPORTANTE: Si es la primera vez que accede al servicio utilice su NIF como usuario y contraseña de acceso, recomendamos que modifique esta contraseña una vez conectado. <br /><br /></td></tr>" +
        "<tr><td colspan='2'>Gracias por utilizar la facturación electrónica de ALZICOOP.<br /><br /></td></tr>"+
        "<tr><td>Atentamente,</td></tr>"+
        "<tr><td>ALZICOOP, COOP.V. <br /><br /></td></tr>"+
        "<tr><td colspan='2' style='font-style: oblique; font-size: 12px'>"+
        "(*) Le recordamos que la Factura Electrónica con firma digital sustituye a la factura de papel y que, por lo tanto, tiene la misma validez legal."+
        "<br />Si no consigue cargar la página mediante el enlace de acceso directo, pinche en la siguiente dirección, o cópiela en su navegador: http://facturae.alzicoop.com <br /></td></tr>";
        cuerpo += "<tr><td colspan='2'style='font-weight: bold, font-size: 12px'><br />Confidencialidad</td></tr>" +
        "<tr><td colspan='2' style='font-size: 12px'>Este mensaje y sus archivos adjuntos van dirigidos exclusivamente a su destinatario, pudiendo contener información confidencial sometida a secreto profesional. No está permitida su reproducción o distribución sin la autorización expresa de Cooperativa Hortofruticola de Alzira, ALZICOOP,COOP.V. Si usted no es el destinatario final por favor elimínelo e infórmenos por esta vía.<br /></td></tr>";
        cuerpo += "<tr><td colspan='2' style='font-size: 12px'>De acuerdo con la Ley 34/2002 (LSSI) y la Ley 15/1999 (LOPD), usted tiene derecho al acceso, rectificación y cancelación de sus datos personales informados en el fichero del que es titular Cooperativa Hortofruticola de Alzira, ALZICOOP,COOP.V. Si desea modificar sus datos o darse de baja en el sistema de comunicación electrónica envíe un correo a administracion@alzicoop.com, indicando en la línea de “Asunto” el derecho que desea ejercitar.</td></tr>" +
            "</table>";
        */


        //Ahora
        DatosFacturaLib.Plantilla planti = CntLib.getPlantilla(1, ctx1);

        string tabla = "";
        tabla =  "<table style='font-size: 14px; font-weight: normal; font-style: normal; font-family: Arial, Helvetica, sans-serif; background-color: #F9F5EC'>";
        tabla = "<table>";
        foreach (Factura item in c.Facturas)
        {
            string link = "http://facturae.alzicoop.com?Factura=" + item.Id_factura;
            if ((bool)item.Nueva)
                tabla += "<tr><td><a href='" + link + "'>Factura: " + item.Num_serie + item.Num_factura.ToString() + "</a></td></tr>";
        }
        tabla = tabla + "</table>";


        cuerpo = planti.Contenido;

        cuerpo = string.Format(planti.Contenido, c.Nombre, "http://facturae.alzicoop.com?Factura", tabla);
        
        correo.Body = cuerpo;
        correo.IsBodyHtml = true;
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        servidor();
        smtp.Send(correo);
    }

    public bool MandarEmailAsoc(Asociado asoc)
    {
        correo.From = new MailAddress(ConfigurationSettings.AppSettings["mail_address"]);
        correo.To.Add(new MailAddress(ConfigurationSettings.AppSettings["mail_address"]));
        correo.Subject = String.Format("[ONLINE] Solicitud cambio de datos / Sugerencias [Codigo:{0}]", asoc.IdAsoc);
        string cuerpo = @"
            <p>Nombre: {12}</p>    
            <p>Direccion: {3}</p>    
            <p>Cod.Postal: {4}</p>    
            <p>Poblacion: {5}</p>    
            <p>Provincia: {6}</p>    
            <p>Fecha Nacimiento: {7:dd/MM/yyyy}</p>    
            <p>Telefono1: {8}</p>    
            <p>Telefono2: {9}</p>    
            <p>Movil: {10}</p>
            <p>Mail: {11}</p>
            <p>Cuenta bancaria: {14}-{15}-{16}-{17}-{18}</p>
            <p>Comentarios: {13}</p>
            ";
        cuerpo = String.Format(cuerpo,
            asoc.Nombre,
            asoc.Apellido1,
            asoc.Apellido2,
            asoc.Direccion,
            asoc.CodPostal,
            asoc.Poblacion,
            asoc.Provincia,
            asoc.FechaNacimiento,
            asoc.Telefono1,
            asoc.Telefono2,
            asoc.Movil,
            asoc.Mail,
            asoc.NomLargo,
            asoc.Comentarios,
            asoc.Iban,
            asoc.Entidad,
            asoc.Sucursal,
            asoc.Dc,
            asoc.Numcc);
        correo.Body = cuerpo;
        correo.IsBodyHtml = true;
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        servidor();
        smtp.Send(correo);
        return true;
    }
}