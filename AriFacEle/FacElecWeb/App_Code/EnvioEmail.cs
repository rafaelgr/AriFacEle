using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatosFacturaLib;
using System.IO;

/// <summary>
/// Descripción breve de EnvioEmail
/// </summary>
public static class EnvioEmail
{
    //public static EnvioEmail()
    //{
    //    //
    //    // TODO: Agregar aquí la lógica del constructor
    //    //
    //}




    public static bool   RealizaEnvioEmail2(ArrayList selectedItems,FacturaEntity ctx1,string pathAdjuntos)
    {
       
            // El path sera: Server.MapPath("~/Adjuntos")
            // Process the list of files found in the directory.
            ArrayList adjuntos=new  ArrayList();
            string[] fileEntries = Directory.GetFiles(pathAdjuntos);
            foreach (string fileName in fileEntries)
            {
                adjuntos.Add(fileName);
            }
            


           // ArrayList selectedItems = (ArrayList)Session["selectedItems"];
            Cliente cliente = new Cliente();
            EmailGen email;
        
            foreach (string item in selectedItems)
            {
                cliente = CntLib.getCliente(int.Parse(item), ctx1);
                cliente.F_nueva = false;
                ctx1.SaveChanges();
                if (cliente.Email != null)
                {
                    email = new EmailGen(cliente.Email);
                    email.EstablecerAdjuntos(adjuntos);

                    email.mandarMail(cliente, ctx1);
                }
            }
        
            return true;
        
    }
}