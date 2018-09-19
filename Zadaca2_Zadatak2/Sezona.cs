using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca2_Zadatak2
{
    public class Sezona
    {
        string sezonskaGodina;
        int brojKola;
        Liga liga;

        public Sezona()
        {
        }

        public Liga Liga
        {
            get { return liga; }
            set { liga = value; }
        }

        public Sezona(string SezonskaGodina, Liga lliga)
        {
            sezonskaGodina = SezonskaGodina;
            liga = lliga;
            if (lliga.Nivo == "premijer")
                brojKola = 2 * (10 - 1);
            else
                brojKola = 2 * (8 - 1);
        }

       
       public void odigrajKolo(Liga liga)
        {
            
            int numTeams = liga.Klubovi.Count;
            int numDays = (numTeams - 1);
            int halfSize = numTeams / 2;

            List<Klub> teams = new List<Klub>();

            teams.AddRange(liga.Klubovi); // Copy all the elements.
            teams.RemoveAt(0); // To exclude the first team.

            int teamsSize = teams.Count;
            int rbKola = liga.RbKola;

            Console.WriteLine("Kolo {0}", (rbKola + 1));

            int teamIdx = rbKola % teamsSize;

            Console.WriteLine("{0} vs {1}", teams[teamIdx].Naziv, liga.Klubovi[0].Naziv);
            //liga.registrirajUtakmicu(teams[teamIdx].Naziv, liga.Klubovi[0].Naziv);

            for (int index = 1; index < halfSize; index++)
            {
                int prviTim = (rbKola + index) % teamsSize;
                int drugiTim = (rbKola + teamsSize - index) % teamsSize;
                Console.WriteLine("{0} vs {1}", teams[prviTim].Naziv, teams[drugiTim].Naziv);
               // liga.registrirajUtakmicu(teams[prviTim].Naziv, teams[drugiTim].Naziv);
            }

            liga.RbKola++;
        }
        
    }
}
