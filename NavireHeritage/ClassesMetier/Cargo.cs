using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    class Cargo : Navire, Station.Interface.INavCommercable
    {
        private string typeFret;

        public Cargo(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFret) :base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeFret = typeFret;
        }

        public string TypeFret { get => typeFret;}

        public void Charger(int qte)
        {
            
        }
    }
}
