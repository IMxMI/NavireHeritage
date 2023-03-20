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
				Test.TestEnregistrerArriveePrevue(port, new Cargo("IMO9780859", "CMA CGM A. LINCOLN", 43.43279, 134.76258, 140872, 148992, 123000, "marchandises diverses"));
				Console.WriteLine(port);
				Test.AfficheAttendus(port);
				Test.ChargementInitial(port);
				Test.TestEnregistrerArrivee(port, "IMO9241061");
				Test.TestEnregistrerArrivee(port, "IMO0000000");
				Console.ReadKey();
				
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}
