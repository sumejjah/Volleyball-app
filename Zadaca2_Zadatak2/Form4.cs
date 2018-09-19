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
    public partial class Form4 : Form
    {
        int rez1, rez2;
        bool dozvoliPrelaz;

        public int Rez1
        {
            get { return rez1; }
            set { rez1 = value; }
        }

        public int Rez2
        {
            get { return rez2; }
            set { rez2 = value; }
        }

        
        public Form4(string domaci, string gostujuci)
        {
            InitializeComponent();
            label3.Text = domaci;
            label4.Text = gostujuci;
            dozvoliPrelaz = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //unakrsna validacija 
            if ((int)numericUpDown1.Value == 0 && (int)numericUpDown2.Value == 0 || 
                        (int)numericUpDown1.Value == 3 && (int)numericUpDown2.Value == 3 ||
                            (int)numericUpDown1.Value == 2 && (int)numericUpDown2.Value == 2)
                errorProvider1.SetError(button1, "Unesni rezultat utakmice nije uredu!");
            else
            {
                errorProvider1.SetError(button1, "");

                rez1 = (int)numericUpDown1.Value;
                rez2 = (int)numericUpDown2.Value;

                this.Close();
            }
        }

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            if (numericUpDown1.Value > 3)
            {
                errorProvider1.SetError(numericUpDown1, "Max broj osvojenih setova je 3");
                e.Cancel = !dozvoliPrelaz;
            }
            else
                errorProvider1.SetError(numericUpDown1, "");
        }

        private void numericUpDown2_Validating(object sender, CancelEventArgs e)
        {
            if (numericUpDown2.Value > 3)
            {
                errorProvider1.SetError(numericUpDown2, "Max broj osvojenih setova je 3");
                e.Cancel = !dozvoliPrelaz;
            }
            else
                errorProvider1.SetError(numericUpDown2, "");
        }
    }
}
