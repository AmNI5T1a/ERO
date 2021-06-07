using System;
using System.Collections.Generic;

using System.Linq;

using Data.Models;

namespace Data.Interfaces
{
    interface IGetAllAvaliableCars
    {
        IEnumerable<Car> GetAllAvaliableCars { get; set; }
    }
}
