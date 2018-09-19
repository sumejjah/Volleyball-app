using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca2_Zadatak2
{
    
    public class Liga
    {
        List<Klub> klubovi;
        string kategorija, nivo, mjesto;
        bool aktivna;
        int rbKola;
        int maxBrojKola;

        public int MaxBrojKola
        {
            get { return maxBrojKola; }
            set { maxBrojKola = value; }
        }

        public int RbKola
        {
            get { return rbKola; }
            set { rbKola = value; }
        }

        public string Kategorija
        {
            get { return kategorija; }
            set { kategorija = value; }
        }

        public string Mjesto
        {
            get { return mjesto; }
            set { mjesto = value; }
        }

        public string Nivo
        {
            get { return nivo; }
            set { nivo = value; }
        }

        public bool Aktivna
        {
            get { return aktivna; }
            set { aktivna = value; }
        }

        public Liga() { }

        public Liga(Liga l)
        {
            if (l != null)
            {
                klubovi = l.Klubovi;
                nivo = l.Nivo;
                kategorija = l.Kategorija;
                aktivna = l.Aktivna;
                mjesto = l.Mjesto;
                rbKola = 0;
                maxBrojKola = l.MaxBrojKola;
            }
        }

        public Liga(List<Klub> Klubovi, string Nivo, string Kategorija, string Mjesto, bool Aktivna)
        {
            klubovi = Klubovi;
            nivo = Nivo;
            kategorija = Kategorija;
            aktivna = Aktivna;
            mjesto = Mjesto;
            rbKola = 0;
            if (nivo == "premijer")
                maxBrojKola = 18;
            else
                maxBrojKola = 14;
        }

        public List<Klub> Klubovi
        {
            get { return klubovi; }
            set { klubovi = value; }
        }

        public void registrirajUtakmicu(string a, string b, int rez1, int rez2)
        {
            int prvi = Klubovi.FindIndex(x => x.Naziv == a);
            int drugi = Klubovi.FindIndex(x => x.Naziv == b);

            int p, q;

            p = rez1;
            q = rez2;

            Klubovi[prvi].OsvojeniSetovi += p;
            Klubovi[drugi].OsvojeniSetovi += q;
            Klubovi[prvi].IzgubljeniSetovi += q; //onoliko koliko je drugi  tim osvojio setova, toliko je prvi izgubio
            Klubovi[drugi].IzgubljeniSetovi += p;

            if (p > q)
            {
                Klubovi[prvi].OsvojeneUtakmice++;
                Klubovi[drugi].IzgubljeneUtakmice++;

            }
            else
            {
                Klubovi[drugi].OsvojeneUtakmice++;
                Klubovi[prvi].IzgubljeneUtakmice++;
            }

        }
    }
}
