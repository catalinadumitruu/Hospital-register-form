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
    public partial class Form_Pacienti : Form
    {
        Pacienti pacient;
        string Provider;

        public Form_Pacienti()
        { 
            InitializeComponent();
            Provider = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = proiect_spital2.accdb";
            UpdateList();
        }

        public Form_Pacienti(Pacienti p)
        {
            pacient = p;
            InitializeComponent();
        }

        public void UpdateList()
        {
            listView1.Items.Clear(); 
            OleDbConnection conexiune = new OleDbConnection(Provider);
            string sql = "SELECT * FROM pacienti;";
            OleDbCommand comanda = new OleDbCommand(sql,conexiune);

            try
            {
                conexiune.Open();
                OleDbDataReader reader = comanda.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["id_pacient"].ToString());
                    item.SubItems.Add(reader["nume"].ToString());
                    item.SubItems.Add(reader["varsta"].ToString());
                    item.SubItems.Add(reader["denumire_boala"].ToString());
                    item.SubItems.Add(reader["grupa_sange"].ToString());
                    item.SubItems.Add(reader["alergii"].ToString());
                    item.SubItems.Add(reader["CNP"].ToString());
                    item.SubItems.Add(reader["medic"].ToString());

                    Pacienti pacient = new Pacienti();

                    pacient.Id_pacient = Convert.ToInt32(reader["id_pacient"].ToString());
                    pacient.Nume = reader["nume"].ToString();
                    pacient.Varsta = Convert.ToInt32(reader["varsta"].ToString());
                    pacient.Denumire_boala = reader["denumire_boala"].ToString();
                    pacient.Grupa_sange = reader["grupa_sange"].ToString();
                    pacient.Alergii = reader["alergii"].ToString();
                    pacient.Cnp = reader["CNP"].ToString();
                    pacient.Medic = reader["medic"].ToString();
             

                    item.Tag = pacient;
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

        private void adaugaIntregistrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_adauga_pacient form_add_pacient = new Form_adauga_pacient();
            form_add_pacient.ShowDialog();

            if(form_add_pacient.DialogResult == DialogResult.OK)
            {
                OleDbConnection conexiune = new OleDbConnection(Provider);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                try
                {
                    conexiune.Open();
                    comanda.Transaction = conexiune.BeginTransaction();

                    comanda.CommandText = "SELECT max(id_pacient) FROM pacienti";
                    int cod = Convert.ToInt32(comanda.ExecuteScalar());

                    comanda.CommandText = "INSERT INTO pacienti(id_pacient,nume,varsta,denumire_boala,grupa_sange,alergii,CNP,medic)  VALUES(@id_pacient,@nume,@varsta,@denumire_boala,@grupa_sange,@alergii,@CNP,@medic)";

                    comanda.Parameters.Add("id_pacient", OleDbType.Integer).Value = cod + 1;
                    comanda.Parameters.Add("nume", OleDbType.Char).Value = form_add_pacient.pacient.Nume;
                    comanda.Parameters.Add("varsta", OleDbType.Integer).Value = form_add_pacient.pacient.Varsta;
                    comanda.Parameters.Add("denumire_boala", OleDbType.Char).Value = form_add_pacient.pacient.Denumire_boala;
                    comanda.Parameters.Add("grupa_sange", OleDbType.Char).Value = form_add_pacient.pacient.Grupa_sange;
                    comanda.Parameters.Add("alergii", OleDbType.Char).Value = form_add_pacient.pacient.Alergii;
                    comanda.Parameters.Add("CNP", OleDbType.Char).Value = form_add_pacient.pacient.Cnp;
                    comanda.Parameters.Add("medic", OleDbType.Char).Value = form_add_pacient.pacient.Medic;
 
                    Form_Medici form_Med = new Form_Medici();
                    List<TreeNode> lista_medici = new List<TreeNode>();
                    
                    foreach(TreeNode medic in form_Med.treeView1.Nodes)
                    {
                        lista_medici.Add(medic);
                    }

                    //for(int i = 0; i<lista_medici.Count; i++)
                    //{
                      //  MessageBox.Show(lista_medici[i].ToString());
                    //}
                   
                    int j = 0;
                        while(j < lista_medici.Count && form_add_pacient.pacient.Medic != lista_medici[j].ToString())
                        {
                            j++;
                        }
                    //MessageBox.Show("Medicul " + lista_medici[j].ToString());
                        if ( j == lista_medici.Count) //daca a ajuns la finalul listei si nu a gasit medicul in lista => nod nou si adauga medic nou
                        { 
                        MessageBox.Show("Medicul introdus nu figureaza in baza de date. Doriti o inregistrare noua?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            form_Med.adaugaInregistrareToolStripMenuItem_Click(sender,e, form_add_pacient.pacient.Medic);
                        //MessageBox.Show("Medic adaugat", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else // daca a gasit medicul cautat => adauga un copil la nodul respectiv
                        {
                        MessageBox.Show(Convert.ToString(lista_medici[j]));
                        MessageBox.Show(form_add_pacient.pacient.Nume);
                        MessageBox.Show(form_add_pacient.pacient.Denumire_boala);
                            form_Med.treeView1.Nodes[j].Nodes.Add(form_add_pacient.pacient.Nume + ", diagnosticat cu " + form_add_pacient.pacient.Denumire_boala);
                            MessageBox.Show("S-a adaugat pacientul la un medic deja existent!!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                   // form_Med.nr_pacienti++;

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

        private void modificaInregistrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_adauga_pacient form_adauga_pacient = new Form_adauga_pacient((Pacienti)listView1.SelectedItems[0].Tag);
            form_adauga_pacient.ShowDialog();

            if(form_adauga_pacient.DialogResult == DialogResult.OK)
            {
                OleDbConnection conexiune = new OleDbConnection(Provider);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                try
                {
                    conexiune.Open();
                    comanda.Transaction = conexiune.BeginTransaction();

                    // comanda.CommandText = "SELECT nume FROM pacienti WHERE id_pacient = @id";
                   //comanda.Parameters.Add("id", OleDbType.Integer).Value = Convert.ToInt32(((Pacienti)listView1.SelectedItems[0].Tag).Id_pacient);
                   // string nume_pacient = comanda.ExecuteScalar().ToString();

                    comanda.CommandText = "UPDATE pacienti SET nume =@nume, varsta =@varsta, denumire_boala =@denumire_boala, grupa_sange =@grupa_sange, alergii = @alergii, CNP = @cnp,medic =@medic WHERE id_pacient = @id_pacient";
                    
                    comanda.Parameters.Add("nume", OleDbType.Char).Value = form_adauga_pacient.pacient.Nume;
                    comanda.Parameters.Add("varsta", OleDbType.Integer).Value = form_adauga_pacient.pacient.Varsta;
                    comanda.Parameters.Add("denumire_boala", OleDbType.Char).Value = form_adauga_pacient.pacient.Denumire_boala;
                    comanda.Parameters.Add("grupa_sange", OleDbType.Char).Value = form_adauga_pacient.pacient.Grupa_sange;
                    comanda.Parameters.Add("alergii", OleDbType.Char).Value = form_adauga_pacient.pacient.Alergii;
                    comanda.Parameters.Add("cnp", OleDbType.Char).Value = form_adauga_pacient.pacient.Cnp;
                    comanda.Parameters.Add("medic", OleDbType.Char).Value = form_adauga_pacient.pacient.Medic;
                    comanda.Parameters.Add("id_pacient", OleDbType.Integer).Value = Convert.ToInt32(((Pacienti)listView1.SelectedItems[0].Tag).Id_pacient);

                    //facem update si in lista medicilor cu pacienti

                    Form_Medici form_Med = new Form_Medici();
                    List<TreeNode> lista_medici = new List<TreeNode>();

                    foreach (TreeNode medic in form_Med.treeView1.Nodes)
                    {
                        lista_medici.Add(medic);
                    }

                    int j = 0;
                    while (j < lista_medici.Count && form_adauga_pacient.pacient.Nume != lista_medici[j].ToString())
                    {
                        j++;
                    }

                    TreeNode nou = new TreeNode(form_adauga_pacient.pacient.Nume + ", diagnosticat cu" + form_adauga_pacient.pacient.Denumire_boala);

                    if (j == lista_medici.Count) { }
                    else
                    {
                        form_Med.treeView1.Nodes[j] = nou;
                    }

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

                comanda.CommandText = "SELECT nume FROM pacienti WHERE id_pacient = @id";
                comanda.Parameters.Add("id", OleDbType.Integer).Value = Convert.ToInt32(((Pacienti)listView1.SelectedItems[0].Tag).Id_pacient);
                string nume_pacient = comanda.ExecuteNonQuery().ToString();

                comanda.CommandText = "DELETE FROM pacienti WHERE id_pacient = @id_pacient";

                comanda.Parameters.Add("id_pacient", OleDbType.Integer).Value = Convert.ToInt32(((Pacienti)listView1.SelectedItems[0].Tag).Id_pacient);

                //stergem pacientul si din lista medicului de care apartine
                Form_Medici form_Med = new Form_Medici();
                List<TreeNode> lista_medici = new List<TreeNode>();

                foreach (TreeNode medic in form_Med.treeView1.Nodes)
                {
                    lista_medici.Add(medic);
                }

                int j = 0;
                while (j < lista_medici.Count && nume_pacient != lista_medici[j].ToString())
                {
                    j++;
                }

                if (j == lista_medici.Count) { }
                else
                {
                    form_Med.treeView1.Nodes.Remove(form_Med.treeView1.Nodes[j]);
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Items[1].Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_imprimare form = new Form_imprimare();
            form.ShowDialog();
        }
    }
}
