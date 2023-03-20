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
				port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CGM A. LINCOLN", 43.43279, 134.76258, 140872, 148992, 123000, "marchandises diverses"));
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
    }
}
