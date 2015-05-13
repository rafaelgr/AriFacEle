using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosFacturaLib;
using System.IO;

public partial class Inicio2 : System.Web.UI.Page
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


            //LOGARSE.  Esto es solo para aritxi
            // Miramos primero  si es el admin.  Si no es el admin miramos si codclien
            // y finalmente mirariamos si es el socio
            bool yaLogado = false;



            Superusuario su = (from u in ctx1.Superusuarios
                               where u.Login == txtLogin.Text && u.Contraseña == txtPassword.Text
                               select u).FirstOrDefault<Superusuario>();
            if (su != null)
            {
                Session.Add("IdSuper", su.Id);
                Session.Timeout = 360;

                Response.Redirect("~/AdminPage.aspx");
                yaLogado = true;
            }

            if (!yaLogado)
            {
                /*Ahora en aritxi el login sera el codigo de cliente.
                por lo tanto habra dos nuevas funciones.
                Una para buscar por codigo cliente, y otra para buscar por codigo proveedor */

                //1ª comprobacion. Vcampo es un numerico
                int codigo = 0;
                try
                {
                    codigo = Convert.ToInt32(txtLogin.Text);
                    if (codigo == 0)
                        lblErr.Text = "Código incorrecto";

                }
                catch (FormatException e1)
                {
                    lblErr.Text = "Código numerico";
                }

                if (codigo > 0)
                {
                    Cliente client = CntLib.getCliente(false, codigo, ctx1);
                    if (client != null && client.Contraseña.Equals(txtPassword.Text))
                    {
                        Session.Add("IdCliente", client.ID);

                        Session.Timeout = 360;
                        yaLogado = true;
                        if (Request["Factura"] != null)
                            Response.Redirect("~/InvoiceViewer.aspx?Factura=" + idFactura);
                        else
                            Response.Redirect("~/InvoiceViewer.aspx");
                    }


                    if (!yaLogado)
                    {
                        client = CntLib.getCliente(true, codigo, ctx1);
                        if (client != null && client.Contraseña.Equals(txtPassword.Text))
                        {
                            Session.Add("IdCliente", client.ID);

                            Session.Timeout = 360;
                            yaLogado = true;
                            if (Request["Factura"] != null)
                                Response.Redirect("~/InvoiceViewer.aspx?Factura=" + idFactura);
                            else
                                Response.Redirect("~/InvoiceViewer.aspx");
                        }
                    }
                       
                }


            }

            if (!yaLogado)
                lblErr.Text = "Error: Login o contraseña incorrectos.";

        }
        else
        {
            Session.Clear();
        } // de Session["IdCliente"]




    } //LinkButton1_Click

}  //de la clase