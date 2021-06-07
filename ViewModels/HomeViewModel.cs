using System;
using System.Collections.Generic;

using System.Linq;

using Data.Models;

namespace ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> listOfTopCars { get; set; }
    }
}
