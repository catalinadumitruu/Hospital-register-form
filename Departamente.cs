using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_paw_spital
{
    public class Departamente
    {
        private int id_departament;
        private string denumire;
        private int id_supervizor;

        public Departamente()
        {
            this.id_departament = 0;
            this.denumire = "Denumire nespecificata";
            this.id_supervizor = 0;
        }

        public Departamente(int id, string denumire, int id_supervizor)
        {
            this.id_departament = id;
            this.denumire = denumire;
            this.id_supervizor = id_supervizor;
        }

        public int Id_departament
        {
            get { return this.id_departament; }
            set { if (value > 0) this.id_departament = value; }
        }

        public string Denumire
        {
            get { return this.denumire; }
            set { this.denumire = value; }
        }

        public int Id_supervizor
        {
            get { return this.id_supervizor; }
            set { this.id_supervizor = value; }
        }

        public override string ToString()
        {
            return this.denumire;
        }
    }
}

