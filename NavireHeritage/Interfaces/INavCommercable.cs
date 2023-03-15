using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interface
{
    interface INavCommercable
    {
        /// <summary>
        /// Methode qui met à jour le tonnage actuel du nvaire avec la valeur passée en parametre.
        /// La quantité passée en paramètre est enlevée à la quantité actuelle.
        /// </summary>
        /// <param name="qte"></param>
        void Decharger(int qte);
        void Charger(int qte);
    }
}
