using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavireHeritage.ClassesMetier;

namespace NavireHeritage.ClassesTechniques
{
    public abstract class Test
    {
        public static void ChargementInitial(Port port)
        {
            try
            {
                // cargos
                port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CGM A. LINCOLN", 43.43279, 134.76258,
                    140872, 148992, 123000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9250098", "CONTAINERSHIPS VII", 54.35412, 5.3644,
                    10499, 13965, 11000, "Matériel de loisirs"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9502910", "MAERSK EMERALD", 54.72202, 170.54304,
                    141754, 141189, 137000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9755933", "MSC DIANA", 39.74224, 5.99304,
                    193489, 202036, 176000, "Matériel industriel"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9204506", "HOLANDIA", 41.74844, 6.87008,
                    8737, 9113, 7500, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9305893", "VENTO DI ZEFIRO", 41.5070, 11.41972, 
                    17665, 22033, 0, "Matériel industriel"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9305543", "O DI ZEFI", 43.3245, 6.87008,
                    17665, 22033, 7500, "Huile"));
                //port.EnregistrerArriveePrevue(new Cr)
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void AfficheAttendus(Port port)
        {
            Console.WriteLine("-------------------------------------------------------------------\n" +
                "Liste des bateaux en attente de leur arrivée :");
            foreach (var navire in port.NavireAttendus)
            {
                Console.WriteLine($"{navire.Key}\t{navire.Value.Nom} : {navire.Value.GetType().Name}");
            }
        }
    }
}
