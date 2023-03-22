using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNavire.Exceptions
{
    class GestionPortException : Exception
    {
        public GestionPortException(string message) : 
            base("Erreur le  : " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + " à " + DateTime.Now.ToString("HH:mm:ss") + "\n" + message)
        {}
    }
}
