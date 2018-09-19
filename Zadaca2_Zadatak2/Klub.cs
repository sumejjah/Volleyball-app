using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca2_Zadatak2
{
    [Serializable]
    public class Klub
    {
        string prefiks;
        string naziv, mjesto, adresa, brojTelefona;
        int osvojeniSetovi, izgubljeniSetovi, osvojeneUtakmice, izgubljeneUtakmice;

        public string Prefiks
        {
            get { return prefiks; }
            set { prefiks = value; }
        }

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public string Mjesto
        {
            get { return mjesto; }
            set { mjesto = value; }
        }

        public string BrojTelefona
        {
            get { return brojTelefona; }
            set { brojTelefona = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public int OsvojeniSetovi
        {
            get { return osvojeniSetovi; }
            set { osvojeniSetovi = value; }
        }

        public int IzgubljeniSetovi
        {
            get { return izgubljeniSetovi; }
            set { izgubljeniSetovi = value; }
        }

        public int OsvojeneUtakmice
        {
            get { return osvojeneUtakmice; }
            set { osvojeneUtakmice = value; }
        }

        public int IzgubljeneUtakmice
        {
            get { return izgubljeneUtakmice; }
            set { izgubljeneUtakmice = value; }
        }

        public Klub()
        {
        }

        public Klub(string Prefiks, string Naziv, string Mjesto, string BrojTelefona, string Adresa)
        {
            prefiks = Prefiks;
            naziv = Naziv;
            mjesto = Mjesto;
            brojTelefona = BrojTelefona;
            adresa = Adresa;
            osvojeniSetovi = 0;
            izgubljeniSetovi = 0;
            osvojeneUtakmice = 0;
            izgubljeneUtakmice = 0;
        }

        public bool sviPodaciUneseni()
        {
            if (naziv != "" && mjesto != "" && prefiks != "" && brojTelefona != "" && adresa != "")
                return true;
            return false;
        }
    }
}
