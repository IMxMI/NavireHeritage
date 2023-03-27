using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    class Croisiere : Navire, Station.Interface.INavCroisierable
	{
        private char typeNavireCroisiere;
        private int nbPassagersMaxi;
        private Dictionary<String, Passager> passagers;

		public char TypeNavireCroisiere { get => typeNavireCroisiere;}
		public int NbPassagersMaxi { get => nbPassagersMaxi;}
		internal Dictionary<string, Passager> Passagers { get => passagers;}

		public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi) : base( imo,  nom,  latitude,  longitude,  tonnageGT,  tonnageDWT,  tonnageActuel)
		{
			this.typeNavireCroisiere = typeNavireCroisiere;
			this.nbPassagersMaxi = nbPassagersMaxi;
		}

		public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi, List<Passager> passagers) : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
		{
			passagers = new List<Passager>();
		}
		public void Embarquer(List<Object> passagers)
		{
			if (passagers.Count < nbPassagersMaxi)
			{
				foreach(Passager passager1 in passagers)
				{
					passagers.Add(passager1);
				}
			}
			else
			{
				throw new Exception("Erreur le navire est déjà plein");
			}
		}
		public List<Object> Debarquer(List<Object> passagers)
		{
			int count = 0;
			if(passagers.Count > 0)
			{
				foreach(Passager passager1 in this.passagers.Values)
				{
					passagers.RemoveAt(count);
					count++;
				}
			}
			else
			{
				throw new Exception("Erreur le bateau est déjà vide");
			}
			return passagers;
		}
	}
}
