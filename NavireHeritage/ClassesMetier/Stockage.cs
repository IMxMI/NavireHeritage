namespace NavireHeritage.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Stockage : Navire
    {
        private int numero;
        private int capaciteMaxi;
        private int capaciteDispo;

        public int Numero { get => numero; set => numero = value; }

        public int CapaciteMaxi { get => capaciteMaxi; set => capaciteMaxi = value; }

        public int CapaciteDispo { get => capaciteDispo; set => capaciteDispo = value; }

        public Stockage(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, int numero, int capaciteMaxi, int capaciteDispo) : base ( imo,  nom,  latitude,  longitude,  tonnageGT,  tonnageDWT,  tonnageActuel)
        {
            this.Numero = numero;
            this.CapaciteMaxi = capaciteMaxi;
            this.CapaciteDispo = capaciteDispo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stockage"/> class.
        /// Truc.
        /// </summary>
        /// <param name="imo">Imo.</param>
        /// <param name="nom">Nom.</param>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        /// <param name="tonnageGT">TonnageGT.</param>
        /// <param name="tonnageDWT">TonnageDWT.</param>
        /// <param name="tonnageActuel">TonnageActuel.</param>
        /// <param name="numero">Numero.</param>
        /// <param name="capaciteMaxi">CapaciteMaxi.</param>
        public Stockage(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, int numero, int capaciteMaxi)
            : this(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel, numero, capaciteMaxi, capaciteMaxi) { }
    }
}
