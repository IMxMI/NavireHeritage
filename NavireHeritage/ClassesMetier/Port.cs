using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    class Port : Station.Interface.IStationable
	{
        private string nom;
        private string latitude;
        private string longitude;
        private int nbPortique; // Nombre de points d'accueil d'un cargo
        private int nbQuaisPassager; // Nombre de quais d'accueil pour navires passagers
        private int nbQuaisTanker; // Nombre de quais d'accueil pour les tankers de jusqu'à 130000 tonnes (GT)
        private int nbQuaisSuperTanker; // Nombre de quais d'accueil pour les tankers de plus de 130000 tonnes(GT)
        private Dictionary<string, Navire> navireAttendus = new Dictionary<string, Navire>(); // Dictionnaire des navires attendus. String = id du navire
        private Dictionary<string, Navire> navireArrives = new Dictionary<string, Navire>(); // Dictionnaire des navires arrivés, c’est-à-dire présents dans le port.String = id du navire
        private Dictionary<string, Navire> navirePartis = new Dictionary<string, Navire>(); // Dictionnaire des navires partis récemment. String = id du navire
        private Dictionary<string, Navire> navireEnAttente = new Dictionary<string, Navire>(); // Dictionnaire des navires en attente d'avoir un quai libre pour stationner.String = id du navire

		public Dictionary<string, Navire> NavireAttendus { get => navireAttendus; set => navireAttendus = value; }
		public Dictionary<string, Navire> NavireArrives { get => navireArrives; set => navireArrives = value; }
		public Dictionary<string, Navire> NavirePartis { get => navirePartis; set => navirePartis = value; }
		public Dictionary<string, Navire> NavireEnAttente { get => navireEnAttente; set => navireEnAttente = value; }

		public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisPassager, int nbQuaisTanker, int nbQuaisSuperTanker)
		{
			this.nom = nom;
			this.latitude = latitude;
			this.longitude = longitude;
			this.nbPortique = nbPortique;
			this.nbQuaisPassager = nbQuaisPassager;
			this.nbQuaisTanker = nbQuaisTanker;
			this.nbQuaisSuperTanker = nbQuaisSuperTanker;
		}

        public void EnregistrerArriveePrevue(Object objet)
		{
				if (objet is Navire navire)
				{
					if (!navireAttendus.ContainsKey(navire.Imo))
					{
						this.navireAttendus.Add(navire.Imo, navire);
					}
					else
					{
						throw new Exception($"Le navire {navire.Imo} est déjà attendu dans le port");
					}

				}
				else
				{
					throw new Exception("Le port ne peut accueillir que des navires");
				}
		}

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




		private void NavireCroisiereArrive(Croisiere croisiere)
		{
			navireArrives.Add(croisiere.Imo, croisiere);
			navireAttendus.Remove(croisiere.Imo);
		}

		private void NavireCroisiereArrive(string imo)
		{
			Croisiere croisiere = (Croisiere)GetUnAttendu(imo);
			navireArrives.Add(croisiere.Imo, croisiere);
			navireAttendus.Remove(croisiere.Imo);
		}

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

		private void NavireCargoAttenduArrive(string imo)
		{
			Cargo cargo = (Cargo)GetUnAttendu(imo);
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

		private void CargoInnattendu(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFret)
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

		private void TankerInnattendu(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFluide)
		{
			Tanker tanker = new Tanker(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel, typeFluide);
			if(tanker.TonnageGT <= 130000)
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

		private void NavireTankerAttenduArrive(string imo)
		{
			Tanker tanker = (Tanker)GetUnAttendu(imo);
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

		public void EnregistrerArrivee(string imo)
		{
			if (EstAttendu(imo))
			{
				if (GetUnAttendu(imo) is Croisiere)
				{
					NavireCroisiereArrive(imo);
				}
				else if (GetUnAttendu(imo) is Cargo)
				{
					if (GetNbCargoArrives() < nbPortique)
					{
						NavireCargoAttenduArrive(imo);
					}
				}

				else if (GetUnAttendu(imo) is Tanker)
				{
					NavireTankerAttenduArrive(imo);
				}
			}
			else
			{
				throw new Exception($"{imo} n'est pas attendu ou est déjà dans le port");
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
				int i = 0;
				while(i < navireArrives.Count && navireArrives.ElementAt(i).Key != imo)
				{
					i++;
				}
				navirePartis.Add(imo, navireArrives.ElementAt(i).Value);
				navireArrives.Remove(imo);
				Console.WriteLine($"Le navire {imo} a quitté le port");
			}
			else
			{
				throw new Exception($"Enregistrement départ impossible pour {imo} le navire n'est pas dans le port");
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
			foreach(Navire navire in navireArrives.Values)
			{
					if (navire is Tanker && navire.TonnageGT <= 130000)
					{
						count++;
					}
			}
			return count;
		}

		public int GetNbCroisiereArrives()
		{
			int count = 0;
			foreach(Navire navire in navireArrives.Values)
			{
				if(navire is Croisiere)
				{
					count++;
				}
				
			}
			return count;
		}

		public int GetNbSuperTankerArrives()
		{
			int count = 0;
			foreach(Navire navire in this.navireArrives.Values)
			{
				if (navire is Tanker && navire.TonnageGT > 130000)
				{
					count++;
				}
			}
			return count;
		}

		public int GetNbCargoArrives()
		{
			int count = 0;
			foreach (Navire navire in navireArrives.Values)
			{
				if(navire is Cargo)
				{
					count++;
				}
			}
			return count;
		}


		public override string ToString()
		{
			return $"------------------------------\nPort de {nom}\n\tCoordonnées GPS : {latitude} / {longitude}\n\tNb portiques : {nbPortique}\n\tNb quas croisière : {nbQuaisPassager}\n\tNb quais tanker : {nbQuaisTanker}\n\tNb quais super tankers : {nbQuaisSuperTanker}\n\tNb Navires à quai : {navireArrives.Count}\n\tNb navires attendus : {navireAttendus.Count}\n\tNb navires partis : {navirePartis.Count}\n\tNb navires en attente : {navireEnAttente.Count}\n\nNombre de cargos dans le port : {GetNbCargoArrives()}\nNombre de tankers dans le port : {GetNbTankerArrives()}\nNombre de super tankers dans le port : {GetNbSuperTankerArrives()}\n--------------------------------";
		}
	}
}
