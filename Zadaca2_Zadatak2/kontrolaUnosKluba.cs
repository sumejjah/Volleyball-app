using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Zadaca2_Zadatak2
{
    public partial class kontrolaUnosKluba : UserControl
    {
        private Klub klub;

        private string NIJEODABRAN = "Niste odabrali nista od ponuđenog!";
        private string MINIMALANBRZNAKOVA = "Minimalno 3 znaka!";
       
        public bool dozvoliPrelazak { get; set; }

        string prefiks, naziv, mjesto, brojTelefona, adresa;

        public string Prefiks
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.SelectedItem = value; }
        }

        public string Naziv
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Mjesto
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string BrojTelefona
        {
            get { return kontrolaUnosBrojaTelefona1.Broj; }
            set { kontrolaUnosBrojaTelefona1.Broj = value; }
        }
        /*
        public string Adresa
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }*/


        public kontrolaUnosKluba()
        {
            InitializeComponent();
            klub = new Klub();
            dozvoliPrelazak = true;
        }

        void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) //nista nije oznaceno
            {
                errorProvider1.SetError(comboBox1, NIJEODABRAN);
                e.Cancel = dozvoliPrelazak;
            }
            else
                ukloniError(comboBox1);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length < 3)
            {
                errorProvider1.SetError(textBox1, MINIMALANBRZNAKOVA);
                e.Cancel = dozvoliPrelazak;
            }
            else
            {
                ukloniError(textBox1);
            }
           
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Length < 3)
            {
                errorProvider1.SetError(textBox2, MINIMALANBRZNAKOVA);
                e.Cancel = dozvoliPrelazak;
            }
            else
                ukloniError(textBox2);
        }

        /*private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text.Length < 3)
            {
                toolStripStatusLabel1.Text = "Minimalan broj znakova je 3!";
                e.Cancel = dozvoliPrelazak;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
            }
        }*/

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex != -1)
            {
                klub.Prefiks = cb.SelectedItem.ToString();
                ukloniError(cb);
            }
        }

        private void ukloniError(Control C)
        {
            errorProvider1.SetError(C, "");
        }

        public bool SviPodaciUneseni()
        {
            if (comboBox1.SelectedIndex == -1)
                return false;
            else if (Naziv.Length < 3)
                return false;
            else if (Mjesto.Length < 3)
                return false;
           
            else
                return true;
               // return kontrolaUnosBrojaTelefona1.Broj.Length < 9 &&
                 //               Regex.IsMatch(kontrolaUnosBrojaTelefona1.Broj, @"^[0-9]$");
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 3)
                klub.Naziv = textBox1.Text;
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if(textBox2.Text.Length >= 3)
               klub.Mjesto = textBox2.Text;
        }

        public void izbrisiPodatke()
        {
            comboBox1.Refresh();
            textBox1.Clear();
            textBox2.Clear();
            kontrolaUnosBrojaTelefona1.ocisti();
        }
    }
}
