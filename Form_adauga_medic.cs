using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_paw_spital
{
    public partial class Form_adauga_medic : Form
    {
        public Medici medic = new Medici();
        public int nr_pacienti = 0;
        public Form_adauga_medic()
        {
            InitializeComponent();
        }

        public Form_adauga_medic(Medici m)
        {
            medic = m;
            InitializeComponent();
            numeTXT.Text = medic.Nume;
            varstTXT.Text = medic.Varsta.ToString();
            oreTXT.Text = medic.Ore_lucrate.ToString();
            salariulTXT.Text = medic.Salariul.ToString();
            departamentTXT.Text = medic.Departament;          
        }

        public Form_adauga_medic(string value)
        {
            medic.Nume = value;
            InitializeComponent();
            numeTXT.Text = medic.Nume;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            medic.Nume = numeTXT.Text;
            medic.Departament = departamentTXT.Text;
            int varsta = 0;
            double ore = 0;
            double sal = 0;

            try
            {
                varsta = Convert.ToInt32(varstTXT.Text);
                ore = Convert.ToDouble(oreTXT.Text);
                sal = Convert.ToDouble(salariulTXT.Text);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            medic.Varsta = varsta;
            medic.Ore_lucrate = ore;
            medic.Salariul = sal;
        }

        private void numeTXT_Validating(object sender, CancelEventArgs e)
        {
            if (numeTXT.Text == "") errorProvider1.SetError(numeTXT, "Medicul are nevoie de un nume!");
            else errorProvider1.SetError(numeTXT, "");
        }

        private void salariulTXT_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDouble(salariulTXT.Text) == 0) errorProvider1.SetError(salariulTXT, "Medicul trebuie sa aiba un salariu adaugat!");
            else errorProvider1.SetError(salariulTXT, "");
        }
    }
}
