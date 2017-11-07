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
using System.Xml.Linq;

namespace RemoveZero
{
    public partial class Form1 : Form
    {
        string fileName = "";
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string fName in openFileDialog1.FileNames)
                {
                    fileName = fName;
                    XmlReader reader = XmlReader.Create(fileName);
                    XDocument doc = XDocument.Load(reader);
                    reader.Close();

                    doc.Element("DECLAR").
                        Element("DECLARBODY").
                        SetElementValue("HNUM", (Convert.ToInt32(doc.Element("DECLAR").
                        Element("DECLARBODY").
                        Element("HNUM").Value)).
                        ToString());                    
                    doc.Save(fileName);
                    textBox1.Text += (++i).ToString() + ".  " + fileName + " compleet" + Environment.NewLine;
                }
                textBox1.Text += "Total: " + i.ToString();
            }
        }
    }
}
