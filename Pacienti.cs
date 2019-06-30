using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_paw_spital
{

    public delegate void ProcessPacientDelegate(Pacienti pacient);

    [Serializable]
    public class Pacienti : IComparable, ICloneable
    {
        private int id_pacient;
        private string nume;
        private int varsta;
        private string denumire_boala;
        private string grupa_sange;
        private string alergii;
        private string CNP;
        private string medic;

        public Pacienti()
        {
            this.id_pacient = 0;
            this.nume = "nesetat";
            this.varsta = 0;
            this.denumire_boala = "neexaminat";
            this.grupa_sange = "probe neprelevate";
            this.alergii = "neidentificate";
            this.CNP = "000000000000";
            this.medic = "";
        }

        public Pacienti(int id_pacient, string nume, int varsta, string denumireBoala, string grupaSange, string alergii, string cnp, string medic)
        {
            this.id_pacient = id_pacient;
            this.nume = nume;
            this.varsta = varsta;
            this.denumire_boala = denumireBoala;
            this.grupa_sange = grupaSange;
            this.alergii = alergii;
            this.CNP = cnp;
            this.medic = medic;
        }

        public int Id_pacient
        {
            get { return this.id_pacient; }
            set { if (value > 0) this.id_pacient = value; }
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

        public string Denumire_boala
        {
            get { return this.denumire_boala; }
            set { if (!string.IsNullOrEmpty(value)) this.denumire_boala = value; }
        }

        public string Grupa_sange
        {
            get { return this.grupa_sange; }
            set { if (!string.IsNullOrEmpty(value)) this.grupa_sange = value; }
        }

        public string Alergii
        {
            get { return this.alergii; }
            set { if (!string.IsNullOrEmpty(value)) this.alergii = value; }
        }

        public string Cnp
        {
            get { return this.CNP; }
            set { this.CNP = value; }
        }

        public string Medic
        {
            get { return this.medic; }
            set { if (!string.IsNullOrEmpty(value)) this.medic = value; }
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        public object Clone()
        {
            return (Pacienti)((ICloneable)this).Clone();
        }

        public int CompareTo(object obj)
        {
            Pacienti pacient = (Pacienti)obj;

            if (this.varsta > pacient.varsta) return -1;
            else if (this.varsta < pacient.varsta) return 1;
            else return this.varsta.CompareTo(pacient.varsta);
        }

        public override string ToString()
        {
            return this.id_pacient + " <> Pacientul " + this.nume + " are " + this.varsta + " ani,CNP-ul: " + this.CNP + " grupa de sange " + this.grupa_sange + ", alergii : " + this.alergii
                + " si sufera de " + this.denumire_boala;
        }

        //public override string ToString()
        //{
        //    return this.nume + ", cu diagnosticul: " + this.denumire_boala;
        //}

        public static Pacienti operator ~(Pacienti p)
        {
            string teste_necesare = "teste necesare";
            Pacienti nou = new Pacienti(p.id_pacient, p.nume, p.varsta, p.denumire_boala, p.grupa_sange, teste_necesare, p.CNP, p.medic);

            return nou;
        }

        public void pacienti_procesare(ProcessPacientDelegate pacienti)
        {
          
        }
    }
}

