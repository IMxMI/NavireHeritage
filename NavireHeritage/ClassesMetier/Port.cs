using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Station.Interface;


namespace NavireHeritage.ClassesMetier
{
     public class Port : IStationable
    {
        private readonly string nom;
        private readonly string latitude;
        private readonly string longitude;
        private int nbPortique;
        private int nbQuaisPassager;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private readonly Dictionary<String, Navire> navireAttendus = new Dictionary<string, Navire>();
		private readonly Dictionary<String, Navire> navireArrives = new Dictionary<string, Navire>();
		private readonly Dictionary<String, Navire> navirePartis = new Dictionary<string, Navire>();
		private readonly Dictionary<String, Navire> navireEnAttente = new Dictionary<string, Navire>();

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisPassager, int nbQuaisTanker, int nbQuaisSuperTanker)
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.NbPortique = nbPortique;
            this.NbQuaisPassager = nbQuaisPassager;
            this.NbQuaisTanker = nbQuaisTanker;
            this.NbQuaisSuperTanker = nbQuaisSuperTanker;
        }

        public string Nom => nom;

        public string Latitude => latitude;

        public string Longitude => longitude;

        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }

        internal Dictionary<string, Navire> NavireAttendus => navireAttendus;

        internal Dictionary<string, Navire> NavireArrives => navireArrives;

        internal Dictionary<string, Navire> NavirePartis => navirePartis;

        internal Dictionary<string, Navire> NavireEnAttente => navireEnAttente;

        public void EnregistrerArriveePrevue(Object objet)
        {
            if(objet is Navire navire)
            {
                if (!this.navireAttendus.ContainsKey(navire.Imo))
                {
                    this.navireAttendus.Add(navire.Imo, navire);

                }
                else
                {
                    throw new Exception("Le navire " + navire.Imo + " est déja enregistré dans le port.");
                }
            }
            else
            {
                throw new Exception("L'objet n'est pas un navire.");
            }
        }           

       public void EnregistrerDepart(Object objet)
		{
			if (objet is Navire navire)
			{
				if (navireArrives.ContainsKey(navire.Imo))
				{
					navirePartis.Add(navire.Imo, navire);
					navireArrives.Remove(navire.Imo);
				}
				else
				{
					throw new Exception($"Le navire {navire.Imo} n'est pas dans le port");
				}
			}
			
		}

		public void EnregistrerDepart(string imo)
		{
			if (navireArrives.ContainsKey(imo))
			{
				foreach(Navire navire in navireArrives.Values)
				{
					navirePartis.Add(navire.Imo, navire);
					navireArrives.Remove(imo);
				}
			}
			else
			{
				throw new Exception($"Le navire {imo} n'est pas présent dans le port");
			}
		}

 /// <summary>
		/// Ajout du navire passé en paramètre dans le
		/// dictionnaire des navires en attente d'un quai dans le port
		/// </summary>
		/// <param name="navire"></param>

		public void AjouterNavireEnAttente(Navire navire)
		{
			navireEnAttente.Add(navire.Imo, navire);
		}

		/// <summary>
		/// Retourne vrai si le navire est attendu
		/// </summary>
		/// <param name="imo"></param>
		/// <returns></returns>

		public bool EstAttendu(string imo)
		{
			return navireAttendus.ContainsKey(imo);
		}

		/// <summary>
		/// Retourne vrai si le navire est dans le port
		/// </summary>
		/// <param name="imo"></param>
		/// <returns></returns>

		public bool EstPresent(string imo)
		{
			return navireArrives.ContainsKey(imo);
		}

		public bool EstParti(string imo)
		{
			return navirePartis.ContainsKey(imo);
		}

		/// <summary>
		/// Chargement du navire dont l'id est passé en
		/// paramètre de la quantité passée en paramètre
		/// </summary>
		/// <param name="imo"></param>
		/// <param name="qte"></param>
		public void Chargement(string imo, int qte)
		{
			if (navireArrives.ContainsKey(imo))
			{
				foreach (Navire navire in navireArrives.Values)
				{
					if (navire.Imo == imo)
					{
						if (navire.TonnageActuel != navire.TonnageDWT)
						{
							navire.TonnageActuel += qte;
						}
						else
						{
							throw new Exception($"Le navire {imo} est plein");
						}

					}
				}
			}
			else
			{
				throw new Exception($"Le navire {imo} n'est pas dans le port");
			}
		}

		public Object GetUnParti(string id)
		{
			if (navirePartis.ContainsKey(id))
			{
				return navirePartis[id];
			}
			else
			{
				throw new Exception($"Le navire {id} n'est pas parti");
			}
		}

		public Object GetUnAttendu(string id)
		{
			if (navireAttendus.ContainsKey(id))
			{
				return navireAttendus[id];
			}
			else
			{
				throw new Exception($"Le navire {id} n'est pas attendu dans le port");
			}
		}

		public Object GetUnArrive(string id)
		{
			if (navireArrives.ContainsKey(id))
			{
				return navireArrives[id];
			}
			else
			{
				throw new Exception($"Le navire {id} n'est pas arrivé dans le port");
			}
		}

		public int GetNbTankerArrives()
		{
			int count = 0;
			foreach(Tanker navire in navireArrives.Values)
			{
					if (navire.TonnageGT <= 130000)
					{
						count++;
					}
			}
			return count;
		}

		public int GetNbSuperTankerArrives()
		{
			int count = 0;
			foreach(Tanker navire in navireArrives.Values)
			{
				if (navire.TonnageGT > 130000)
				{
					count++;
				}
			}
			return count;
		}

		public int GetNbCargoArrives()
		{
			int count = 0;
			foreach (Cargo navire in navireArrives.Values)
			{
				count++;
			}
			return count;
		}

		/// <summary>
		/// Enregistre les navires arrivee dans le port.
		/// </summary>
		/// <param name="objet">Navire.</param>
		public void EnregistrerArrivee(Object objet)
		{
			if (objet is Navire navire)
			{
				if (navire is Croisiere croisiere)
				{
					NavireCroisiereArrive(croisiere);
				}
				else if (navire is Cargo cargo)
				{
					if (navireAttendus.ContainsKey(navire.Imo))
					{
						NavireCargoAttenduArrive(cargo);
					}
					else
					{
						CargoInnattendu(cargo.Imo, cargo.Nom, cargo.Latitude, cargo.Longitude, cargo.TonnageGT, cargo.TonnageDWT, cargo.TonnageActuel, cargo.TypeFret);
					}
				}
				else if (navire is Tanker tanker)
				{
					if (navireAttendus.ContainsKey(navire.Imo))
					{
						NavireTankerAttenduArrive(tanker);
					}
					else
					{
						TankerInnattendu(tanker.Imo, tanker.Nom, tanker.Latitude, tanker.Longitude, tanker.TonnageGT, tanker.TonnageDWT, tanker.TonnageActuel, tanker.TypeFluide);
					}
				}
			}
			else
			{
				throw new Exception("Ce n'est pas un navire");
			}
		}

		/// <summary>
		/// Un navire de type croisiere est arriver.
		/// </summary>
		/// <param name="croisiere"></param>
		private void NavireCroisiereArrive(Croisiere croisiere)
		{
			navireArrives.Add(croisiere.Imo, croisiere);
			navireAttendus.Remove(croisiere.Imo);
		}

		/// <summary>
		/// Un navire de type cargo, attendu est arrive.
		/// </summary>
		/// <param name="cargo">Navire Cargo.</param>
		private void NavireCargoAttenduArrive(Cargo cargo)
		{
			if (GetNbCargoArrives() < nbPortique)
			{
				navireArrives.Add(cargo.Imo, cargo);
				navireAttendus.Remove(cargo.Imo);
			}
			else
			{
				navireEnAttente.Add(cargo.Imo, cargo);
				navireAttendus.Remove(cargo.Imo);
			}
		}

		/// <summary>
		/// Le navirede type Cargo est innatendu.
		/// </summary>
		/// <param name="imo">Imo.</param>
		/// <param name="nom">Nom.</param>
		/// <param name="latitude">Latitude.</param>
		/// <param name="longitude">Longitude.</param>
		/// <param name="tonnageGT">TonnageGT.</param>
		/// <param name="tonnageDWT">TonnageDWT.</param>
		/// <param name="tonnageActuel">TonnageActuel.</param>
		/// <param name="typeFret">TypeFret.</param>
		private void CargoInnattendu(string imo, string nom, double latitude, double longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFret)
		{
			Cargo cargo = new Cargo(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel, typeFret);
			if (GetNbCargoArrives() < nbPortique)
			{
				navireArrives.Add(cargo.Imo, cargo);
				navireAttendus.Remove(cargo.Imo);
			}
			else
			{
				navireEnAttente.Add(cargo.Imo, cargo);
				navireAttendus.Remove(cargo.Imo);
			}
		}

		/// <summary>
		/// Le navire de type Tanker n'est pas attendu.
		/// </summary>
		/// <param name="imo"></param>
		/// <param name="nom"></param>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		/// <param name="tonnageGT"></param>
		/// <param name="tonnageDWT"></param>
		/// <param name="tonnageActuel"></param>
		/// <param name="typeFluide"></param>
		private void TankerInnattendu(string imo, string nom, double latitude, double longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFluide)
		{
			Tanker tanker = new Tanker(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel, typeFluide);
			if (tanker.TonnageGT <= 130000)
			{
				if (GetNbTankerArrives() < nbQuaisTanker)
				{
					navireArrives.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
				else
				{
					navireEnAttente.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
			}
			else
			{
				if (GetNbSuperTankerArrives() < nbQuaisSuperTanker)
				{
					navireArrives.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
				else
				{
					navireEnAttente.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
			}
		}

		/// <summary>
		/// Un navire de type Tanker attendu, est arrivé.
		/// </summary>
		/// <param name="tanker"></param>
		private void NavireTankerAttenduArrive(Tanker tanker)
		{
			if (tanker.TonnageGT <= 130000)
			{
				if (GetNbTankerArrives() < nbQuaisTanker)
				{
					navireArrives.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
				else
				{
					navireEnAttente.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
			}
			else
			{
				if (GetNbSuperTankerArrives() < nbQuaisSuperTanker)
				{
					navireArrives.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
				else
				{
					navireEnAttente.Add(tanker.Imo, tanker);
					navireAttendus.Remove(tanker.Imo);
				}
			}
		}

		/// <summary>
		/// Enregistre l'arrivé des Navires dans navireArrives.
		/// </summary>
		/// <param name="imo"></param>
		public void EnregistrerArrivee(string imo)
		{
			foreach (Navire navire in navireArrives.Values)
			{
				if (navire is Croisiere croisiere)
				{
					NavireCroisiereArrive(croisiere);
				}
				else if (navire is Cargo cargo)
				{
					if (navireAttendus.ContainsKey(navire.Imo))
					{
						NavireCargoAttenduArrive(cargo);
					}
					else
					{
						CargoInnattendu(cargo.Imo, cargo.Nom, cargo.Latitude, cargo.Longitude, cargo.TonnageGT, cargo.TonnageDWT, cargo.TonnageActuel, cargo.TypeFret);
					}
				}
				else if (navire is Tanker tanker)
				{
					if (navireAttendus.ContainsKey(navire.Imo))
					{
						NavireTankerAttenduArrive(tanker);
					}
					else
					{
						TankerInnattendu(tanker.Imo, tanker.Nom, tanker.Latitude, tanker.Longitude, tanker.TonnageGT, tanker.TonnageDWT, tanker.TonnageActuel, tanker.TypeFluide);
					}
				}

				throw new Exception($"{imo} n'est pas un navire");
			}
		}


		public override string ToString()
		{
			return $"Port de {nom}\n\tCoordonnées GPS : {latitude} / {longitude}\n\tNb portiques : {nbPortique}\n\tNb quas croisière : {nbQuaisPassager}\n\tNb quais tanker : {nbQuaisTanker}\n\tNb quais super tankers : {nbQuaisSuperTanker}\n\tNb Navires à quai : {navireArrives.Count}\n\tNb navires attendus : {navireAttendus.Count}\n\tNb navires partis : {navirePartis.Count}\n\tNb navires en attente : {navireEnAttente.Count}\n\nNombre de cargos dans le port : {GetNbCargoArrives()}\nNombre de tankers dans le port : {GetNbTankerArrives()}\nNombre de super tankers dans le port : {GetNbSuperTankerArrives()}";
		}
    }
}