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
    public partial class Form7 : Form
    {
        Liga l;

        public Liga L
        {
            get { return l; }
            set { l = value; }
        }
        
        public Form7(Liga liga)
        {
            InitializeComponent();
            l = liga;

            List<Klub> lista = new List<Klub>();
            lista.AddRange(liga.Klubovi);

            lista.Sort(delegate(Klub a, Klub b)   //1-> prvi > drugi  ; 0 -> jednaki ; -1 -> prvi < drugi
            {
                if (a.OsvojeneUtakmice > b.OsvojeneUtakmice)
                    return -1; 
                else if (a.OsvojeneUtakmice == b.OsvojeneUtakmice)
                {
                    if (a.OsvojeniSetovi > b.OsvojeniSetovi)
                        return -1;
                    else if (a.OsvojeniSetovi == b.OsvojeniSetovi && a.IzgubljeniSetovi < b.IzgubljeniSetovi)
                        return -1;
                    else
                        return 0;
                }
                else if (a.OsvojeneUtakmice < b.OsvojeneUtakmice)
                    return 1; 
                else
                    return 0; 
            });


            DataTable tabela = new DataTable();
            tabela.Clear();
            tabela.Columns.Add("Rang", typeof(int));
            tabela.Columns.Add("Naziv kluba", typeof(string));
            tabela.Columns.Add("Osvojene utakmice", typeof(int));
            tabela.Columns.Add("Izgubljene utakmice", typeof(int));
            tabela.Columns.Add("Osvojeni setovi", typeof(int));
            tabela.Columns.Add("Izgubljeni setovi", typeof(int));
            tabela.Columns.Add("Ukupno poena", typeof(int));

            for (int i = 0; i < l.Klubovi.Count; i++)
            {
                DataRow red = tabela.NewRow();
                int ukupnoPoena = lista[i].OsvojeneUtakmice * 3;
                tabela.Rows.Add(i, lista[i].Prefiks + "  " + lista[i].Naziv, lista[i].OsvojeneUtakmice,
                    lista[i].IzgubljeneUtakmice, lista[i].OsvojeniSetovi, lista[i].IzgubljeniSetovi, ukupnoPoena);
            }

            dataGridView1.DataSource = tabela;
        }

      
    }
}
