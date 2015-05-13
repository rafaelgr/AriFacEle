using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriAgroModel
{
    public class Vcampo
    {
        private int codcampo;
        private int provincia;

        public int Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        private int municipio;

        public int Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }
        private int poligono;

        public int Poligono
        {
            get { return poligono; }
            set { poligono = value; }
        }
        private int parcela;

        public int Parcela
        {
            get { return parcela; }
            set { parcela = value; }
        }
        private int recinto;

        public int Recinto
        {
            get { return recinto; }
            set { recinto = value; }
        }
        private DateTime? fecalta;

        public DateTime? Fecalta
        {
            get { return fecalta; }
            set { fecalta = value; }
        }
        private DateTime? fecbaja;

        public DateTime? Fecbaja
        {
            get { return fecbaja; }
            set { fecbaja = value; }
        }
        private decimal supsigpa;

        public decimal Supsigpa
        {
            get { return supsigpa; }
            set { supsigpa = value; }
        }
        private decimal latitud;

        public decimal Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        private decimal longitud;

        public decimal Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        private int codsocio;

        public int Codsocio
        {
            get { return codsocio; }
            set { codsocio = value; }
        }
        private string nomsocio;

        public string Nomsocio
        {
            get { return nomsocio; }
            set { nomsocio = value; }
        }
        private int codvarie;

        public int Codvarie
        {
            get { return codvarie; }
            set { codvarie = value; }
        }
        private string nomvarie;

        public string Nomvarie
        {
            get { return nomvarie; }
            set { nomvarie = value; }
        }

        private int codparti;

        public int Codparti
        {
            get { return codparti; }
            set { codparti = value; }
        }
        private string nomparti;

        public string Nomparti
        {
            get { return nomparti; }
            set { nomparti = value; }
        }

        private int codsitua;

        public int Codsitua
        {
            get { return codsitua; }
            set { codsitua = value; }
        }
        private string nomsitua;

        public string Nomsitua
        {
            get { return nomsitua; }
            set { nomsitua = value; }
        }

        private int nroCampo;
        public int NroCampo
        {
            get { return nroCampo; }
            set { nroCampo = value; }
        }

        public int Codcampo
        {
            get { return codcampo; }
            set { codcampo = value; }
        }

    }
}
