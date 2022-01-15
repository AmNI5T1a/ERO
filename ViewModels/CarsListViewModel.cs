using System;
using System.Collections.Generic;

using System.Linq;
using Data.Models;

namespace ViewModels
{
    public class CarsListViewModel
    {
        public LinkedList<Car> allCars { get; set; }

        public CarsListViewModel()
        {
            allCars = new LinkedList<Car>();
        }
    }
}
