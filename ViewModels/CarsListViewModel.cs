using System;
using System.Collections.Generic;

using System.Linq;
using Data.Models;

namespace ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        
        public string currentCategory { get; set; }
    }
}
