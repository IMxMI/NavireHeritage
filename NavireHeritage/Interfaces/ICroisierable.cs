﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interface
{
    interface INavCroisierable
    {
        void Embarquer(List<Object> objects);
        void Debarquer(List<Object> objects);
    }
}
