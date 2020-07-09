using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatosFacturaLib
{
    public class EmpresaG
    {
        private int codigo;
        private string nomempre;

        public string Nomempre
        {
            get { return nomempre; }
            set { nomempre = value; }
        }
        private string cifempre;

        public string Cifempre
        {
            get { return cifempre; }
            set { cifempre = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string domempre;

        public string Domempre
        {
            get { return domempre; }
            set { domempre = value; }
        }
        private string codpobla;

        public string Codpobla
        {
            get { return codpobla; }
            set { codpobla = value; }
        }
        private string pobempre;

        public string Pobempre
        {
            get { return pobempre; }
            set { pobempre = value; }
        }
        private string proempre;

        public string Proempre
        {
            get { return proempre; }
            set { proempre = value; }
        }
    }
}
