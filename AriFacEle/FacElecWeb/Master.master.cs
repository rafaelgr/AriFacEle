using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosFacturaLib;
using System.IO;
using System.Collections;


public partial class Master : System.Web.UI.MasterPage
{

    FacturaEntity ctx1;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Crear contexto
        ctx1 = new FacturaEntity("FacturaEntity");

        // Comprobamos si ha hecho un login previo, si no volvemos a la pàgina principal
        if (Session["Skin"] != null)
            RadSkinManager1.Skin = (string)Session["Skin"];
        else
        {
            RadSkinManager1.Skin = "Outlook";
            Session.Add("Skin", "Outlook");
        }
        if (Session["IdCliente"] != null)
        {
            Cliente cliente = CntLib.getCliente((int)Session["IdCliente"], ctx1);
            txtNomClient.Text = cliente.Nombre;

            liberarespacio();
        }

        if(this.Page.GetType().Name.Equals("inicio_aspx"))
            imgbSalir.Visible=false;
    }

    protected void imgbSalir_Click(object sender, ImageClickEventArgs e)
    {
        //Si previamente se han consultado facturas, eliminar el directorio web.
        //CntLib.liberarfacturas(int.Parse(Session["IdCliente"].ToString()), Request.PhysicalApplicationPath, ctx1);
        if(Session["IdCliente"]!=null)
            liberarespacio();

        Session.Clear();
        Response.Redirect("~/Inicio.aspx");
    }

    protected void liberarespacio()
    {
        //Si previamente se han consultado facturas, eliminar el directorio web.
        CntLib.liberarfacturas(int.Parse(Session["IdCliente"].ToString()), Request.PhysicalApplicationPath, ctx1);

        string urlaux = Request.PhysicalApplicationPath + String.Format("Documentos\\{0:000000}\\", int.Parse(Session["IdCliente"].ToString()));
        if (!System.IO.Directory.Exists(urlaux))
        {
            System.IO.Directory.CreateDirectory(urlaux);
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // liberar contexto
        ctx1.Dispose();
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {

        string arg = e.Argument;
        ArrayList selectedItems = (ArrayList)Session["selectedItems"];
        bool b2 = false;
        bool b = Convert.ToBoolean(arg);

        if (b)
            b2= EnvioEmail.RealizaEnvioEmail2(selectedItems, ctx1, Server.MapPath("~/Adjuntos"));
            
            if (b2)
 
                //Ha ido bien
                RadWindowManager1.RadAlert("Proceso envio email finalizado correctamente",350,150,"Envio email", null,"~/img/accept.png");  
   
            else
                RadWindowManager1.RadAlert("ERROR enviando email",150,150,"Envio email",null);
        Session["selectedItems"] = null;
        
            
    }

    
}
