using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosFacturaLib;


public partial class Plantilla : System.Web.UI.Page
{
    #region Variables declaration
    //string caller = ""; // who calls the form
    DatosFacturaLib.Plantilla planti = null;

    
    FacturaEntity ctx;

    #endregion



    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["IdSuper"] == null)
        {
          Response.Redirect("~/Inicio.aspx");
        }
        ctx = new FacturaEntity("FacturaEntity");
        btnAccept.Visible =true;
        // load the combo
        // Is it a new record or not?

        //Se mandaba un query if (Request.QueryString["PlantillaId"] != null)
        //if (Request.QueryString["PlantillaId"] != null)
        //{
            //planti = CntLib.getPlantilla (int.Parse(Request.QueryString["PlantillaId"]), ctx);
        planti = CntLib.getPlantilla(1, ctx);  //La 1 es la plantilla para el email
        LoadData(planti);
        //}
        /*if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
        }*/
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion
    #region Actions
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!DataOk())
                return;
            //No hay nuevo de momento
            //if (newRecord)
            //    planti =new DatosFacturaLib.Plantilla();
            UnloadData(planti);
            //if (newRecord)
            //{
            //    ctx.Add(planti);
            //}
            ctx.SaveChanges();
            Response.Redirect("~/AdminPage.aspx");
            /*
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
        
             */
        }
        catch (Exception ex)
        {
            //ControlDeError(ex);
        }
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        //RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        Response.Redirect("~/AdminPage.aspx");
    }
    #endregion
    #region Auxiliary
    protected bool DataOk()
    {

        int i=0;
        int inicio = 0;
        int j;
        double Num;
        bool isNum;
        string s;
         
        do
        {
            i = rdeContenido.Text.IndexOf("{", inicio);
            if (i>0)
            {
                j = rdeContenido.Text.IndexOf("}", i);
                if (j<=0)
                {
                    //No tiene cierre llave
                    return false;
                }
                else
                {
                    //Ok. Tiene cierre de llave
                    if (i + 1 == j)

                        s = "error";  // ha puesto {}
                    else
                        inicio = j + 1;  //para el siguiente bucle
                        j = j - (i + 1);
                        s=rdeContenido.Text.Substring(i+1,   j);
                    
                    
                    isNum = double.TryParse(s, out Num);
                    if (!isNum)
                    {
                        return false ;
                    }
                    else
                    {
                        
                        //Si que es uhn numero. Solo dos comprobaciones. Debe ser mayor =0 y <=...
                        j= int.Parse(s);
                        if (j<0 || j>4)
                         return false ;
                        else
	                    {
                            //return true;  
	                    }
                       
                    }
                }
            }
          
           
        }
        while (i > 0);






        return true;
    }

    protected void LoadData(DatosFacturaLib.Plantilla plantilla)
    {
        
        txtNombre.Text = plantilla.Nombre ;
        rdeContenido.Content = plantilla.Contenido;
    }

    protected void UnloadData(DatosFacturaLib.Plantilla plantilla)
    {
       // plantilla.Nombre = txtNombre.Text;
       plantilla.Contenido = rdeContenido.Content;
    }
    #endregion

    /*
    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = permiso.Proceso;
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
     
    }*/
}