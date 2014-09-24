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
using System.Xml; //Include this name space inorder to use SqlBulkCopy<
using System.Xml.Schema;

namespace XMLValidator
{
    public partial class ChooseXMLFile : Form
    {
        String fileName;
        String schemaName;

        public ChooseXMLFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFDxml.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFDschema.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                MessageBox.Show("Select an XML file!");
            }
            else if (schemaName == null)
            {
                MessageBox.Show("Select a Schema file!");
            }
            else
            {
                // validate the XML file
                if (ValidateXmlWithXsd(fileName, schemaName))
                {
                    MessageBox.Show("valid XML!");
                }
                else
                {
                    MessageBox.Show("Not valid XML");
                }
            }
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fileName = openFDxml.FileName;
            filePathTextBox.Text = fileName;
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            schemaName = openFDxml.FileName;
            schemaPathTextBox.Text = schemaName;
        }

        private static bool ValidateXmlWithXsd(string xmlUri, string xsdUri)
        {
            try
            {
                XmlReaderSettings xmlSettings = new XmlReaderSettings();
                xmlSettings.Schemas = new System.Xml.Schema.XmlSchemaSet();
                xmlSettings.ValidationType = ValidationType.Schema;
                XmlReader reader = XmlReader.Create(xmlUri, xmlSettings);

                // Parse the file.
                while (reader.Read()) ;

                return true;
            }
            catch (System.Xml.XmlException ex)
            {
                return false;
            }
        }
            
    }
}
