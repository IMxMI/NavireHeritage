using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    class Cargo : Navire
    {
        private string typeFret;

        public Cargo(string imo, string nom, string latitude, string longitude, int tonnageDT, int tonnageDWT, int tonnageActuel, string typeFret) :base(imo, nom, latitude, longitude, tonnageDT, tonnageDWT, tonnageActuel)
        {
            this.typeFret = typeFret;
        }

        public string TypeFret { get => typeFret;}
    }
}
