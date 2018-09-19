using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zadaca2_Zadatak2
{
    public partial class Form2 : Form
    {
        Klub klub;
        List<Klub> sviKlubovi = new List<Klub>();
        XmlSerializer xmlSerijalizer;
        IFormatter binSerijalizer;

        public Klub Klub
        {
            get { return klub; }
            set { klub = value; }
        }

        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (kontrolaUnosKluba1.SviPodaciUneseni() == true && textBox1.Text.Length >= 3)
                {
                    klub = new Klub(kontrolaUnosKluba1.Prefiks, kontrolaUnosKluba1.Naziv,
                                                kontrolaUnosKluba1.Mjesto, kontrolaUnosKluba1.BrojTelefona,
                                                        textBox1.Text);
                    this.Close();
                }

                else
                    throw (new KlasaIzuzetak());
            }
            catch (KlasaIzuzetak)
            {
                MessageBox.Show("Niste unijeli sve podatke!");
            }
        }

        private void kontrolaUnosKluba1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length < 3)
            {
                toolStripStatusLabel1.Text = "Adresa mora sadrzavati minimalno 4 karaktera!";
                e.Cancel = true;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                e.Cancel = false;
            }
        }

        bool validirajPodatkeKluba()
        {
            if (kontrolaUnosKluba1.Prefiks == "" || kontrolaUnosKluba1.Naziv == "" || kontrolaUnosKluba1.Mjesto == "" || kontrolaUnosKluba1.BrojTelefona == "" ||
                textBox1.Text == "")
                return false;
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validirajPodatkeKluba())
                {
                    throw new ArgumentException("Nisu validni svi podaci!");
                }
                else
                {
                    Klub k = new Klub(kontrolaUnosKluba1.Prefiks, kontrolaUnosKluba1.Naziv,
                                                kontrolaUnosKluba1.Mjesto, kontrolaUnosKluba1.BrojTelefona,
                                                        textBox1.Text);
                    binSerijalizer = new BinaryFormatter();
                    FileStream dat = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi\\" + k.Naziv + ".bin", FileMode.Create, FileAccess.Write);
                    binSerijalizer.Serialize(dat, k); dat.Close();

                    sviKlubovi.Add(k);
                    
                    MessageBox.Show("Zaposlenik je uspješno sačuvan u XML datoteku koja se nalazi na lokaciji: " + Path.GetDirectoryName(Application.ExecutablePath) + "\\Zaposlenici.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    izbrisiPodatke();
                }               
            }
            catch(Exception poruka)
            {
                MessageBox.Show(poruka.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void izbrisiPodatke()
        {
            kontrolaUnosKluba1.izbrisiPodatke();
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validirajPodatkeKluba())
                {
                    throw new ArgumentException("Nisu validni svi podaci!");
                }
                else
                {
                    Klub k = new Klub(kontrolaUnosKluba1.Prefiks, kontrolaUnosKluba1.Naziv,
                                                kontrolaUnosKluba1.Mjesto, kontrolaUnosKluba1.BrojTelefona,
                                                        textBox1.Text);
                    xmlSerijalizer = new XmlSerializer(typeof(Klub));
                    using (FileStream xmlDatoteka = File.Create(Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi\\" + k.Naziv + ".xml"))
                    {
                        xmlSerijalizer.Serialize(xmlDatoteka, k);
                    }

                    sviKlubovi.Add(k);
                    
                    MessageBox.Show("Zaposlenik je uspješno sačuvan u XML datoteku koja se nalazi na lokaciji: " + Path.GetDirectoryName(Application.ExecutablePath) + "\\Zaposlenici.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    izbrisiPodatke();
                }
            }
            catch (Exception poruka)
            {
                MessageBox.Show(poruka.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                xmlSerijalizer = new XmlSerializer(typeof(List<Klub>));
                using (FileStream xmlDatoteka = File.Create(Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi\\" + "klubovi.xml"))
                {
                    xmlSerijalizer.Serialize(xmlDatoteka, sviKlubovi);
                }
                MessageBox.Show("Zaposlenici su uspješno sačuvani iz liste u XML datoteku koja se nalazi na lokaciji: " + Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                sviKlubovi.Add(new Klub(kontrolaUnosKluba1.Prefiks, kontrolaUnosKluba1.Naziv,
                                                kontrolaUnosKluba1.Mjesto, kontrolaUnosKluba1.BrojTelefona,
                                                        textBox1.Text));
                MessageBox.Show("Klub je uspjesno dodan u listu!", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                izbrisiPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                binSerijalizer = new BinaryFormatter();
                FileStream dat = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi\\" + "klubovi.bin", FileMode.Create, FileAccess.Write);
                binSerijalizer.Serialize(dat, sviKlubovi); 
                dat.Close();
                MessageBox.Show("Zaposlenici su uspješno sačuvani iz liste u binarnu datoteku koja se nalazi na lokaciji: " + Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Klub> spaseniProizvodi;
            try
            {
                openFileDialog1.FileName = "Binarna datoteka...";
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi\\";
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    binSerijalizer = new BinaryFormatter();
                    using (FileStream binDatoteka = File.Open(openFileDialog1.FileName, FileMode.Open))
                    {
                        BinaryReader binČitač = new BinaryReader(binDatoteka); 
                        spaseniProizvodi = binSerijalizer.Deserialize(binDatoteka) as List<Klub>;
                    }
                    Form8 forma = new Form8(spaseniProizvodi);
                    forma.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form9 forma = new Form9();
            this.Hide();
            forma.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form10 forma = new Form10();
            this.Hide();
            forma.ShowDialog();
            this.Show();
        }
    }
}
