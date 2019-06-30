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
    public partial class Form_adauga_departament : Form
    {
        public Departamente dep = new Departamente();
        string Provider;

        public Form_adauga_departament()
        {
            InitializeComponent();
           Provider = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = proiect_spital2.accdb";
        }

        public Form_adauga_departament(Departamente d)
        {
            dep = d;
            InitializeComponent();
            den_txt.Text = dep.Denumire;
            idSuper_txt.Text = dep.Id_supervizor.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int id_s = 0;
            string den = "";

            try
            {
                id_s = Convert.ToInt32(idSuper_txt.Text);
                den = den_txt.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dep.Id_supervizor = id_s;
            dep.Denumire = den;
        }

        //public void idSuper_txt_Validating(object sender, CancelEventArgs e)
        //{
        //    OleDbConnection conexiune = new OleDbConnection(Provider);
        //    string sql = "SELECT id_supervizor FROM departamente";
        //    OleDbCommand comanda = new OleDbCommand(sql, conexiune);
        //    List<int> list = new List<int>();

        //    try
        //    {
        //        conexiune.Open();
        //        OleDbDataReader reader = comanda.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            list.Add(Convert.ToInt32(reader["id_supervizor"].ToString()));
        //        }

        //    }
        //    catch (OleDbException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        conexiune.Close();
        //    }

        //    TextBox textBoxLocal = (TextBox)sender;

        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        //if (Convert.ToInt32(textBoxLocal.Text) == list[i]) errorProvider1.SetError(textBoxLocal, "ID-ul introdus exista deja!!!");
        //        //else errorProvider1.SetError(textBoxLocal, "");
        //    }

        //    if (textBoxLocal.SelectedText.Length < 0) errorProvider1.SetError(textBoxLocal, "!!!!!");
        //}


    }
}
