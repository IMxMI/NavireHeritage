﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interface
{
    interface INavCroisierable
    {
        /// <summary>
        /// Méthode qui met à jour la liste d'objets présents dans un 
        /// bateau(passagers ou autres) Les objets de la liste passée en paramètre 
        /// doivent être ajoutés de la liste des objets présents dans le navire.
        /// Une exception sera générée si le nombre d'objets dépasse le nombre de d'objets maximum du navire. 
        /// Aucun objet ne sera alors ajouté.
        /// </summary>
        /// <param name="objects">obj.</param>
        void Embarquer(List<Object> objects);

        /// <summary>
        /// Méthode qui met à jour la liste d'objets présents dans un bateau(passagers ou autres).
        /// Les objets passés en paramètres doivent être retirés de la liste des objets présents dans le navire.
        /// Cette méthode retourne la liste des objets passés en paramètre et qui n'ont pas été trouvés dans la liste des objets présents dans le navire.
        /// </summary>
        /// <param name="objects">Objs.</param>
        void Debarquer(List<Object> objects);
    }
}
