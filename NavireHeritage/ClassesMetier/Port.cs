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
        private Dictionary<string, Navire> navireAttendus; // Dictionnaire des navires attendus. String = id du navire
        private Dictionary<string, Navire> navireArrives; // Dictionnaire des navires arrivés, c’est-à-dire présents dans le port.String = id du navire
        private Dictionary<string, Navire> navirePartis; // Dictionnaire des navires partis récemment. String = id du navire
        private Dictionary<string, Navire> navireEnAttente; // Dictionnaire des navires en attente d'avoir un quai libre pour stationner.String = id du navire

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
			if (objet is Navire navire )
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
				navireArrives.Add(navire.Imo, navire);
				navireAttendus.Remove(navire.Imo);
			}
            
		}
        public void EnregistrerArrivee(string imo)
		{
			if (navireAttendus.ContainsKey(imo))
			{
				foreach (Navire navire in navireAttendus.Values)
				{
					navireArrives.Add(imo, navire);
					navireAttendus.Remove(imo);
				}
			}
			else
			{
				throw new Exception($"Le navire {imo} n'est pas attendu");
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


		public override string ToString()
		{
			return $"Port de {nom}\n\tCoordonnées GPS : {latitude} / {longitude}\n\tNb portiques : {nbPortique}\n\tNb quas croisière : {nbQuaisPassager}\n\tNb quais tanker : {nbQuaisTanker}\t\nNb quais super tankers : {nbQuaisSuperTanker}\n\tNb Navires à quai : {navireArrives.Count}\n\tNb navires attendus : {navireAttendus.Count}\n\tNb navires partis : {navirePartis.Count}\n\tNb navires en attente : {navireEnAttente.Count}\n\nNombre de cargos dans le port : {GetNbCargoArrives()}\nNombre de tankers dans le port : {GetNbTankerArrives()}\tNombre de super tankers dans le port : {GetNbSuperTankerArrives()}";
		}
	}
}
