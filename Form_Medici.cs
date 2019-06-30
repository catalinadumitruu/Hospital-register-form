using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_paw_spital
{
    public partial class Form_Medici : Form
    {
        Medici med;
        string Provider;
        public int nr_pacienti = 0;

        public Form_Medici()
        {
            InitializeComponent();
            Provider = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = proiect_spital2.accdb";
            UpdateList();
        }

        public Form_Medici(Medici m)
        {
            med = m;
            InitializeComponent();
        }

        public void UpdateList()
        {
            listView1.Items.Clear();
            treeView1.Nodes.Clear();
            OleDbConnection conexiune = new OleDbConnection(Provider);
            string sql = "SELECT * FROM medici";
            OleDbCommand comanda = new OleDbCommand(sql, conexiune);

            try
            {
                conexiune.Open();
                OleDbDataReader reader = comanda.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["id_medic"].ToString());
                    item.SubItems.Add(reader["nume"].ToString());
                    item.SubItems.Add(reader["varsta"].ToString());
                    item.SubItems.Add(reader["ore_lucrate_pe_saptamana"].ToString());
                    item.SubItems.Add(reader["salariul"].ToString());
                    item.SubItems.Add(reader["numar_pacienti"].ToString());
                    item.SubItems.Add(reader["departament"].ToString());

                    Medici medic = new Medici();
                    medic.Id_medic = Convert.ToInt32(reader["id_medic"].ToString());
                    medic.Nume = reader["nume"].ToString();
                    medic.Varsta = Convert.ToInt32(reader["varsta"].ToString());
                    medic.Ore_lucrate = Convert.ToDouble(reader["ore_lucrate_pe_saptamana"].ToString());
                    medic.Salariul = Convert.ToDouble(reader["salariul"].ToString());
                    medic.Numar_pacienti = Convert.ToInt32(reader["numar_pacienti"].ToString());
                    medic.Departament = reader["departament"].ToString();

                    nr_pacienti = medic.Numar_pacienti;

                    string sql2 = "SELECT nume, denumire_boala FROM pacienti WHERE medic = @Med";
                    OleDbCommand comanda2 = new OleDbCommand(sql2, conexiune);
                    OleDbParameter param = new OleDbParameter();
                    param.ParameterName = "@Med";
                    param.Value = medic.Nume;
                    comanda2.Parameters.Add(param);

                    OleDbDataReader reader2 = comanda2.ExecuteReader();

                    TreeNode node = new TreeNode(medic.Nume);
                    treeView1.Nodes.Add(node);

                    while (reader2.Read())
                    {
                        node.Nodes.Add(reader2["nume"].ToString() + ", diagnosticat cu " +reader2["denumire_boala"].ToString()); 
                    }

                    item.Tag = medic;
                    listView1.Items.Add(item);

                }

            }catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }

        private void adaugaInregistrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_adauga_medic form_add_medic = new Form_adauga_medic();
            form_add_medic.ShowDialog();

            if(form_add_medic.DialogResult == DialogResult.OK)
            {
                OleDbConnection conexiune = new OleDbConnection(Provider);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                try
                {
                    conexiune.Open();
                    comanda.Transaction = conexiune.BeginTransaction();

                    comanda.CommandText = "SELECT max(id_medic) FROM medici;";
                    int cod = Convert.ToInt32(comanda.ExecuteScalar());

                    comanda.CommandText = "INSERT INTO medici(id_medic,nume,varsta,ore_lucrate_pe_saptamana,salariul,numar_pacienti,departament) " +
                                           " VALUES (@id_medic,@nume,@varsta,@ore_lucrate_pe_saptamana,@salariul,@numar_pacienti,@departament);";

                    comanda.Parameters.Add("id_medic", OleDbType.Integer).Value = cod + 1;
                    comanda.Parameters.Add("nume", OleDbType.Char).Value = form_add_medic.medic.Nume;
                    comanda.Parameters.Add("varsta", OleDbType.Integer).Value = form_add_medic.medic.Varsta;
                    comanda.Parameters.Add("ore_lucrate_pe_saptamana", OleDbType.Double).Value = form_add_medic.medic.Ore_lucrate;
                    comanda.Parameters.Add("salariul", OleDbType.Double).Value = form_add_medic.medic.Salariul;
                    comanda.Parameters.Add("numar_pacienti", OleDbType.Integer).Value = 0;
                    comanda.Parameters.Add("departament", OleDbType.Char).Value = form_add_medic.medic.Departament;

                    TreeNode newNode = new TreeNode(form_add_medic.medic.Nume);
                    treeView1.Nodes.Add(newNode);
                    
                    comanda.ExecuteNonQuery();
                    comanda.Transaction.Commit();

                }catch(OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                    comanda.Transaction.Rollback();
                }
                finally
                {
                    conexiune.Close();
                }

                UpdateList();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Items[1].Enabled = true;
                contextMenuStrip1.Items[2].Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;

            }
        }

        public void adaugaInregistrareToolStripMenuItem_Click(object sender, EventArgs e,string nume)
        {
            Form_adauga_medic form_add_medic = new Form_adauga_medic(nume);
            form_add_medic.ShowDialog();

            if (form_add_medic.DialogResult == DialogResult.OK)
            {
                OleDbConnection conexiune = new OleDbConnection(Provider);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                try
                {
                    conexiune.Open();
                    comanda.Transaction = conexiune.BeginTransaction();

                    comanda.CommandText = "SELECT max(id_medic) FROM medici;";
                    int cod = Convert.ToInt32(comanda.ExecuteScalar());

                    comanda.CommandText = "INSERT INTO medici(id_medic,nume,varsta,ore_lucrate_pe_saptamana,salariul,numar_pacienti,departament) " +
                                           " VALUES (@id_medic,@nume,@varsta,@ore_lucrate_pe_saptamana,@salariul,@numar_pacienti,@departament);";
                   
                    comanda.Parameters.Add("id_medic", OleDbType.Integer).Value = cod + 1;
                    comanda.Parameters.Add("nume", OleDbType.Char).Value = nume;
                    comanda.Parameters.Add("varsta", OleDbType.Integer).Value = form_add_medic.medic.Varsta;
                    comanda.Parameters.Add("ore_lucrate_pe_saptamana", OleDbType.Double).Value = form_add_medic.medic.Ore_lucrate;
                    comanda.Parameters.Add("salariul", OleDbType.Double).Value = form_add_medic.medic.Salariul;
                    comanda.Parameters.Add("numar_pacienti", OleDbType.Integer).Value = nr_pacienti;
                    comanda.Parameters.Add("departament", OleDbType.Char).Value = form_add_medic.medic.Departament;

                    TreeNode newNode = new TreeNode(nume);
                    treeView1.Nodes.Add(newNode);

                    comanda.ExecuteNonQuery();
                    comanda.Transaction.Commit();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                    comanda.Transaction.Rollback();
                }
                finally
                {
                    conexiune.Close();
                }

                UpdateList();
            }
        }

        private void stergeInregistrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(Provider);
            OleDbCommand comanda = new OleDbCommand();
            comanda.Connection = conexiune;

            try
            {
                conexiune.Open();
                comanda.Transaction = conexiune.BeginTransaction();

                comanda.CommandText = "DELETE FROM medici WHERE id_medic = @id_medic";

                comanda.Parameters.Add("id_medic", OleDbType.Integer).Value = Convert.ToInt32(((Medici)listView1.SelectedItems[0].Tag).Id_medic);

                int index = 0;
                while(index < treeView1.Nodes.Count && treeView1.Nodes[index].Name != ((Medici)(listView1.SelectedItems[0].Tag)).Nume)
                {
                        index++;
                }

                if(index == treeView1.Nodes.Count) { }     
                else
                {
                    treeView1.Nodes.Remove(treeView1.Nodes[index]);
                }
               
                comanda.ExecuteScalar();
                comanda.Transaction.Commit();
            }catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                comanda.Transaction.Rollback();
            }
            finally
            {
                conexiune.Close();
            }

            UpdateList();
        }

        private void modificaInregistrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_adauga_medic form_Adauga_Medic = new Form_adauga_medic((Medici)listView1.SelectedItems[0].Tag);
            form_Adauga_Medic.ShowDialog();

            if(form_Adauga_Medic.DialogResult == DialogResult.OK)
            {
                OleDbConnection conexiune = new OleDbConnection(Provider);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                try
                {
                    conexiune.Open();
                    comanda.Transaction = conexiune.BeginTransaction();

                    //comanda.CommandText = "SELECT nume FROM medici WHERE id_medic = @id_m";
                    //comanda.Parameters.Add("id_medic", OleDbType.Integer).Value = Convert.ToInt32(((Medici)listView1.SelectedItems[0].Tag).Id_medic);
                   // string nume_for_update = comanda.ExecuteNonQuery().ToString();

                    comanda.CommandText = "UPDATE medici SET nume = @nume, varsta=@varsta, ore_lucrate_pe_saptamana = @ore_lucrate,salariul = @salariul,departament=@dep WHERE id_medic=@id_medic";
                   
                    comanda.Parameters.Add("nume", OleDbType.Char).Value = form_Adauga_Medic.medic.Nume;
                    comanda.Parameters.Add("varsta", OleDbType.Integer).Value = form_Adauga_Medic.medic.Varsta;
                    comanda.Parameters.Add("ore_lucrate", OleDbType.Double).Value = form_Adauga_Medic.medic.Ore_lucrate;
                    comanda.Parameters.Add("salariul", OleDbType.Double).Value = form_Adauga_Medic.medic.Salariul;
                    comanda.Parameters.Add("nume", OleDbType.Char).Value = form_Adauga_Medic.medic.Nume;
                    comanda.Parameters.Add("id_medic", OleDbType.Integer).Value = Convert.ToInt32(((Medici)listView1.SelectedItems[0].Tag).Id_medic);

                    int j = 0;
                    while(j<treeView1.Nodes.Count && treeView1.Nodes[j].Name != form_Adauga_Medic.medic.Nume)
                    {
                        j++;
                    }

                    TreeNode node = new TreeNode(form_Adauga_Medic.medic.Nume);

                    if (j == treeView1.Nodes.Count) { }
                    else
                    {
                        treeView1.Nodes[j] = node;
                    }

                    comanda.ExecuteScalar();
                    comanda.Transaction.Commit();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                    comanda.Transaction.Rollback();
                }
                finally
                {
                    conexiune.Close();
                }

                UpdateList();
            }
        }
        // in fisierul text se salveaza raport medici -  medicii + pacienti care le revin
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Fisier detalii medici(*.txt)|*.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);

                foreach (ListViewItem medic in listView1.Items)
                {
                    writer.WriteLine(" <> " + ((Medici)medic.Tag).ToString());

                    List<string> pacienti = new List<string>();

                    OleDbConnection conexiune = new OleDbConnection(Provider);
                    string sql = "SELECT * FROM pacienti WHERE medic = @med";
                    OleDbCommand comanda = new OleDbCommand(sql, conexiune);

                    try
                    {
                        conexiune.Open();
                        comanda.Transaction = conexiune.BeginTransaction();

                        comanda.Parameters.Add("med", OleDbType.Char).Value = ((Medici)medic.Tag).Nume;

                        OleDbDataReader reader = comanda.ExecuteReader();

                        while (reader.Read())
                        {
                            pacienti.Add(reader["nume"].ToString() + " are " + reader["varsta"].ToString() + " ani, este diagnosticat cu " +
                                        reader["denumire_boala"].ToString() + ", grupa de sange este " + reader["grupa_sange"].ToString() +
                                        " si CNP-ul: " + reader["cnp"].ToString());
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

                    int i = 1;

                    foreach(string p in pacienti)
                    {
                        writer.WriteLine(" Pacientul  " + i +":  >> " + p);
                        i++;
                    }
                }                
                writer.Close();
                fs.Close();
                MessageBox.Show("Text file has been written", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //se salveaza criptat medicii si salariul castigat
        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Fisier binar(*.dat)|*.dat";

            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write);
                List<string> list = new List<string>();

                OleDbConnection conexiune = new OleDbConnection(Provider);

                try
                {
                    conexiune.Open();

                    foreach (ListViewItem medic in listView1.Items)
                    {
                        string sql = "SELECT nume, salariul FROM medici WHERE id_medic = @med";
                        OleDbCommand comanda = new OleDbCommand(sql, conexiune);
                        comanda.Parameters.Add("med", OleDbType.Integer).Value = ((Medici)medic.Tag).Id_medic;

                        OleDbDataReader reader = comanda.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add("Medicul " + reader["nume"].ToString() + " castiga " + reader["salariul"].ToString() + " RON");
                        }
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

                BinaryFormatter binaryForm = new BinaryFormatter();
                binaryForm.Serialize(fs, list);

                fs.Close();
                MessageBox.Show("Binary file created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sunteti pe cale sa accesati informatii private.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Form_info_criptate info = new Form_info_criptate();
            info.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_raport_medici raport = new Form_raport_medici();

            raport.ShowDialog();
        }
    }
}
