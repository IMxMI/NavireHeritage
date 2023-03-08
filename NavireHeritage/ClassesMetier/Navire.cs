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
        protected double latitude;
        protected double longitude;
        protected int tonnageGT;
        protected int tonnageDWT;
        protected int tonnageActuel;

        protected Navire(string imo, string nom, double latitude, double longitude, int tonnageGT, int tonnageDWT, int tonnageActuel)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.tonnageGT = tonnageGT;
            this.tonnageDWT = tonnageDWT;
            this.tonnageActuel = tonnageActuel;
        }
        public string Imo => imo;

        public string Nom => nom;

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public int TonnageGT { get => tonnageGT;}
        public int TonnageDWT { get => tonnageDWT;}
        public int TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
    }
}
