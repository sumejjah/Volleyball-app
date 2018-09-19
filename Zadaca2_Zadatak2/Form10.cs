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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            try
            {
                XmlTextReader citac = new XmlTextReader(@Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\Klubovi\\" + "klubovi.xml");

                while (citac.Read())
                { //3. provjerava se tip čvora, 
                    // u ovom slučaju se provjerava da li je element (početni) ili je sadržaj (tekst) uz element 
                    switch (citac.NodeType)
                    {
                        case XmlNodeType.Element:
                            listView1.Text += "\r\n" + citac.Name + ": ";
                            break;

                        case XmlNodeType.Text:
                            listView1.Text += citac.Value;
                            break;
                    }
                }
                citac.Close(); //4.zatvaranje streama
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
