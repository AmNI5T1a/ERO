using System;
using System.Collections.Generic;

using System.Linq;

namespace Data.Models
{
    public class CarCategory
    {
        public ushort id { get;  set; }
        public string categoryName { get; set; }
        public string description { get; set; }

        public List<Car> listOfCars { get; set; }
    }
}
