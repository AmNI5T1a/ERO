using System;
using System.Collections.Generic;

using System.Linq;

using Data.Models;

namespace Data.Interfaces
{
    public interface IGetTopCars
    {
        IEnumerable<Car> GetAllTopCars();
    }
}
