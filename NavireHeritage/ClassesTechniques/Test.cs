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
            }
            catch
            {

            }


        }
    }
}
