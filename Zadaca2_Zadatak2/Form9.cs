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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            try
            {
                XmlDocument dokument = new XmlDocument();
                dokument.Load(@Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\Klubovi\\" + "klubovi.xml");

                XmlElement korijen = dokument.DocumentElement;
                treeView1.Nodes.Clear();

                treeView1.Nodes.Add(new TreeNode(dokument.DocumentElement.Name));

                TreeNode drvoCvor = treeView1.Nodes[0];

                dodajCvor(korijen, drvoCvor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dodajCvor(XmlNode XmlCvor, TreeNode drvoCvor)
        {
            XmlNode XmlTekuciCvor;
            // trenutni/tekući čvor u XML dokumentu 
            TreeNode drvoTekuciCvor;
            // trenutni/tekući čvor u treeView kontroli 
            XmlNodeList XmlListaCvorova;
            //koristi se za formiranje liste čvorova djece za tekući cvor
            if (XmlCvor.HasChildNodes) // provjerava da li XML čvor ima djece 
            {
                XmlListaCvorova = XmlCvor.ChildNodes; // formira se lista XML djece za trenutni čvor
                // dok god čvor ima djece
                for (int i = 0; i <= XmlListaCvorova.Count - 1; i++)
                { // tekući čvor je i-djete 
                    XmlTekuciCvor = XmlCvor.ChildNodes[i];
                    drvoCvor.Nodes.Add(new TreeNode(XmlTekuciCvor.Name)); // dodaj XML čvor u drvo 
                    drvoTekuciCvor = drvoCvor.Nodes[i];
                    dodajCvor(XmlTekuciCvor, drvoTekuciCvor); // rekurzivni poziv metode dodajCvor 
                }
            }
            else
            {
                drvoCvor.Text = XmlCvor.InnerText.ToString(); // tekst (sadržaj) elementa 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
