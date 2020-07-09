using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatosFacturaLib
{
    public class FacVtoG
    {
        private int numlinea;

        public int Numlinea
        {
            get { return numlinea; }
            set { numlinea = value; }
        }
        private DateTime fecefect;

        public DateTime Fecefect
        {
            get { return fecefect; }
            set { fecefect = value; }
        }
        private decimal impefect;

        public decimal Impefect
        {
            get { return impefect; }
            set { impefect = value; }
        }
    }
}
