using System;
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

            Cliente client = CntLib.getCliente(txtLogin.Text, ctx1);
            if (client != null && client.Contraseña.Equals(txtPassword.Text))
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