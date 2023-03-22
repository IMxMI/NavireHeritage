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
                //Port port = new Port("Marseille", "43.2976N", "5.3471E", 4, 3, 2, 4);
                //Console.WriteLine(port);
                throw new GestionPortException("Test création d'erreur");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}