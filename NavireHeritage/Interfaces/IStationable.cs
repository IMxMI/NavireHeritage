using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interface
{
    interface IStationable
    {
        void EnregistrerArriveePrevue(Object objet);
        void EnregistrerArrivee(String objet);
        void EnregistrerDepart(String objet);
        bool EstAttendu(String id);
        bool EstPresent(String id);
        bool EstParti(String id);
        object GetUnAttendu(String id);
        object GetUnArrive(String id);
        object GetUnParti(String id);

    }
}
