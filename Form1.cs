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
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        private void pacientiBTN_Click(object sender, EventArgs e)
        {
            Form_Pacienti form_Pacienti = new Form_Pacienti();
            form_Pacienti.Show();
            
        }

        private void mediciBTN_Click(object sender, EventArgs e)
        {
            Form_Medici form_Medici = new Form_Medici();
            form_Medici.ShowDialog();
        }

        private void reteteBTN_Click(object sender, EventArgs e)
        {
            Form_Retete form_retete = new Form_Retete();
            form_retete.ShowDialog();
        }

        private void departamenteBTN_Click(object sender, EventArgs e)
        {
            Form_Departamente form_dep = new Form_Departamente();
            form_dep.ShowDialog();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
