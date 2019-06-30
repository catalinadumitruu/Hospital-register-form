using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_paw_spital
{
    public delegate void ProcesareReteta(string r);
    public class Retete : ICloneable, IComparable, IExpirare
    {
        private int nr_crt;
        private string pacient;
        private string medic;
        private string[] medicament;
        private int cantitate_med;
        private double pret;
        private DateTime data;
        private Boolean ok = true;

        public Retete()
        {
            this.nr_crt = 0;
            this.pacient = null;
            this.medic = null;
            this.medicament = null;
            this.cantitate_med = 0;
            this.pret = 0.0;
            this.data = new DateTime(2000, 1, 01);
        }

        public Retete(int nr_crt, Pacienti p, Medici m, string[] medicament, int cantitate, double pret, DateTime date)
        {
            this.nr_crt = nr_crt;
            this.pacient = p.Nume;
            this.medic = m.Nume;
            this.cantitate_med = cantitate;
            this.medicament = new string[cantitate];
            this.medicament = medicament;
            this.pret = pret;
            this.data = date;
        }

        public int Nr_crt
        {
            get { return this.nr_crt; }
            set { if (value > 0) this.nr_crt = value; }
        }

        public string Pacient
        {
            get { return this.pacient; }
            set {this. pacient = value; }
        }

        public string Medic
        {
            get { return this.medic; }
            set { this.medic = value; }
        }

        public string[] Medicament
        {
            get { return this.medicament; }
            set { this.medicament = value; }
        }

        public int Cantitate
        {
            get { return this.cantitate_med; }
            set { if (value > 0) this.cantitate_med = value; }
        }

        public double Pret
        {
            get { return this.pret; }
            set { if (value > 0) this.pret = value; }
        }

        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int CompareTo(object obj)
        {
            Retete reteta = (Retete)obj;

            if (this.cantitate_med > reteta.cantitate_med) return 1;
            else if (this.cantitate_med < reteta.cantitate_med) return -1;
            else return this.cantitate_med.CompareTo(reteta.cantitate_med);
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        public Retete Clone()
        {
            return (Retete)((ICloneable)this).Clone();
        }

        public override string ToString()
        {
            return this.nr_crt + ". A fost emisa de doctorul " + this.medic + " pentru " + this.pacient + " la data de " + this.data +
                ". Se recomanda " + this.medicament + " in cantitate de " + this.cantitate_med + " bucati, pretul/buc: " + this.pret;
        }

        public string this[int index]
        {
            get { return this.medicament[index]; }
            set { this.medicament[index] = value; }
        }

        public double valoare_reteta()
        {
            return this.cantitate_med * this.pret;
        }

        public void print_data_expirare()
        {
            DateTime newDateTime;

            if (this.data.Month + 4 > 12) newDateTime = new DateTime(this.data.Year + 1, this.data.Month + 4, this.data.Day);
            else newDateTime = new DateTime(this.data.Year, this.data.Month + 4, this.data.Day);

          // MessageBox.Show('Medicamentul va expira in data de: ', newDateTime);
        }

        public void proc_reteta(ProcesareReteta reteta)
        {
            foreach(string med in medicament)
            {
                if (ok)
                {
                    reteta(med);
                }
            }
        }
    }
}