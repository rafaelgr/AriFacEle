using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatosFacturaLib
{
    public class FacturaG
    {
        private string numserie;

        public string Numserie
        {
            get { return numserie; }
            set { numserie = value; }
        }
        private int numfactu;

        public int Numfactu
        {
            get { return numfactu; }
            set { numfactu = value; }
        }
        private DateTime fecfactu;

        public DateTime Fecfactu
        {
            get { return fecfactu; }
            set { fecfactu = value; }
        }
        private int codclien;

        public int Codclien
        {
            get { return codclien; }
            set { codclien = value; }
        }
        private decimal totbases;

        public decimal Totbases
        {
            get { return totbases; }
            set { totbases = value; }
        }
        private decimal totivas;

        public decimal Totivas
        {
            get { return totivas; }
            set { totivas = value; }
        }
        private decimal totfaccl;

        public decimal Totfaccl
        {
            get { return totfaccl; }
            set { totfaccl = value; }
        }
    }
}
