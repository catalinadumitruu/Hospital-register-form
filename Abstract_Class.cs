using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_paw_spital
{
    public abstract class Abstract_Class
    {
        private string nume_ab;
        private string locatie;
        private DateTime data_angajare;

        public Abstract_Class()
        {

        }

        public abstract string Nume_abstract
        {
            get;
            set;
        }

        public abstract string Locatie
        {
            get;
            set;
        }

        public abstract DateTime Data_angajaree
        {
            get;
            set;
        }
        public string Nume { get; internal set; }

        public string Update()
        {
            return "Angaajtului " + this.nume_ab + " care lucreaza in spitalul : " + this.locatie + " din data de " + this.data_angajare + " i s-a facut update.";
        }

        public abstract double calculeaza_salariul_cu_bonus(); //stiind ca se acord un bonus de 10%
    }
}
