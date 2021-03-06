﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosFacturaLib;
using System.IO;

public partial class Inicio : System.Web.UI.Page
{
    FacturaEntity ctx1;

    int idFactura = 0;
    Factura fact;
    //Cliente client;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Crear contexto
        ctx1 = new FacturaEntity("FacturaEntity");

        if (Request["Factura"] != null)
        {
            idFactura = int.Parse(Request["Factura"]);
        }
    }

    //protected void Page_Unload(object sender, EventArgs e)
    //{
    //    // liberar contexto
    //    ctx1.Dispose();
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdCliente"] != null)
        {            
            if (Request["Factura"] != null)
                Response.Redirect("~/InvoiceViewer.aspx?Factura=" + idFactura);
            else
                Response.Redirect("~/InvoiceViewer.aspx");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        lblErr.Text = ""; 
        if (Session["IdCliente"] == null)
        {
            Cliente client = null;
            string login = txtLogin.Text;
            if (CntLib.getClienteMoreThanOne(login, ctx1))
            {
                lblErr.Text = "Error: Hay más de un cliente con este identifcador. <br/> Use el correo electrónico como identificador de usuario.";
                return;
            }
            // comprobar si es un correo el identificador
            if (login.IndexOf("@") != -1)
            {
                // buscar por el correo.
                client = CntLib.getClienteByEmail(login, ctx1);
            }
            else
            {
                client = CntLib.getCliente(txtLogin.Text.Trim(), ctx1);
            }

            if (client != null && client.Contraseña.Trim().Equals(txtPassword.Text.Trim()))
            {
                Session.Add("IdCliente", client.ID);

                Session.Timeout = 360;

                if (Request["Factura"] != null)
                    Response.Redirect("~/InvoiceViewer.aspx?Factura=" + idFactura);
                else
                    Response.Redirect("~/InvoiceViewer.aspx");
            }
            else
            {
                Superusuario su = (from u in ctx1.Superusuarios
                                   where u.Login == txtLogin.Text && u.Contraseña == txtPassword.Text
                                   select u).FirstOrDefault<Superusuario>();
                if (su != null)
                {
                    Session.Add("IdSuper", su.Id);
                    Session.Timeout = 360;

                    Response.Redirect("~/AdminPage.aspx");
                }
                else
                    lblErr.Text = "Error: Nombre o contraseña incorrectos.";
            }

        }
        else
        {
            Session.Clear();
        }

    }
    
}