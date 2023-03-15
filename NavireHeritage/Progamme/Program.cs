using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage
{
    class Program
    {
        static void Main(string[] args)
        {
            Port port = new Port("Marseille", "43.2976N", "5.3471E", 4, 3, 2, 4);
            Console.WriteLine(port);
        }
    }
}
