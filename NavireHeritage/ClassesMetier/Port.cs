using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    class Port
    {
        private readonly string nom;
        private readonly string latitude;
        private readonly string longitude;
        private int nbPortique;
        private int nbQuaisPassager;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private readonly Dictionary<String, Navire> navireAttendus;
        private readonly Dictionary<String, Navire> navireArrives;
        private readonly Dictionary<String, Navire> navirePartis;
        private readonly Dictionary<String, Navire> navireEnAttente;

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

        public void EnregistrerArriveePrevue(Navire navire)
        {
            this.navireAttendus.Add(navire.Imo, navire);
        }

        public void EnregistrerArrivee(Navire navire)
        {
            this.navireArrives.Add(navire.Imo, navire);
        }

        public void EnregistrerDepart(Navire navire)
        {
            this.navireArrives.Remove(navire.Imo);
        }

        private void AjoutNavireEnAttente(Navire navire)
        {
            this.navireEnAttente.Add(navire.Imo, navire);
        }

        public bool EstAttendu(String imo)
        {
            return (navireAttendus.ContainsKey(imo));
        }

        public bool EstPresent(String imo)
        {
            return (navireArrives.ContainsKey(imo));
        }

        public bool EstEnAttente(String imo)
        {
            return (navireEnAttente.ContainsKey(imo));
        }

        public void Chargement(Navire navire)
        {

        }
    }
}
