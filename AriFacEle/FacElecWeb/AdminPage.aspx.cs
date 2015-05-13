using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosFacturaLib;
using Telerik.Web.UI;
using System.Collections;


public partial class AdminPage : System.Web.UI.Page
{
    FacturaEntity ctx1;
    int idCliente;
    int idSuper;
    Cliente cliente;
    Superusuario superU;
    bool continuarProcesoEnvioEmail;


    protected void Page_Init(object sender, EventArgs e)
    {
        // Crear contexto
        ctx1 = new FacturaEntity("FacturaEntity");

        // Comprobamos si ha hecho un login previo, si no volvemos a la pàgina principal
        if (Session["IdCliente"] != null)
        {
            idCliente = int.Parse(Session["IdCliente"].ToString());
            cliente = (from c in ctx1.Clientes
                       where c.ID == idCliente
                       select c).First<Cliente>();
        }
        if (Session["IdSuper"] != null)
        {
            idSuper = int.Parse(Session["idSuper"].ToString());
            superU = (from c in ctx1.Superusuarios
                      where c.Id == idSuper
                      select c).First<Superusuario>();
        }
        else
        {
            Response.Redirect("~/Inicio.aspx");
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // liberar contexto
        ctx1.Dispose();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdEnvio.AllowSorting = true;
            GridSortExpression expresion = new GridSortExpression();
            expresion.FieldName = "Nombre";
            expresion.SortOrder = GridSortOrder.Ascending;
            grdEnvio.MasterTableView.SortExpressions.Add(expresion);

            loadCuenta();
        }
        GridTraductor.TraducirFiltrosRadGrid(grdEnvio);
        GridTraductor.TraducirGrupoRadGrid(grdEnvio);
    }

    #region[mi_cuenta]

    protected void loadCuenta()
    {
        txtLogin.Text = superU.Login;
        txtLogin.Enabled = false;

        txtEmail.Text = superU.Email;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Image1.Visible = true;
        Image2.Visible = true;
        Image3.Visible = true;
        if (!txtEmail.Text.Equals(""))
        {
            superU.Email = txtEmail.Text;
            Image3.ImageUrl = "~/img/accept.png";
        }
        else
        {
            Image3.ImageUrl = "~/img/warning.png";
        }
        if (!txtPass1.Text.Equals("") && !txtPass2.Text.Equals("") && txtPass1.Text.Equals(txtPass2.Text))
        {
            Image1.ImageUrl = "~/img/accept.png";
            Image2.ImageUrl = "~/img/accept.png";

            superU.Contraseña = txtPass1.Text;
            ctx1.SaveChanges();
        }
        else
        {
            Image1.ImageUrl = "~/img/warning.png";
            Image2.ImageUrl = "~/img/warning.png";
        }
    }

    #endregion
    
    protected void grdEnvio_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        grdEnvio.DataSource = (from c in ctx1.Clientes
                               where c.F_nueva != false
                               select c).ToList<Cliente>();
    }

    protected void grdEnvio_ItemCommand(object source, GridCommandEventArgs e)
    {
        lblMensaje.Visible = false;
        ArrayList selectedItems;
        if (Session["selectedItems"] == null)
        {
            selectedItems = new ArrayList();
        }
        else
        {
            selectedItems = (ArrayList)Session["selectedItems"];
        }
        if (e.CommandName == "Selecion" && e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            string idCliente = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["ID"].ToString();
            if (!selectedItems.Contains(idCliente))
            {
                selectedItems.Add(idCliente);
                e.Item.Selected = true;
            }
            else
            {
                selectedItems.Remove(idCliente);
                e.Item.Selected = false;
            }

            Session["selectedItems"] = selectedItems;
        }
    }

    protected void chkSelec_CheckedChanged(object sender, EventArgs e)
    {
        lblMensaje.Visible = false;
        if (chkSelec.Checked == true)
        {
            ArrayList selectedItems = selectedItems = new ArrayList();
            List<Cliente> clientes = (from c in ctx1.Clientes
                                      where c.F_nueva != false
                                      select c).ToList<Cliente>();
            foreach (Cliente item in clientes)
            {
                selectedItems.Add(item.ID.ToString());
            }
            Session["selectedItems"] = selectedItems;
        }
        else
            Session["selectedItems"] = new ArrayList();

        grdEnvio.Rebind();
    }
    
    protected void grdEnvio_ItemDataBound(object sender, GridItemEventArgs e)
    {
        string idCliente;

        if (e.Item is GridDataItem)
        {
            ArrayList selectedItems;
            if (Session["selectedItems"] == null)
            {
                selectedItems = new ArrayList();
            }
            else
            {
                selectedItems = (ArrayList)Session["selectedItems"];
            }
            idCliente = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]].ToString();
            if (selectedItems.Contains(idCliente))
                e.Item.Selected = true;
            else
                e.Item.Selected = false;
           
        }
    }


    private void EnlazarAjuntos()
    {


    }

    private void ConfirmCallBackFn2()
    {
        Console.Write("");
    }

    protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["selectedItems"] != null)
        {
            ArrayList selectedItems = (ArrayList)Session["selectedItems"];

            bool ok = false;
            bool existeCarpeta = System.IO.Directory.Exists(Server.MapPath("~/Adjuntos"));

            if (existeCarpeta)
            {
                //Veremos si tiene archivos dentro
                string[] archivos = System.IO.Directory.GetFiles(Server.MapPath("~/Adjuntos"));
                int i = 0;
                foreach (string fichero in archivos)
                    i++;


                if (i > 0)
                {
                    RadWindowManager rdw = (RadWindowManager)this.Master.FindControl("RadWindowManager1");
                    //RadWindowManager1.RadConfirm("Existen " + i + " archivo(s) para adjuntar. ¿Continuar?", "");
                    rdw.RadConfirm("Existen archivos para adjuntar. Continuar?", "confirmCallBackFn", 330, 180, null, "Envio email");
                }
                else
                {

                    ok=EnvioEmail.RealizaEnvioEmail2(selectedItems, ctx1, Server.MapPath("~/Adjuntos"));
                }
            }
            else
            {
                ok=EnvioEmail.RealizaEnvioEmail2(selectedItems, ctx1,Server.MapPath("~/Adjuntos"));
            }

            /*
            ArrayList selectedItems= (ArrayList)Session["selectedItems"];
            Cliente cliente = new Cliente();
            EmailAlz email;

            foreach (string item in selectedItems)
            {
                cliente = CntLib.getCliente(int.Parse(item), ctx1);
                cliente.F_nueva = false;
                ctx1.SaveChanges();
                if (cliente.Email != null)
                {
                    email = new EmailAlz(cliente.Email);
                    email.mandarMail(cliente, ctx1);
                }
            }

            if (selectedItems.Count > 0)
            {
                Session["selectedItems"] = null;
                lblMensaje.Visible = true;
            }
            */

            if (ok)
            {
                Session["selectedItems"] = null;
                lblMensaje.Visible = true;
            }
            
        }
        else
        {
             RadWindowManager rdw = (RadWindowManager)this.Master.FindControl("RadWindowManager1");
                   
            rdw.RadAlert("Seleccione los items", 150, 150, "Envio email", null);   
        }

       
        
        grdEnvio.Rebind();
    }



    protected void btnEditPlantilla_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("~/Plantilla.aspx");
    }

}