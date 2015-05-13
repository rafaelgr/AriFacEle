using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public class Asociado
{
    private int idAsoc;

    public int IdAsoc
    {
        get { return idAsoc; }
        set { idAsoc = value; }
    }
    private string poblacion;
    public string Poblacion
    {
        get { return poblacion; }
        set { poblacion = value; }
    }
    private string provincia;

    public string Provincia
    {
        get { return provincia; }
        set { provincia = value; }
    }
    private DateTime? fechaNacimiento;

    public DateTime? FechaNacimiento
    {
        get { return fechaNacimiento; }
        set { fechaNacimiento = value; }
    }
    private string telefono1;

    public string Telefono1
    {
        get { return telefono1; }
        set { telefono1 = value; }
    }
    private string telefono2;

    public string Telefono2
    {
        get { return telefono2; }
        set { telefono2 = value; }
    }
    private string movil;

    public string Movil
    {
        get { return movil; }
        set { movil = value; }
    }
    private string mail;

    public string Mail
    {
        get { return mail; }
        set { mail = value; }
    }

    private string nif;
    public string Nif
    {
        get { return nif; }
        set { nif = value; }
    }

    private string nombre;
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    private string apellido1;
    public string Apellido1
    {
        get { return apellido1; }
        set { apellido1 = value; }
    }
    private string apellido2;
    public string Apellido2
    {
        get { return apellido2; }
        set { apellido2 = value; }
    }

    private string nomLargo;
    public string NomLargo
    {
        get { return nomLargo; }
        set { nomLargo = value; }
    }


    private string direccion;
    public string Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }
    private string codpostal;
    public string CodPostal
    {
        get { return codpostal; }
        set { codpostal = value; }
    }

    private string comentarios;
    public string Comentarios
    {
        get { return comentarios; }
        set { comentarios = value; }
    }

    private string iban;
    public string Iban
    {
        get { return iban; }
        set { iban = value; }
    }
    private string entidad;
    public string Entidad
    {
        get { return entidad; }
        set { entidad = value; }
    }
    private string sucursal;
    public string Sucursal
    {
        get { return sucursal; }
        set { sucursal = value; }
    }
    private string dc;
    public string Dc
    {
        get { return dc; }
        set { dc = value; }
    }
    private string numcc;
    public string Numcc
    {
        get { return numcc; }
        set { numcc = value; }
    }



}
