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

        public Cargo(string imo, string nom, double latitude, double longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFret) :base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeFret = typeFret;
        }

        public string TypeFret { get => typeFret;}

        /// <summary>
        /// Methode qui permet de chager le navire.
        /// </summary>
        /// <param name="qte">Quantité à charger.</param>
        public void Charger(int qte)
        {
            if (qte <= tonnageDWT - this.tonnageActuel)
            {
                this.tonnageActuel += qte;
            }
            else
            {
                throw new Exception("Erreur : La capacité du navire n'est pas assez grande.");
            }
        }

        /// <summary>
        /// Methode qui permet de déchager le navire.
        /// </summary>
        /// <param name="qte">Quantité à décharger.</param>
        public void Decharger(int qte)
        {
            if (qte > this.tonnageActuel)
            {
                throw new Exception("Erreur : La quantité de déchagergement est trop grande.");
            }
            else
            {
                this.tonnageActuel -= qte;
            }
        }
    }
}
