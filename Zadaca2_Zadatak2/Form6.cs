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
    public partial class Form6 : Form
    {
        List<Liga> lige = new List<Liga>();
        Liga l = new Liga();

        public List<Liga> Lige
        {
            get { return lige; }
            set { lige = value; }
        }
        public Liga L
        {
            get { return l; }
            set { l = value; }
        }
        
        public Form6(List<Liga> Lige)
        {
            InitializeComponent();
            lige = Lige;
            button2.Hide();
            label2.Hide();
            groupBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l = lige.Find(x => x.Mjesto == textBox1.Text);
            if (l == null)
            {
                MessageBox.Show("Nije pronadjena tražena liga!");
                this.Close();
            }
            button2.Show();
            label2.Show();
            groupBox1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            l.Aktivna = !(l.Aktivna);
            MessageBox.Show("Aktivnost lige je promijenjena!", "Poruka", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
