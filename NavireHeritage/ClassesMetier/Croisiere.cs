//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NavireHeritage.ClassesMetier
//{
//    class Croisiere : Navire, Station.Interface.INavCroisierable
//    {
//        private readonly char typeNavireCroisiere;
//        private readonly int nbPassagersMaxi;
//        private readonly Dictionary<string, Passager> passagers;

//        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi)
//            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
//        {
//            this.typeNavireCroisiere = typeNavireCroisiere;
//            this.nbPassagersMaxi = nbPassagersMaxi;
//        }

//        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi, Dictionary<string, Passager> passagers)
//            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
//        {
//            this.typeNavireCroisiere = typeNavireCroisiere;
//            this.nbPassagersMaxi = nbPassagersMaxi;
//            this.passagers = passagers;
//        }

//        public char TypeNavireCroisiere => typeNavireCroisiere;

//        public int NbPassagersMaxi => nbPassagersMaxi;

//        internal Dictionary<string, Passager> Passagers => passagers;

//        public void Embarquer(Dictionary<string, Passager> passagers)
//        {
//            try
//            {

//            }
//            catch
//            {

//            }
//        }
//        public List<Object> Debarquer(List<Object> passagers)
//        {
//            int count = 0;
//            if (passagers.Count > 0)
//            {
//                foreach (Passager passager1 in this.passagers.Values)
//                {
//                    passagers.RemoveAt(count);
//                    count++;
//                }
//            }
//            else
//            {
//                throw new Exception("Erreur le bateau est déjà vide");
//            }
//            return passagers;
//        }
//}
