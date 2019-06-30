using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_paw_spital
{
    public partial class Form_Departamente : Form
    {
        Departamente dep;
        string Provider;

        public Form_Departamente()
        {
            InitializeComponent();
            Provider = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = proiect_spital2.accdb";
            UpdateList();
        }

        public Form_Departamente(Departamente d)
        {
            dep = d;
            InitializeComponent();
        }

        public void UpdateList()
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(Provider);
            string sql = "SELECT * FROM departamente;";
            OleDbCommand comanda = new OleDbCommand(sql, conexiune);
            try
            {
                conexiune.Open();
                OleDbDataReader reader = comanda.ExecuteReader();

                while (reader.Read()){
                    ListViewItem item = new ListViewItem(reader["id_departament"].ToString());
                    item.SubItems.Add(reader["denumire"].ToString());
                    item.SubItems.Add(reader["id_supervizor"].ToString());

                    Departamente dep = new Departamente();
                    dep.Id_departament = Convert.ToInt32(reader["id_departament"].ToString());
                    dep.Denumire = reader["denumire"].ToString();
                    dep.Id_supervizor = Convert.ToInt32(reader["id_supervizor"].ToString());

                    item.Tag = dep;
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

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_adauga_departament form_adauga = new Form_adauga_departament();
            form_adauga.ShowDialog();

            if(form_adauga.DialogResult == DialogResult.OK)
            {
                OleDbConnection conexiune = new OleDbConnection(Provider);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                try
                {
                    conexiune.Open();
                    comanda.Transaction = conexiune.BeginTransaction();
                    comanda.CommandText = "SELECT max(id_departament) FROM departamente";
                    int cod = Convert.ToInt32(comanda.ExecuteScalar());

                    comanda.CommandText = "INSERT INTO departamente(id_departament,denumire,id_supervizor) " +
                        "                  VALUES(@id_departament,@denumire,@id_supervizor)";

                    comanda.Parameters.Add("id_departament", OleDbType.Integer).Value = cod + 1;
                    comanda.Parameters.Add("denumire", OleDbType.Char).Value = form_adauga.dep.Denumire;
                    comanda.Parameters.Add("id_supervizor", OleDbType.Integer).Value = form_adauga.dep.Id_supervizor;

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
              //  form_adauga.Validating += new CancelEventHandler(form_adauga.idSuper_txt_Validating);
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
                comanda.CommandText = "DELETE FROM departamente WHERE id_departament = @id_departamanet";
                
                comanda.Parameters.Add("id_departament", OleDbType.Integer).Value = Convert.ToInt32(((Departamente)listView1.SelectedItems[0].Tag).Id_departament);

                comanda.ExecuteScalar();
                comanda.Transaction.Commit();
            } catch(OleDbException ex)
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
            Form_adauga_departament update_form = new Form_adauga_departament((Departamente)listView1.SelectedItems[0].Tag);
            update_form.ShowDialog();

            if(update_form.DialogResult == DialogResult.OK)
            {

                OleDbConnection conexiune = new OleDbConnection(Provider);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                try
                {
                    conexiune.Open();
                    comanda.Transaction = conexiune.BeginTransaction();
                    comanda.CommandText = "UPDATE departamente SET denumire = @denumire, id_supervizor = @id_supervizor WHERE id_departament = @id_departament";

                    comanda.Parameters.Add("denumire", OleDbType.Char).Value = update_form.dep.Denumire;
                    comanda.Parameters.Add("id_supervizor", OleDbType.Integer).Value = update_form.dep.Id_supervizor;
                    comanda.Parameters.Add("id_departament", OleDbType.Integer).Value = update_form.dep.Id_departament;

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
            Clipboard.SetText(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.GetText();
        }
    }
}
