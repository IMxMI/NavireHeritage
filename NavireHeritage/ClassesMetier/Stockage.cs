namespace NavireHeritage.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Stockage : Navire
    {
        private readonly int numero;
        private int capaciteMaxi;
        private int capaciteDispo;



        public Stockage(string imo, string nom, double latitude, double longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, int numero, int capaciteMaxi, int capaciteDispo) : base ( imo,  nom,  latitude,  longitude,  tonnageGT,  tonnageDWT,  tonnageActuel)
        {
            this.numero = numero;
            this.CapaciteMaxi = capaciteMaxi;
            this.CapaciteDispo = capaciteDispo;
        }
        
        public int Numero { get => numero;}

        public int CapaciteMaxi { get => capaciteMaxi; set => capaciteMaxi = value; }

        public int CapaciteDispo { get => capaciteDispo; set => capaciteDispo = value; }

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
        public Stockage(string imo, string nom, double latitude, double longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, int numero, int capaciteMaxi)
            : this(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel, numero, capaciteMaxi, capaciteMaxi) { }
    }
}
