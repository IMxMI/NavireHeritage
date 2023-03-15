using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interface
{
    interface IStationable
    {
        /// <summary>
        /// Méthode qui met à jour la liste des objets qui sont
        /// susceptibles d'arriver dans la station (port, aéroport,…).
        /// </summary>
        /// <param name="objects"></param>
        void EnregistrerArriveePrevue(Object objects);

        /// <summary>
        /// Méthode qui enregistre l'arrivée réelle de l'objet. 
        /// </summary>
        /// <param name="objects"></param>
        void EnregistrerArrivee(String objects);

        /// <summary>
        /// Méthode qui enregistre le départ d'un objet présent dans la station.
        /// </summary>
        /// <param name="objects"></param>
        void EnregistrerDepart(String objects);

        bool EstAttendu(String id);

        bool EstPresent(String id);

        bool EstParti(String id);

        object GetUnAttendu(String id);

        object GetUnArrive(String id);

        object GetUnParti(String id);

    }
}
