using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatosFacturaLib
{
    public class FacIvaG
    {
        private decimal porciva;

        public decimal Porciva
        {
            get { return porciva; }
            set { porciva = value; }
        }
        private decimal baseimp;

        public decimal Baseimp
        {
            get { return baseimp; }
            set { baseimp = value; }
        }
        private decimal imporiv;

        public decimal Imporiv
        {
            get { return imporiv; }
            set { imporiv = value; }
        }
    }
}
