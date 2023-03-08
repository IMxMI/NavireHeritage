using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    abstract class Navire
    {
        protected readonly string imo;
        protected readonly string nom;
        protected string latitude;
        protected string longitude;
        protected int tonnageGT;
        protected int tonnageDWT;
        protected int tonnageActuel;

        protected Navire(string imo, string nom, string latitude, string longitude, int tonnageDT, int tonnageDWT, int tonnageActuel)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.tonnageGT = tonnageDT;
            this.tonnageDWT = tonnageDWT;
            this.tonnageActuel = tonnageActuel;
        }
        public string Imo => imo;

        public string Nom => nom;

        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int TonnageGT { get => tonnageGT; set => tonnageGT = value; }
        public int TonnageDWT { get => tonnageDWT; set => tonnageDWT = value; }
        public int TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
    }
}
