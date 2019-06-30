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
    public partial class Form_adauga_pacient : Form
    {
        public Pacienti pacient = new Pacienti();

        public Form_adauga_pacient()
        {
            InitializeComponent();
        }

        public Form_adauga_pacient(Pacienti p)
        {
            pacient = p;
            InitializeComponent();
            numeTXT.Text = pacient.Nume;
            varstaTXT.Text = pacient.Varsta.ToString();
            boalaTXT.Text = pacient.Denumire_boala;
            grupaSangeTXT.Text = pacient.Grupa_sange;
            alergiiTXT.Text = pacient.Alergii;
            cnpTXT.Text = pacient.Cnp;
            medicTXT.Text = pacient.Medic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pacient.Nume = numeTXT.Text; ;
            int varsta = 0;
            pacient.Denumire_boala = boalaTXT.Text;
            pacient.Grupa_sange = grupaSangeTXT.Text;
            pacient.Alergii = alergiiTXT.Text;
            pacient.Cnp = cnpTXT.Text;
            pacient.Medic = medicTXT.Text;

            try
            {
                varsta = Convert.ToInt32(varstaTXT.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            pacient.Varsta = varsta;
        }

        private void varstaTXT_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int varsta = Convert.ToInt32(varstaTXT.Text);
                if (varsta > 20)
                    MessageBox.Show("Acesta este un spital de pediatrie, nu sunt acceptati adulti.", "Eroare", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare introducere varsta!", "Eroare", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void numeTXT_Validating(object sender, CancelEventArgs e)
        {
            if (numeTXT.Text == "") MessageBox.Show("Introduceti numele!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void boalaTXT_Validating(object sender, CancelEventArgs e)
        {
            if (boalaTXT.Text == "") errorProvider1.SetError(boalaTXT, "Introduceti diagnosticul!");
            else errorProvider1.SetError(boalaTXT, "");
        }

        private void grupaSangeTXT_Validating(object sender, CancelEventArgs e)
        {
            if (grupaSangeTXT.Text == "") errorProvider1.SetError(grupaSangeTXT, "Introduceti grupa de sange!");
            else errorProvider1.SetError(grupaSangeTXT, "");
        }

        private void medicTXT_Validating(object sender, CancelEventArgs e)
        {
            if (medicTXT.Text == "") errorProvider1.SetError(medicTXT, "Pacientul trebuie sa fie asignat unui medic!");
            else errorProvider1.SetError(medicTXT, "");
        }
    }
}
