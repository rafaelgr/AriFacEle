using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatosFacturaLib
{
    public class FacLineaG
    {
        private int numlinea;

        public int Numlinea
        {
            get { return numlinea; }
            set { numlinea = value; }
        }
        private string nomconce;

        public string Nomconce
        {
            get { return nomconce; }
            set { nomconce = value; }
        }
        private string ampliaci;

        public string Ampliaci
        {
            get { return ampliaci; }
            set { ampliaci = value; }
        }
        private decimal cantidad;

        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private decimal precio;

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        private decimal porciva;

        public decimal Porciva
        {
            get { return porciva; }
            set { porciva = value; }
        }
        private decimal impoiva;

        public decimal Impoiva
        {
            get { return impoiva; }
            set { impoiva = value; }
        }
    }
}
