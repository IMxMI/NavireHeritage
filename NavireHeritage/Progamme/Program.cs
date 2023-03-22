using GestionNavire.Exceptions;
using NavireHeritage.ClassesTechniques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavireHeritage.ClassesMetier;

namespace NavireHeritage
{
    class Program
    {
        static void Main()
        {
            try
            {
                Port port = new Port("Marseille", "43.2976N", "5.3471E", 4, 3, 2, 4);
                Test.ChargementInitial(port);
                Console.WriteLine(port);




                //Test.AfficheAttendus(port);
                //Test.TestEnregistrerArriveePrevue(port, new Cargo("IMO9780859", "CMA CGM A. LINCOLN", 43.43279, 134.76258,
                //    140872, 148992, 123000, "marchandises diverses"));
                //Test.TestEnregistrerArriveePrevue(port, new Cargo("IMO9788889", "LINCOLN", 43.47279, 134.77258,
                //   140852, 148962, 123080, "marchandises diverses"));
                //Test.AfficheAttendus(port);


                // throw new GestionPortException("Test création d'erreur");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}