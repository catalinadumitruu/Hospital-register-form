using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Proiect_paw_spital
{
    public partial class Form_Retete : Form
    {
        Retete reteta;
        string Provider;

        public Form_Retete()
        {
            InitializeComponent();
            Provider = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = proiect_spital2.accdb";
            UpdateList();
        }

        public Form_Retete(Retete r)
        {
            reteta = r;
            InitializeComponent();
        }

        public void UpdateList()
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(Provider);
            string sql = "SELECT * FROM retete;";
            OleDbCommand comanda = new OleDbCommand(sql, conexiune);

            try
            {
                conexiune.Open();
                OleDbDataReader reader = comanda.ExecuteReader();
         
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["nr_crt"].ToString());
                    item.SubItems.Add(reader["pacient"].ToString());
                    item.SubItems.Add(reader["medic"].ToString());
                    item.SubItems.Add(reader["cantitate_medicamente"].ToString());
                    item.SubItems.Add(reader["pret"].ToString());
                    item.SubItems.Add(reader["data"].ToString());

                    Retete reteta = new Retete();
                    reteta.Nr_crt = Convert.ToInt32(reader["nr_crt"].ToString());
                    reteta.Pacient = reader["pacient"].ToString();
                    reteta.Medic = reader["medic"].ToString();
                    reteta.Cantitate = Convert.ToInt32(reader["cantitate_medicamente"].ToString());
                    reteta.Pret = Convert.ToDouble(reader["pret"].ToString());
                    reteta.Data = Convert.ToDateTime(reader["data"].ToString());

                    string sql2 = "SELECT denumire FROM medicamente WHERE nr_crt_reteta = @nrCRT";
                    OleDbCommand comanda2 = new OleDbCommand(sql2, conexiune);
                    OleDbParameter parameter = new OleDbParameter();
                    parameter.ParameterName = "@nrCRT";
                    parameter.Value = reteta.Nr_crt;
                    comanda2.Parameters.Add(parameter);
              
                    OleDbDataReader reader2 = comanda2.ExecuteReader();

                    TreeNode nod = new TreeNode(reteta.Pacient);
                        treeView1.Nodes.Add(nod);
                    while (reader2.Read())
                    {
                        nod.Nodes.Add(reader2["denumire"].ToString());
                    }

                    item.Tag = reteta;
                    listView1.Items.Add(item);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }


        //sa se salveze nume pacient -> data consultatie -> medicamente recomandate
        private void salveazaRaportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemoryStream memStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.UTF8);

            OleDbConnection conexiune = new OleDbConnection(Provider);
            
            string sql = "SELECT * FROM retete";
            OleDbCommand comanda = new OleDbCommand(sql, conexiune);

            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("Raport-pacienti-data-medicamente");

            try
            {
                conexiune.Open();

                OleDbDataReader reader = comanda.ExecuteReader();

                while (reader.Read())
                {
                    writer.WriteStartElement("raport");
                    
                    writer.WriteStartElement("nume_pacient");
                    writer.WriteValue(reader["pacient"].ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("data_consultatie");
                    writer.WriteValue(reader["data"].ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("nr_medicamente");
                    writer.WriteAttributeString("nr_medicamente", "tipuri_medicamente");
                    writer.WriteValue(reader["cantitate_medicamente"].ToString());
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                string XML = Encoding.UTF8.GetString(memStream.ToArray());

                memStream.Close();
                memStream.Dispose();

                StreamWriter streamWriter = new StreamWriter("raport.xml");
                streamWriter.WriteLine(XML);
                streamWriter.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
            MessageBox.Show("Fisier generat cu succes!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.DoDragDrop(button1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if ((e.KeyState & 8) == 8 &&
                    (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move; 
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Text = e.Data.GetData(DataFormats.Text).ToString();
            if (e.Effect == DragDropEffects.Move) button1.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_raport_retete form_raport_retete = new Form_raport_retete();
            form_raport_retete.ShowDialog();
        }


    }
}
