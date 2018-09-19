using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadaca2_Zadatak2.Properties;
using System.Resources;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace Zadaca2_Zadatak2
{
    public partial class Form1 : Form
    {
        /*
        Jedan od gestalt principa je udaljenost. Objekti koji su blizu 
         * jedni drugima (relativno u odnosu na druge objekte) izgledaju kao grupa, za razliku od onih koji su udaljeni.
         * Iskoristila sam tab kontrole kako bi korisniku lakse bilo snaci se i koristiti program.
         * takodjer, tu se nazire i gestalt princip: simetrija
         * 
         * Gestalt princip: slicnost
         * sve kotrole (za unos) su jednake velicine
         * 
         * Gestalt princip : pozadina
         * u tab kontroli, sam na drugom tabu promijenila boju pozadine, kako bi korisnik odmah uocio samo button-e
         * 
         * 
        */
        List<Klub> sviKlubovi = new List<Klub>();
        List<Klub> chosen = new List<Klub>();
        List<int> tmp = new List<int>();

        List<Liga> lige = new List<Liga>();
        Sezona s = new Sezona();
        Liga trenutnaLiga = new Liga();
        TextBox drzava = new TextBox();
        Label labela = new Label();

        Thread nit;

        public Form1()
        {
            InitializeComponent();

            tabPage3.Hide();

            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            labela.Text = "";
            drzava.Hide();
            checkedListBox1.Hide();
            button4.Hide();

            label1.Hide();
            textBox1.Hide();

            button7.Hide();
            button8.Hide();
            button9.Hide();

            for (int i = 0; i < 10; i++)
            {
                sviKlubovi.Add(new Klub("OK", i.ToString(), "Visoko", "123456", "bare"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 unosKluba = new Form2();
            this.Hide();
            unosKluba.ShowDialog();
            Klub klub = unosKluba.Klub;
            if (sviKlubovi.Contains(klub))
            {
                MessageBox.Show("Vec je registrovan uneseni klub!");
                return;
            }
            if (klub != null)
            {
                sviKlubovi.Add(klub);
                MessageBox.Show("Klub uspjesno dodan! :) ");
            }

            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            labela.Text = "";
            drzava.Hide ();
            checkedListBox1.Hide();
            groupBox4.Hide();
            label2.Hide();
            button5.Hide();
            label1.Hide();
            textBox1.Hide();

            this.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            groupBox1.Show();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            labela.Text = "";
            drzava.Hide();
            checkedListBox1.Hide();
            label2.Hide();
            button5.Hide();

            label1.Hide();
            textBox1.Hide();

            groupBox1.Show();
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true) //premijer liga
            {
                groupBox2.Show();
                groupBox3.Show();

                Label labela = new Label();
                labela.AutoSize = true;
                labela.Size = new Size(35, 15);
                labela.Text = "Država: ";
                labela.Location = new Point(40, 150);
                tabPage1.Controls.Add(labela);
                labela.Visible = true;
              
                drzava.Location = new System.Drawing.Point(125, 158);
                drzava.Size = new System.Drawing.Size(200, 20);
                drzava.Visible = true;
                tabPage1.Controls.Add(drzava);


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                groupBox2.Show();
                groupBox3.Show();

                Label labela = new Label();
                labela.AutoSize = true;
                labela.Size = new Size(35, 15);
                labela.Text = "Entitet: ";
                labela.Location = new Point(40, 150);
               // labela.BorderStyle = BorderStyle.FixedSingle;
                tabPage1.Controls.Add(labela);
                labela.Visible = true;
                labela.Show();

                drzava.Location = new System.Drawing.Point(125, 158);
                drzava.Size = new System.Drawing.Size(200, 20);
                drzava.Visible = true;
                tabPage1.Controls.Add(drzava);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < sviKlubovi.Count; i++)
                {
                    if (sviKlubovi[i].Prefiks != "ŽOK")
                        tmp.Add(i);
                }
            if (radioButton1.Checked && tmp.Count < 10)
            {
                MessageBox.Show("Potrebno je registrovati još " + (10 - tmp.Count).ToString() + " klubova.");
                return;
            }
            else if (radioButton2.Checked && tmp.Count < 8)
            {
                MessageBox.Show("Potrebno je registrovati još " + (8 - tmp.Count).ToString() + " klubova.");
                return;
            }
            if(radioButton1.Checked)
                for (int i = 0; i < sviKlubovi.Count; i++)
                {
                    checkedListBox1.Items.Add(sviKlubovi[i].Naziv);
                }
            else if(radioButton2.Checked)
                for (int i = 0; i < sviKlubovi.Count; i++)
                {
                    checkedListBox1.Items.Add(sviKlubovi[i].Naziv);
                }

            checkedListBox1.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> odabraniKlubovi = new List<string>();
            
            foreach (object s in checkedListBox1.CheckedItems)
            {
                odabraniKlubovi.Add(s.ToString());
                //sviKlubovi.Remove(sviKlubovi.Find(x => x.Naziv == s.ToString()));
            }

            checkedListBox1.Items.Clear();
            //checkedListBox1.Items.AddRange(noviCheckBox);

            if (odabraniKlubovi.Count != 10 && radioButton1.Checked)
            {
                MessageBox.Show("Broj klubova nije odgovarajuci!");
                return;
            }
            else if (odabraniKlubovi.Count != 8 && radioButton2.Checked)
            {
                MessageBox.Show("Broj klubova nije odgovarajuci!");
                return;
            }

            foreach (string s in odabraniKlubovi)
            {
                chosen.Add(sviKlubovi.Find(x => x.Naziv == s));
            }
            
            
            string kategorija = string.Empty, nivo = string.Empty;
            if(radioButton3.Checked)
                kategorija = "muška";
            else if(radioButton4.Checked)
                kategorija = "ženska";

            if (radioButton1.Checked)
                nivo = "premijer";
            else if (radioButton2.Checked)
                nivo = "entitetska";

            try
            {
                lige.Add(new Liga(chosen, nivo, kategorija, drzava.Text, radioButton5.Checked));

                MessageBox.Show("Liga uspješno dodana! :)");

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Greška:" + ex.Message, "Izuzetak");
            }
            
            
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

           

            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }

            drzava.Text = "";

            button4.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            checkedListBox1.Hide();
            labela.Text = "";
            drzava.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            button4.Hide();

            drzava.Hide();
            checkedListBox1.Hide();

            label1.Show();
            textBox1.Show();
            
            label2.Show();
            groupBox4.Show();
            button5.Show();                  

        }

        private void button5_Click(object sender, EventArgs e)
        {           
            
                       
            if (radioButton7.Checked)
            {
                try
                {
                    trenutnaLiga = lige.Find(x => (x.Nivo == "premijer" && x.Mjesto == textBox1.Text));

                    if (trenutnaLiga == null)
                    {
                        NullReferenceException izuzetak = new NullReferenceException();
                        throw izuzetak;
                    }
                    else
                    {
                        if (trenutnaLiga.Aktivna == false)
                        {
                            MessageBox.Show("Liga nije aktivna.");
                            return;
                        }

                        TabPage t = tabControl1.TabPages[2];
                        tabControl1.SelectedTab = t;

                    }
                }
                catch (NullReferenceException izuzetak)
                {
                    MessageBox.Show("Nije registrovana odabrana liga!");
                    radioButton7.Checked = false;
                    textBox1.Clear();
                    return;
                }

            }
            else if (radioButton8.Checked)
            {
                try
                {
                    trenutnaLiga = lige.Find(x => (x.Nivo == "entitetska" && x.Mjesto == textBox1.Text));

                    if (trenutnaLiga == null)
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        if (trenutnaLiga.Aktivna == false)
                        {
                            MessageBox.Show("Liga nije aktivna.");
                            return;
                        }

                        TabPage t = tabControl1.TabPages[2];
                        tabControl1.SelectedTab = t;


                    }
                }
                catch (NullReferenceException izuzetak)
                {
                    MessageBox.Show("Nije registrovana odabrana liga!");
                    textBox1.Clear();
                    radioButton8.Checked = false;
                    return;
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < sviKlubovi.Count; i++)
            {
                if (sviKlubovi[i].Prefiks != "MOK")
                    tmp.Add(i);
            }
            if (radioButton1.Checked && tmp.Count < 10)
            {
                MessageBox.Show("Potrebno je registrovati još " + (10 - tmp.Count).ToString() + " klubova.");
                return;
            }
            else if (radioButton2.Checked && tmp.Count < 8)
            {
                MessageBox.Show("Potrebno je registrovati još " + (8 - tmp.Count).ToString() + " klubova.");
                return;
            }
            if (radioButton1.Checked)
                for (int i = 0; i < 10; i++)
                {
                    checkedListBox1.Items.Add(sviKlubovi[i].Naziv);
                }
            else if (radioButton2.Checked)
                for (int i = 0; i < 10; i++)
                {
                    checkedListBox1.Items.Add(sviKlubovi[i].Naziv);
                }

            checkedListBox1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (trenutnaLiga.Aktivna == false)
            {
                MessageBox.Show("Liga nije aktivna!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            s = new Sezona(comboBox1.SelectedItem.ToString(), trenutnaLiga);
            label3.Text = "";
            comboBox1.Hide();
            button6.Hide();
            button7.Show();
            button8.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

           if (trenutnaLiga.RbKola == trenutnaLiga.MaxBrojKola)
            {
                MessageBox.Show("Odigrana su sva kola!");
                return;
            }

            int numTeams = trenutnaLiga.Klubovi.Count;
            int numDays = (numTeams - 1);
            int halfSize = numTeams / 2;

            List<string> teams = new List<string>();
            
            for (int i = 0; i < trenutnaLiga.Klubovi.Count-1; i++)
            {
                teams.Add(trenutnaLiga.Klubovi[i+1].Naziv);  
            }

            //teams.AddRange(trenutnaLiga.Klubovi); // Copy all the elements.
            //teams.RemoveAt(0); // To exclude the first team.
            
            int teamsSize = teams.Count;
            int rbKola = trenutnaLiga.RbKola;

            //Console.WriteLine("Kolo {0}", (rbKola + 1));

            int indeksTima = rbKola % teamsSize;
            //string a = "1", b = "2";
            string a = teams[indeksTima];
            string b = trenutnaLiga.Klubovi[0].Naziv;

            //Console.WriteLine("{0} vs {1}", teams[teamIdx].Naziv, liga.Klubovi[0].Naziv);

            if (trenutnaLiga.Nivo == "premijer")
            {
          
                if (rbKola < 9)
                {
                    
                    Form4 utakmica = new Form4(a, b);
                    this.Hide();
                    utakmica.ShowDialog();
                    trenutnaLiga.registrirajUtakmicu(teams[indeksTima], trenutnaLiga.Klubovi[0].Naziv,
                                                utakmica.Rez1, utakmica.Rez2);
                }
                else
                {
                    Form4 utakmica = new Form4(b, a);
                    this.Hide();
                    utakmica.ShowDialog();
                    trenutnaLiga.registrirajUtakmicu(trenutnaLiga.Klubovi[0].Naziv, teams[indeksTima],
                                                utakmica.Rez1, utakmica.Rez2);
                }
            }
            else
            {
                if (rbKola < 7)
                {
                    
                    Form4 utakmica = new Form4(a, b);
                   this.Hide();
                    utakmica.ShowDialog();
                    trenutnaLiga.registrirajUtakmicu(teams[indeksTima], trenutnaLiga.Klubovi[0].Naziv,
                                                utakmica.Rez1, utakmica.Rez2);
                }
                else
                {
                    Form4 utakmica = new Form4(b, a);
                    this.Hide();
                    utakmica.ShowDialog();
                    trenutnaLiga.registrirajUtakmicu(trenutnaLiga.Klubovi[0].Naziv, teams[indeksTima],
                                                utakmica.Rez1, utakmica.Rez2);
                }
            }

            //this.Show();

            for (int index = 1; index < halfSize; index++)
            {
                int prviTim = (rbKola + index) % teamsSize;
                int drugiTim = (rbKola + teamsSize - index) % teamsSize;
                //Console.WriteLine("{0} vs {1}", teams[prviTim].Naziv, teams[drugiTim].Naziv);
                a = teams[prviTim];
                b = teams[drugiTim];

                if (trenutnaLiga.Nivo == "premijer")
                {
                    if (rbKola < 9)
                    {
                        Form4 utakmica = new Form4(a, b);
                        this.Hide();
                        utakmica.ShowDialog();
                        trenutnaLiga.registrirajUtakmicu(teams[prviTim], teams[drugiTim],
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                    else
                    {
                        Form4 utakmica = new Form4(b, a);
                        this.Hide();
                        utakmica.ShowDialog();
                        trenutnaLiga.registrirajUtakmicu(teams[drugiTim], teams[prviTim],
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                }
                else
                {
                    if (rbKola < 7)
                    {
                        Form4 utakmica = new Form4(a, b);
                        this.Hide();
                        utakmica.ShowDialog();
                        trenutnaLiga.registrirajUtakmicu(teams[prviTim], teams[drugiTim],
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                    else
                    {
                        Form4 utakmica = new Form4(b, a);
                        this.Hide();
                        utakmica.ShowDialog();
                        trenutnaLiga.registrirajUtakmicu(teams[drugiTim], teams[prviTim],
                                                    utakmica.Rez1, utakmica.Rez2);
                    }
                }

            }

            trenutnaLiga.RbKola++;
            this.Show();
            button3.Show();
            button2.Show();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 forma = new Form5(lige);
            this.Hide();
            forma.ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form6 forma = new Form6(lige);
            this.Hide();
            forma.ShowDialog();
            Liga l = forma.L;
            if (forma.L == null)
            {
                MessageBox.Show("Nije pronadjena liga!");
                this.Show();
                return;
            }
            int i = lige.FindIndex(x => (x.Aktivna == !(l.Aktivna) && x.Mjesto == l.Mjesto && x.Nivo == l.Nivo));
            lige[i] = l;
            this.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bool rez = MessageBox.Show("Da li želite obrisati posljednu dodanu ligu?", "Brisanje", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK;
            if (rez)
            {
                lige.RemoveAt(lige.Count - 1);
                MessageBox.Show("Liga je obrisana. Trenutni broj liga je " + lige.Count.ToString());
                return;
            }
            else
                return;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[0];
            tabControl1.SelectedTab = t; //go to tab
        }

        private void button8_Click(object sender, EventArgs e)
        {
                Form7 forma = new Form7(trenutnaLiga);
                this.Hide();
                forma.ShowDialog();
                this.Show();
        }

        Graphics MojGrafickiObjekat;
        ResourceManager rm = Resources.ResourceManager;
        static int brojac = 0;

        private void button13_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MojGrafickiObjekat = panel1.CreateGraphics();

            if (brojac == 0)
            {
                Image slika = (Image)rm.GetObject("tmp-0");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 1)
            {
                Image slika = (Image)rm.GetObject("tmp-1");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 2)
            {
                Image slika = (Image)rm.GetObject("tmp-2");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }

            else if (brojac == 3)
            {
                Image slika = (Image)rm.GetObject("tmp-3");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }

            else if (brojac == 4)
            {
                Image slika = (Image)rm.GetObject("tmp-4");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 5)
            {
                Image slika = (Image)rm.GetObject("tmp-5");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 6)
            {
                Image slika = (Image)rm.GetObject("tmp-6");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 7)
            {
                Image slika = (Image)rm.GetObject("tmp-7");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 8)
            {
                Image slika = (Image)rm.GetObject("tmp-8");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 9)
            {
                Image slika = (Image)rm.GetObject("tmp-9");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 10)
            {
                Image slika = (Image)rm.GetObject("tmp-10");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }
            else if (brojac == 11)
            {
                Image slika = (Image)rm.GetObject("tmp-11");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 300, 200);

                brojac++;
            }

            else if (brojac == 12)
            {
                Image slika = (Image)rm.GetObject("tmp-12");
                TextureBrush mojBrushSlika = new TextureBrush(slika);

                MojGrafickiObjekat.FillRectangle(mojBrushSlika, 10, 5, 81, 500);

                brojac = 0;
            }
        }

        List<Klub> kluboviBarChart = new List<Klub>();
        //string Prefiks, string Naziv, string Mjesto, string BrojTelefona, string Adresa
        void dodajKlubove()
        {
            kluboviBarChart.Add(new Klub("OK", "Željezničar", "Sarajevo", "+38761234432", "Grbavica"));
            kluboviBarChart[0].OsvojeniSetovi = 7;
            kluboviBarChart[0].IzgubljeniSetovi = 2;
            kluboviBarChart[0].OsvojeneUtakmice = 3;
            kluboviBarChart[0].IzgubljeneUtakmice = 0;

            kluboviBarChart.Add(new Klub("OK", "Sarajevo", "Sarajevo", "+387987654", "Kosevo"));
            kluboviBarChart[1].OsvojeniSetovi = 1;
            kluboviBarChart[1].IzgubljeniSetovi = 5;
            kluboviBarChart[1].OsvojeneUtakmice = 0;
            kluboviBarChart[1].IzgubljeneUtakmice = 2;

            kluboviBarChart.Add(new Klub("OK", "Čelik", "Zenica", "+387234987", "NemamPojma"));
            kluboviBarChart[2].OsvojeniSetovi = 4;
            kluboviBarChart[2].IzgubljeniSetovi = 2;
            kluboviBarChart[2].OsvojeneUtakmice = 1;
            kluboviBarChart[2].IzgubljeneUtakmice = 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dodajKlubove();

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali niti jedan klub");
                return;
            }

            Graphics mojGrafickiObjekat;
            mojGrafickiObjekat = panel2.CreateGraphics();

            mojGrafickiObjekat.Clear(Color.White);
            
            Pen mojPen = new Pen(Color.Black, 1);

            mojGrafickiObjekat.DrawLine(mojPen, 45, 20, 250, 20);
            mojGrafickiObjekat.DrawString("10", Font, new SolidBrush(Color.Black), 30, 15);

            mojGrafickiObjekat.DrawLine(mojPen, 45, 60, 250, 60);
            mojGrafickiObjekat.DrawString("5", Font, new SolidBrush(Color.Black), 30, 55);

            mojGrafickiObjekat.DrawLine(mojPen, 45, 100, 250, 100);
            mojGrafickiObjekat.DrawString("3", Font, new SolidBrush(Color.Black), 30, 95);

            mojGrafickiObjekat.DrawLine(mojPen, 45, 140, 250, 140);
            mojGrafickiObjekat.DrawString("1", Font, new SolidBrush(Color.Black), 30, 135);

            mojGrafickiObjekat.DrawLine(mojPen, 45, 150, 250, 150);
            mojGrafickiObjekat.DrawString("0", Font, new SolidBrush(Color.Black), 30, 145);

            SolidBrush Bar1 = new SolidBrush(Color.Aqua);
            Point visina11 = new Point(), visina21 = new Point(), visina31 = new Point(), visina41 = new Point();
           
            if (comboBox2.SelectedIndex == 0)
            {
                visina11 = preracunajKoordinate(kluboviBarChart[0].OsvojeniSetovi);
                visina21 = preracunajKoordinate(kluboviBarChart[0].IzgubljeniSetovi);
                visina31 = preracunajKoordinate(kluboviBarChart[0].OsvojeneUtakmice);
                visina41 = preracunajKoordinate(kluboviBarChart[0].IzgubljeneUtakmice);
                
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                visina11 = preracunajKoordinate(kluboviBarChart[1].OsvojeniSetovi);
                visina21 = preracunajKoordinate(kluboviBarChart[1].IzgubljeniSetovi);
                visina31 = preracunajKoordinate(kluboviBarChart[1].OsvojeneUtakmice);
                visina41 = preracunajKoordinate(kluboviBarChart[1].IzgubljeneUtakmice);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                visina11 = preracunajKoordinate(kluboviBarChart[2].OsvojeniSetovi);
                visina21 = preracunajKoordinate(kluboviBarChart[2].IzgubljeniSetovi);
                visina31 = preracunajKoordinate(kluboviBarChart[2].OsvojeneUtakmice);
                visina41 = preracunajKoordinate(kluboviBarChart[2].IzgubljeneUtakmice);
            }
            /*FillRectangle(Brush b, int x1, int y1, int width, int height);
                Crta ispunjeni pravougaonik specificirane širine i visine. 
                Gornji lijevi ugao pravougaonika je određen sa
                tačkom (x,y). Brush određuje pattern koji ispunjava unutrašnjost pravougaonika.*/
            mojGrafickiObjekat.FillRectangle(Bar1, 50, visina11.Y, 40, 240);
            mojGrafickiObjekat.FillRectangle(Bar1, 110, visina21.Y, 40, 240);
            mojGrafickiObjekat.FillRectangle(Bar1, 170, visina31.Y, 40, 240);
            mojGrafickiObjekat.FillRectangle(Bar1, 230, visina41.Y, 40, 240);
            //olaksica 
            mojGrafickiObjekat.FillRectangle(new SolidBrush(Color.White), 40, 151, 400, 100);

            mojGrafickiObjekat.DrawString("Osvojeni", Font, new SolidBrush(Color.Black), 50, 170);
            mojGrafickiObjekat.DrawString("Izgubljeni", Font, new SolidBrush(Color.Black), 110, 170);
            mojGrafickiObjekat.DrawString("Osvojene", Font, new SolidBrush(Color.Black), 170, 170);
            mojGrafickiObjekat.DrawString("Izgubljene", Font, new SolidBrush(Color.Black), 230, 170);

            mojGrafickiObjekat.DrawString("setovi", Font, new SolidBrush(Color.Black), 50, 180);
            mojGrafickiObjekat.DrawString("setovi", Font, new SolidBrush(Color.Black), 110, 180);
            mojGrafickiObjekat.DrawString("utakmice", Font, new SolidBrush(Color.Black), 170, 180);
            mojGrafickiObjekat.DrawString("utakmice", Font, new SolidBrush(Color.Black), 230, 180);
        }

        public Point preracunajKoordinate(int visina)
        {
            if (visina == 10)
                return new Point(40, 20);
            else if (visina == 9)
                return new Point(40, 25);
            else if (visina == 8)
                return new Point(40, 30);
            else if (visina == 7)
                return new Point(40, 40);
            else if (visina == 6)
                return new Point(40, 50);
            else if (visina == 5)
                return new Point(40, 60);
            else if (visina == 4)
                return new Point(40, 80);
            else if (visina == 3)
                return new Point(40, 100);
            else if (visina == 2)
                return new Point(40, 130);
            else if (visina == 1)
                return new Point(40, 140);
            else
                return new Point(40, 151);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dodajKlubove();
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali niti jedan klub!");
                return;
            }
            
            Graphics mojGrafickiObjekat;
            // Kreiranje vlastitog Graphics objekta
            mojGrafickiObjekat = panel3.CreateGraphics();

            mojGrafickiObjekat.Clear(Color.White);

            SolidBrush zuta = new SolidBrush(Color.Yellow);
            SolidBrush ljubicasta = new SolidBrush(Color.PaleVioletRed);
            
            Pen p = new Pen(Color.Black, 2);

            Rectangle rt = new Rectangle(60, 15, 180, 180);

            // Iscrtamo pite
            float osvojeni = kluboviBarChart[comboBox3.SelectedIndex].OsvojeneUtakmice;
            float izgubljeni = kluboviBarChart[comboBox3.SelectedIndex].IzgubljeneUtakmice;
            float ukupno = osvojeni + izgubljeni;
            // Iscrtamo popunjene pite
            mojGrafickiObjekat.DrawPie(p, rt, 0, -(osvojeni/ukupno)*360);
            mojGrafickiObjekat.FillPie(zuta, rt, 0, -(osvojeni / ukupno) * 360);

            mojGrafickiObjekat.DrawPie(p, rt, 0, (izgubljeni / ukupno) * 360);
            mojGrafickiObjekat.FillPie(ljubicasta, rt, 0, (izgubljeni / ukupno) * 360);

            //mojGrafickiObjekat.DrawRectangle(new Pen(Color.Black), 250, 70, 15, 15);
            mojGrafickiObjekat.FillRectangle(zuta, 250, 70, 15, 15);
            mojGrafickiObjekat.DrawString("osvojene", new Font("Times New Roman", 10, FontStyle.Italic),
                                                new SolidBrush(Color.Black), 270, 70);
            mojGrafickiObjekat.DrawString("utakmice", new Font("Times New Roman", 10, FontStyle.Italic),
                                                new SolidBrush(Color.Black), 270, 80);

            mojGrafickiObjekat.FillRectangle(ljubicasta, 250, 90, 15, 15);
            mojGrafickiObjekat.DrawString("izgubljene", new Font("Times New Roman", 10, FontStyle.Italic),
                                                new SolidBrush(Color.Black), 270, 90);
            mojGrafickiObjekat.DrawString("utakmice", new Font("Times New Roman", 10, FontStyle.Italic),
                                                new SolidBrush(Color.Black), 270, 100);

            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string vremenskaPrognoza = dajIzvorniKod("http://rss.theweathernetwork.com/weather/bkxx0004");
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(vremenskaPrognoza); 

            XmlNodeList elemList = xml.GetElementsByTagName("description");
            XmlNodeList dani = xml.GetElementsByTagName("title");
            for (int i = 1; i < elemList.Count; i++)
            {
                //richTextBox1.Text += elemList[i].InnerXml;
                string tmp = elemList[i].InnerText;
                string dan = dani[i + 2].InnerText;
                //int indexDani = dan.IndexOf("-");
                int l = tmp.IndexOf(",");
                if (l > 0)
                {
                    tmp = tmp.Substring(0, l);
                }
                else
                    tmp = "";
                tmp = Regex.Replace(tmp, @"\s+", " ");
                dan.Trim();

                richTextBox1.Text += dan;
                richTextBox1.Text += "\n";
                richTextBox1.Text += tmp;
                richTextBox1.Text += "\n\n";
            }

            if (richTextBox1.Text.Contains("Cloudy with sunny breaks") == true)
            {
                nit = new Thread(new ThreadStart(suncanoOblacno));
            }
        }


        void suncanoOblacno()
        {
            //Kreiraj grafički objekat
            Graphics mojGrafickiObjekat = panel4.CreateGraphics();
            ResourceManager rm = Resources.ResourceManager;

            //Učitaj brushove za pojedine frejmove
            Image slika = (Image)rm.GetObject("1");
            TextureBrush b1 = new TextureBrush(slika);

            slika = (Image)rm.GetObject("2");
            TextureBrush b2 = new TextureBrush(slika);

            slika = (Image)rm.GetObject("3");
            TextureBrush b3 = new TextureBrush(slika);

            while (true)
            {
                mojGrafickiObjekat.FillRectangle(b1, 0, 0, 149, 193); //Popuni panel odgovarajućom slikom
                Thread.Sleep(100); // Pauziraj thread na 100 ms
                mojGrafickiObjekat.Clear(Color.White); // Pripremi teren za sljedeći frejm

                mojGrafickiObjekat.FillRectangle(b2, 0, 0, 249, 193);
                Thread.Sleep(100);
                mojGrafickiObjekat.Clear(Color.White);

                mojGrafickiObjekat.FillRectangle(b3, 0, 0, 249, 193);
                Thread.Sleep(100);
                mojGrafickiObjekat.Clear(Color.White);

            }
        }

        String dajIzvorniKod(String url)
        {
            try
            {
                WebClient client = new WebClient();
                Byte[] source = client.DownloadData(url);
                String s = System.Text.Encoding.Default.GetString(source);
                return s;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return e.Message;
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            nit.Abort();
        }
        
        
    }
}
