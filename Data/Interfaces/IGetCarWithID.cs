using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;

namespace Data.Interfaces
{
    interface IGetCarWithID
    {
        Car GetCarWithID(ushort carID);
    }
}
