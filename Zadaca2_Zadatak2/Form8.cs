using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zadaca2_Zadatak2
{
    public partial class Form8 : Form
    {
        List<Klub> klubovi;
        private BindingSource izvorSpajanja;
        IFormatter binSerijalizer;

        public List<Klub> Klubovi
        {
            get { return klubovi; }
            set { klubovi = value; }
        }

        public Form8(List<Klub> k)
        {
            InitializeComponent();
            klubovi = k;
            izvorSpajanja = new BindingSource();
            izvorSpajanja.DataSource = klubovi;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = izvorSpajanja;
            postaviKoloneTabeleKlubova();
        }

        private void postaviKoloneTabeleKlubova()
        {
            DataGridViewTextBoxColumn kolonaTabeleKlubova1 = new DataGridViewTextBoxColumn();
            kolonaTabeleKlubova1.DataPropertyName = "Prefiks";
            kolonaTabeleKlubova1.Name = "kolona1";
            kolonaTabeleKlubova1.HeaderText = "Prefiks";
            dataGridView1.Columns.Add(kolonaTabeleKlubova1);

            DataGridViewTextBoxColumn kolonaTabeleKlubova2 = new DataGridViewTextBoxColumn();
            kolonaTabeleKlubova2.DataPropertyName = "Naziv";
            kolonaTabeleKlubova2.Name = "kolona2";
            kolonaTabeleKlubova2.HeaderText = "Naziv";
            dataGridView1.Columns.Add(kolonaTabeleKlubova2);

            DataGridViewTextBoxColumn kolonaTabeleKlubova3 = new DataGridViewTextBoxColumn();
            kolonaTabeleKlubova3.DataPropertyName = "Mjesto";
            kolonaTabeleKlubova3.Name = "kolona3";
            kolonaTabeleKlubova3.HeaderText = "Mjesto";
            dataGridView1.Columns.Add(kolonaTabeleKlubova3);

            DataGridViewTextBoxColumn kolonaTabeleKlubova4 = new DataGridViewTextBoxColumn();
            kolonaTabeleKlubova4.DataPropertyName = "BrojTelefona";
            kolonaTabeleKlubova4.Name = "kolona4";
            kolonaTabeleKlubova4.HeaderText = "BrojTelefona";
            dataGridView1.Columns.Add(kolonaTabeleKlubova4);

            DataGridViewTextBoxColumn kolonaTabeleKlubova5 = new DataGridViewTextBoxColumn();
            kolonaTabeleKlubova5.DataPropertyName = "Adresa";
            kolonaTabeleKlubova5.Name = "kolona5";
            kolonaTabeleKlubova5.HeaderText = "Adresa";
            dataGridView1.Columns.Add(kolonaTabeleKlubova5);
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            (sender as DataGridView).CurrentRow.ReadOnly = true; //može se mijenjati broj telefona i adresa
            if ((sender as DataGridView).CurrentRow.IsNewRow || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                (sender as DataGridView).CurrentRow.ReadOnly = false;
            }
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((DialogResult = MessageBox.Show("Da li želite sačuvati zaposlenike iz tabele u binarnu datoteku?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    foreach (Klub klub in klubovi)
                    {
                        bool klubIzabran = true;
                        foreach (DataGridViewRow redTabele in dataGridView1.Rows)
                        {
                            if (redTabele.DataBoundItem as Klub != null && !redTabele.IsNewRow && klub.Naziv == (redTabele.DataBoundItem as Klub).Naziv)
                            {
                                klub.BrojTelefona = redTabele.Cells[3].Value.ToString();
                                klub.Adresa = redTabele.Cells[4].Value.ToString();
                                klubIzabran = false;
                            }
                        }
                        if (klubIzabran)
                        {
                            klubovi.Remove(klub);
                        }
                    }
                    foreach (DataGridViewRow redTabele in dataGridView1.Rows)
                    {
                        if (redTabele.DataBoundItem as Klub != null && redTabele.IsNewRow)
                        {
                            klubovi.Add(redTabele.DataBoundItem as Klub);
                        }
                    }

                    binSerijalizer = new BinaryFormatter();
                    FileStream dat = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\Klubovi\\" + "klubovi.bin", FileMode.Create, FileAccess.Write);
                    binSerijalizer.Serialize(dat, klubovi);
                    dat.Close();

                    MessageBox.Show("Zaposlenici su uspješno sačuvani iz tabele u XML datoteku koja se nalazi na lokaciji: " + Path.GetDirectoryName(Application.ExecutablePath) +
                                    "\\Klubovi.\n\nNAPOMENA: Isključivo izmjene nad brojem telefona i adresom su sačuvane.", 
                                        "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
