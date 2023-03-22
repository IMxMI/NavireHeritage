using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavireHeritage.ClassesMetier;

namespace NavireHeritage.ClassesTechniques
{
    class Test
    {
        public static void TestEnregistrerArriveePrevue(Port port, Navire navire)
		{
            try
			{
                port.EnregistrerArriveePrevue(navire);
			}
            catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void ChargementInitial(Port port)
		{
			try
			{
				// cargo
				Croisiere croisiere = new Croisiere("IMO9241061", "CORSICA FERRIES", 48.78886, 27.7548, 15000, 14000, 13000, 'M', 2000);
				port.EnregistrerArriveePrevue(croisiere);
				port.EnregistrerArrivee(croisiere);
				port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CGM A. LINCOLN", 43.43279, 134.76258, 140872, 148992, 123000, "marchandises diverses"));
				port.EnregistrerArriveePrevue(new Cargo("IMO9250098", "CONTAINERSHIPS VII", 54.35412, 5.3644, 10499, 13965, 11000, "Matériel de loisirs"));
				port.EnregistrerArriveePrevue(new Cargo("IMO9502910", "MAERSK EMERALD", 54.72202, 170.54304, 141754, 141189, 137000, "marchandises diverses"));
				port.EnregistrerArriveePrevue(new Cargo("IMO9755933", "MSC DIANA", 39.74224, 5.99304, 193489, 202036, 176000, "Matériel industriel"));
				port.EnregistrerArriveePrevue(new Cargo("IMO9204506", "HOLANDIA", 41.74844, 6.87008, 8737, 9113, 7500, "marchandises diverses"));
				port.EnregistrerArriveePrevue(new Cargo("IMO9305893", "VENTO DI ZEFIRO", 41.50706, 11.41972, 17665, 22033, 16784, "Matériel industriel"));
				port.EnregistrerArriveePrevue(new Tanker("IMO9334076", "EJNAN", 52.84632, 42.14151, 140872, 148992, 123000, "Pétrole"));
				port.EnregistrerArriveePrevue(new Tanker("IMO9197832", "KALAMOS", 59.21826, 78.13472, 8737, 9113, 7500, "Gaz"));
				port.EnregistrerArriveePrevue(new Tanker("IMO9220952", "HARAD", 41.74844, 6.87008, 8737, 9113, 7500, "Huile"));
				port.EnregistrerArriveePrevue(new Tanker("IMO9379715", "NEW DRAGON", 41.50706, 11.41972, 17665, 22033, 16784, "Eau"));

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void AfficheAttendus(Port port)
		{
			Console.WriteLine("Liste des bateaux en attente de leur arrivée :");
			foreach(var navire in port.NavireAttendus)
			{
				Console.WriteLine($"IMO : {navire.Key}\t{navire.Value.Nom} : {navire.Value.GetType().Name}");
			}
		}

		public static void TestEnregistrerArrivee(Port port, String imo)
		{
			try
			{
				port.EnregistrerArrivee(imo);
				Console.WriteLine("navire " + imo + " arrivé");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void TestEnregistrerDepart(Port port, String imo)
		{
			try
			{
				port.EnregistrerDepart(imo);
				Console.WriteLine("navire" + imo + " parti");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
    }
}
