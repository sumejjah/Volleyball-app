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

namespace PosebnaKontrola
{
    public partial class kontrolaUnosBrojaTelefona : UserControl
    {
        private const string poruka = "Mora sadrzavati minimalno 9 znakova i svi moraju biti brojevi!";

        public kontrolaUnosBrojaTelefona()
        {
            InitializeComponent();
        }

        private string broj;

        public string Broj
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length < 9 && !Regex.IsMatch(textBox1.Text, @"^[0-9]$"))
            {
                errorProvider1.SetError(textBox1, poruka);
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        public void ocisti()
        {
            textBox1.Clear();
        }
    }
}
