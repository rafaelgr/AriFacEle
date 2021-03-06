﻿using System;
using System.Web;
using System.Web.UI;
using DosimetriaModelo;
using DosimetriaWinWeb;
using Telerik.OpenAccess;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class PlantillaForm : System.Web.UI.Page
{
    #region Variables declaration
    Dosimetria ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    Plantilla plantilla = null;
    bool newRecord = true;
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (DosimetriaCTX -> web.config)
        ctx = new Dosimetria("DosimetriaCTX");
        // verify if a Usuario is logged
        usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (usuario == null)
            Response.Redirect("Default.aspx");
        else
            Session["UsuarioId"] = usuario.UsuarioId;
        //
        permiso = CntDosimetria.GetPermiso(usuario.GrupoUsuario, "Plantillagrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // load the combo
        // Is it a new record or not?
        if (Request.QueryString["PlantillaId"] != null)
        {
            plantilla = CntDosimetria.GetPlantilla(int.Parse(Request.QueryString["PlantillaId"]), ctx);
            LoadData(plantilla);
            newRecord = false;
        }
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
        }
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
            if (newRecord)
                plantilla = new Plantilla();
            UnloadData(plantilla);
            if (newRecord)
            {
                ctx.Add(plantilla);
            }
            ctx.SaveChanges();
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
        }
        catch (Exception ex)
        {
            ControlDeError(ex);
        }
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("closeWindow();");
    }
    #endregion
    #region Auxiliary
    protected bool DataOk()
    {
        if (txtNombre.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "NombreNeeded"));
            RadNotification1.Show();
            return false;
        }
        return true;
    }

    protected void LoadData(Plantilla plantilla)
    {
        txtNombre.Text = plantilla.Nombre;
        rdeContenido.Content = plantilla.Contenido;
    }

    protected void UnloadData(Plantilla plantilla)
    {
        plantilla.Nombre = txtNombre.Text;
        plantilla.Contenido = rdeContenido.Content;
    }
    #endregion


    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = permiso.Proceso;
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }
}