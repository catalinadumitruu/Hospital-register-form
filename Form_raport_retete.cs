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
    public partial class Form_raport_retete : Form
    {
        private BindingManagerBase bmPacient;
        private BindingManagerBase bmMedicamente;
        private DataSet ds;
       
        public Form_raport_retete()
        {
            InitializeComponent();
            InitializeazaDate();
        }

        private void InitializeazaDate()
        {
            InitializareDS(); 
            BindControls();
        }

        private void InitializareDS()
        {
            ds = new DataSet("DataSetHospital");

            DataTable table_pacienti = new DataTable("Pacienti");
            DataTable table_medicamente = new DataTable("Medicamente");

            DataColumn id_pacient = new DataColumn("id_pacient", typeof(int));
            DataColumn Nume = new DataColumn("Nume");
            table_pacienti.Columns.Add(id_pacient);
            table_pacienti.Columns.Add(Nume);

            DataColumn denumire_medicament = new DataColumn("denumire_medicament");
            DataColumn id_pacient_med = new DataColumn("id_pacient_med", typeof(int));
       
            table_medicamente.Columns.Add(denumire_medicament);
            table_medicamente.Columns.Add(id_pacient_med);

            this.ds.Tables.Add(table_pacienti);
            this.ds.Tables.Add(table_medicamente);

            DataRelation data_relation = new DataRelation("pacienti-medicamente", id_pacient, id_pacient_med);
            this.ds.Relations.Add(data_relation);

            DataRow newRow1;
            DataRow newRow2;
                
                for(int i = 0; i < 5; i++)
                {
                    newRow1 = table_pacienti.NewRow();
                    newRow1["id_pacient"] = i;
                    table_pacienti.Rows.Add(newRow1);
                }

            table_pacienti.Rows[0]["Nume"] = "Toader Mara";
            table_pacienti.Rows[1]["Nume"] = "Zlotea Eliza";
            table_pacienti.Rows[2]["Nume"] = "Nita Alina";
            table_pacienti.Rows[3]["Nume"] = "Barbu Luca";
            table_pacienti.Rows[4]["Nume"] = "Tudose Alexandru";


            List<string> lista_med = new List<string>();
            lista_med.Add("Zinnat");
            lista_med.Add("Cefuroxim");
            lista_med.Add("Paracetamol");

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    newRow2 = table_medicamente.NewRow();
                    newRow2["id_pacient_med"] = i;
                    newRow2["denumire_medicament"] = lista_med[j];
                    table_medicamente.Rows.Add(newRow2);
                }
            }
                
        }

        private void BindControls()
        {
            textBox1.DataBindings.Add(new Binding("Text", ds, "pacienti.Nume"));
            textBox3.DataBindings.Add(new Binding("Text", ds, "pacienti.id_pacient"));

            textBox2.DataBindings.Add("Text", ds, "pacienti.pacienti-medicamente.denumire_medicament");

            bmPacient = this.BindingContext[ds, "Pacienti"];
            bmMedicamente = this.BindingContext[ds, "Pacienti.pacienti-medicamente"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmPacient.Position -= 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmPacient.Position += 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmMedicamente.Position -= 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmMedicamente.Position += 1;
        }
    }
}
