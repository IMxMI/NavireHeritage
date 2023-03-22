using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavireHeritage.ClassesMetier;
using NavireHeritage.ClassesTechniques;

namespace NavireHeritage
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
                Port port = new Port("Marseille", "43.2976N", "5.3471E", 4, 3, 2, 4);
				//Test.TestEnregistrerArriveePrevue(port, new Cargo("IMO9780859", "CMA CGM A. LINCOLN", 43.43279, 134.76258, 140872, 148992, 123000, "marchandises diverses"));
				Console.WriteLine(port);
				Test.AfficheAttendus(port);
				Test.ChargementInitial(port);
				
				/**
				 * Dans ce test on enregistre l'arrivée d'un petit tanker attendu et il y a de la place
				 */
				Test.TestEnregistrerArrivee(port, "IMO9334076");
				/**
				 * On rajoute 2 super tankers attendus
				 */
				Test.TestEnregistrerArrivee(port, "IMO9197832");
				Test.TestEnregistrerArrivee(port, "IMO9220952");
				Test.TestEnregistrerArrivee(port, "IMO9379715");
				/**
				 * On essaie de faire partir un navire qui n'est pas arrivé
				 */


				Test.TestEnregistrerDepart(port, "IMO933333");

				/*
				 * On fait partir le navire de croisière, 
				 * il y a touours le super tanker en attente
				 */
				Test.TestEnregistrerDepart(port, "IMO9241061");
				Console.ReadKey();
				
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}
