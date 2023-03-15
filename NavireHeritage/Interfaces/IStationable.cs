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

        /// <summary>
        /// Retourne vrai si l'objet dont l'id est passé en paramètre fait partie des objets attendus dans la station.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool EstAttendu(String id);

        /// <summary>
        /// Retourne vrai si l'objet dont l'id est passé en paramètre fait partie des objets présents dans la station.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool EstPresent(String id);

        /// <summary>
        /// Retourne vrai si l'objet dont l'id est passé en paramètre est parti de la station depuis peu de temps.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool EstParti(String id);

        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetUnAttendu(String id);

        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetUnArrive(String id);

        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetUnParti(String id);

    }
}
