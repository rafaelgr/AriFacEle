using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public class Articulo
{
    private string codArtic;

    public string CodArtic
    {
        get { return codArtic; }
        set { codArtic = value; }
    }
    private string nomArtic;

    public string NomArtic
    {
        get { return nomArtic; }
        set { nomArtic = value; }
    }
    private decimal pvp;

    public decimal PVP
    {
        get { return pvp; }
        set { pvp = value; }
    }
}
