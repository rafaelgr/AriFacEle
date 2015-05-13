using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosFacturaLib;
using System.IO;

public partial class Invoice : System.Web.UI.Page
{
    FacturaEntity ctx1;
    int idFactura = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        ctx1 = new FacturaEntity("FacturaEntity");

        if (Request["Factura"] != null)
        {
            idFactura = int.Parse(Request["Factura"]);
        }
        if (idFactura > 0)
            OpenFactura(idFactura);
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // liberar contexto
        ctx1.Dispose();
    }
    public void OpenFactura(int idFactura)
    {
        string urlaux, url, path, dirRaiz;
        Factura fac = CntLib.getFactura(idFactura, ctx1);
        if (fac.Cliente.ID == int.Parse(Session["IdCliente"].ToString()))
        {
            //ctx1.SaveChanges();
            urlaux = String.Format("Documentos\\{0:000000}", fac.Cliente.ID);
            url = Request.PhysicalApplicationPath + urlaux;

            dirRaiz = ctx1.Repositorios.FirstOrDefault<Repositorio>().Path;
            path = String.Format(dirRaiz + "{0}{1}_{2:00}{3:0000}.pdf", fac.Num_serie, fac.Num_factura, fac.Fecha.Value.Month, fac.Fecha.Value.Year);

            ficherosLib.CopiarFichero(path, url);

            //fac.Nueva = false;
            //ctx1.SaveChanges();

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-disposition", "attachment; filename= " + Path.GetFileName(path));
            Response.WriteFile(String.Format("Documentos/{0:000000}/" + Path.GetFileName(path), fac.Cliente.ID));
            Response.Flush();
            Response.Close();
        }
    }
}