using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca2_Zadatak2
{
    public partial class Form3 : Form
    {
        Liga liga = new Liga();
        Sezona s = new Sezona();

        public Liga Liga
        {
            get { return liga; }
            set { liga = value; }
        }
        
        public Form3()
        {
            InitializeComponent();
            button2.Hide();
            button3.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = new Sezona(comboBox1.SelectedItem.ToString(), liga);
            label1.Text = "";
            comboBox1.Hide();
            button1.Hide();
            button2.Show();
            button3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (liga.RbKola == liga.MaxBrojKola)
            {
                MessageBox.Show("Odigrana su sva kola!");
                return;
            }

            int numTeams = liga.Klubovi.Count;
            int numDays = (numTeams - 1);
            int halfSize = numTeams / 2;

            List<Klub> teams = new List<Klub>();

            teams.AddRange(liga.Klubovi); // Copy all the elements.
            teams.RemoveAt(0); // To exclude the first team.

            int teamsSize = teams.Count;
            int rbKola = liga.RbKola;

            //Console.WriteLine("Kolo {0}", (rbKola + 1));

            int teamIdx = rbKola % teamsSize;

            //Console.WriteLine("{0} vs {1}", teams[teamIdx].Naziv, liga.Klubovi[0].Naziv);

            if (liga.Nivo == "premijer")
            {
                if (rbKola < 9)
                {
                    Form4 utakmica = new Form4(teams[teamIdx].Naziv, liga.Klubovi[0].Naziv);
                    //utakmica.MDiParent = this;
                    this.Close();
                    utakmica.ShowDialog();
                    liga.registrirajUtakmicu(teams[teamIdx].Naziv, liga.Klubovi[0].Naziv,
                                                utakmica.Rez1, utakmica.Rez2);
                }
                else
                {
                    Form4 utakmica = new Form4(liga.Klubovi[0].Naziv, teams[teamIdx].Naziv);
                    this.Close();
                    utakmica.ShowDialog();
                    liga.registrirajUtakmicu(liga.Klubovi[0].Naziv, teams[teamIdx].Naziv,
                                                utakmica.Rez1, utakmica.Rez2);
                }
            }
            else
            {
                if (rbKola < 7)
                {
                    Form4 utakmica = new Form4(teams[teamIdx].Naziv, liga.Klubovi[0].Naziv);
                    this.Close();
                    utakmica.ShowDialog();
                    liga.registrirajUtakmicu(teams[teamIdx].Naziv, liga.Klubovi[0].Naziv,
                                                utakmica.Rez1, utakmica.Rez2);
                }
                else
                {
                    Form4 utakmica = new Form4(liga.Klubovi[0].Naziv, teams[teamIdx].Naziv);
                    this.Close();
                    utakmica.ShowDialog();
                    liga.registrirajUtakmicu(liga.Klubovi[0].Naziv, teams[teamIdx].Naziv,
                                                utakmica.Rez1, utakmica.Rez2);
                }
            }

            //this.Show();

            for (int index = 1; index < halfSize; index++)
            {
                int prviTim = (rbKola + index) % teamsSize;
                int drugiTim = (rbKola + teamsSize - index) % teamsSize;
                //Console.WriteLine("{0} vs {1}", teams[prviTim].Naziv, teams[drugiTim].Naziv);
                if (liga.Nivo == "premijer")
                {
                    if (rbKola < 9)
                    {
                        Form4 utakmica = new Form4(teams[prviTim].Naziv, teams[drugiTim].Naziv);
                        this.Close();
                        utakmica.ShowDialog();
                        liga.registrirajUtakmicu(teams[prviTim].Naziv, teams[drugiTim].Naziv,
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                    else
                    {
                        Form4 utakmica = new Form4(teams[drugiTim].Naziv, teams[prviTim].Naziv);
                        this.Close();
                        utakmica.ShowDialog();
                        liga.registrirajUtakmicu(teams[drugiTim].Naziv, teams[prviTim].Naziv,
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                }
                else
                {
                    if (rbKola < 7)
                    {
                        Form4 utakmica = new Form4(teams[prviTim].Naziv, teams[drugiTim].Naziv);
                        this.Close();
                        utakmica.ShowDialog();
                        liga.registrirajUtakmicu(teams[prviTim].Naziv, teams[drugiTim].Naziv,
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                    else
                    {
                        Form4 utakmica = new Form4(teams[drugiTim].Naziv, teams[prviTim].Naziv);
                        this.Close();
                        utakmica.ShowDialog();
                        liga.registrirajUtakmicu(teams[drugiTim].Naziv, teams[prviTim].Naziv,
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                }

                //this.Show();
            }

            liga.RbKola++;
           // this.Show();
            button3.Show();
            button2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (liga.RbKola == 0)
            {
                MessageBox.Show("Nije odigrana niti jedna utakmica");
                return;
            }
            //ispis tabele
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
