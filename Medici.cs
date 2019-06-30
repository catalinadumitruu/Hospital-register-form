using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_paw_spital
{
    [Serializable]
    public class Medici : Abstract_Class, ICloneable, IComparable
    {
        private int id_medic;
        private string nume;
        private int varsta;
        private double ore_lucrate_pe_saptamana;
        private double salariul;
        private int numar_pacienti;
        private List<Pacienti> pacienti;
        private string departament;

        public Medici()
        {
            this.id_medic = 0;
            this.nume = "nesetat";
            this.varsta = 0;
            this.ore_lucrate_pe_saptamana = 0;
            this.salariul = 0;
            this.numar_pacienti = 0;
            this.pacienti = null;
            this.departament = null;
        }

        public Medici(int id_medic, string nume, int varsta, double ore_lucrate, double salariul, int nr_p, List<Pacienti> pacienti, Departamente dep)
        {
            this.id_medic = id_medic;
            this.nume = nume;
            this.varsta = varsta;
            this.ore_lucrate_pe_saptamana = ore_lucrate;
            this.salariul = salariul;
            this.numar_pacienti = nr_p;
            // this.pacienti = new List<Pacienti>[nr_p];
            this.pacienti = pacienti;
            this.departament = dep.Denumire;
        }

        public Medici(int id_medic, string nume, int varsta, double ore_lucrate, double salariul, int nr_p, List<Pacienti> pacienti)
        {
            this.id_medic = id_medic;
            this.nume = nume;
            this.varsta = varsta;
            this.ore_lucrate_pe_saptamana = ore_lucrate;
            this.salariul = salariul;
            this.numar_pacienti = nr_p;
            this.pacienti = pacienti;
        }

        public int Id_medic
        {
            get { return this.id_medic; }
            set { if (value > 0) this.id_medic = value; }
        }

        public string Nume
        {
            get { return this.nume; }
            set { if (!string.IsNullOrEmpty(value)) this.nume = value; }
        }

        public int Varsta
        {
            get { return this.varsta; }
            set { if (value > 0) this.varsta = value; }
        }

        public double Ore_lucrate
        {
            get { return this.ore_lucrate_pe_saptamana; }
            set { if (value > 0) this.ore_lucrate_pe_saptamana = value; }
        }

        public double Salariul
        {
            get { return this.salariul; }
            set { if (value > 0) this.salariul = value; }
        }

        public int Numar_pacienti
        {
            get { return this.numar_pacienti; }
            set { this.numar_pacienti = value; }
        }

        public List<Pacienti> Pacienti_l
        {
            get { return this.pacienti; }
            set { this.pacienti = value; }
        }

        public string Departament
        {
            get { return this.departament; }
            set { this.departament = value; }
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        public object Clone()
        {
            return (Medici)((ICloneable)this).Clone();
        }

        public int CompareTo(object obj)
        {
            Medici medic = (Medici)obj;

            if (this.ore_lucrate_pe_saptamana > medic.ore_lucrate_pe_saptamana) return -1;
            else if (this.ore_lucrate_pe_saptamana < medic.ore_lucrate_pe_saptamana) return 1;
            else return this.ore_lucrate_pe_saptamana.CompareTo(medic.ore_lucrate_pe_saptamana);
        }

        public override string ToString()
        {
            string result = this.id_medic + "->> Medicul " + this.nume + " cu varsta de " + this.varsta + "ani, lucreaza saptamanal " + this.Ore_lucrate + " si are un salariu de "
                    + this.salariul + " lei. El apartine de departamentul " + this.departament.ToString() + " are " + this.numar_pacienti + " pacienti: "
                    + "\n<> ";

           // foreach (Pacienti p in this.pacienti)
            //{
              //  result += p.ToString() + "\n";
            //}
            return result;
        }

        public static Medici operator +(Medici m, Pacienti p)
        {
            m.pacienti.Add(p);
            m.numar_pacienti++;
            List<Pacienti> list = m.pacienti;
            Medici med = new Medici(m.id_medic, m.nume, m.varsta, m.ore_lucrate_pe_saptamana, m.salariul, m.numar_pacienti, list);

            return med;
        }

        public static bool operator ==(Medici m1, Medici m2)
        {
            return m1.salariul > m2.salariul;
        }

        public static bool operator !=(Medici m1, Medici m2)
        {
            return m1.salariul > m2.salariul;
        }

        public double aproximare_ore_pe_zi()
        {
            return this.ore_lucrate_pe_saptamana / 7;
        }

        public void soratre_alfabetica_pacienti()
        {
            this.pacienti.Sort();
        }

        public override double calculeaza_salariul_cu_bonus()
        {
            return this.salariul + this.salariul * 0.1;
        }

        public override string Nume_abstract
        {
            get { return base.Nume; }
            set { Nume_abstract = value; }
        }

        public override string Locatie { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override DateTime Data_angajaree { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}