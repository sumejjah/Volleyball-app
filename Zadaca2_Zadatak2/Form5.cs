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
    public partial class Form5 : Form
    {
        List<Liga> lige = new List<Liga>();

        public List<Liga> Lige
        {
            get { return lige; }
            set { lige = value; }
        }

        public Form5(List<Liga> Lige)
        {
            InitializeComponent();
            lige = Lige;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int brojLiga = 0;
            foreach (Liga l in lige)
            {
                if (l.Mjesto == textBox1.Text)
                    brojLiga++;
            }
            label1.Text = "Ukupan broj liga u navedenom mjestu je " + brojLiga.ToString();
            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
