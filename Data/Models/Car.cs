using System;
using System.Collections.Generic;

using System.Linq;

namespace Data.Models
{
    public class Car
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public float Price { get; set; }
        public string CategoryID { get; set; }

        public Car(string name, string shortDes, string longDes, float price,string CategoryID)
        {
            this.Name = name;
            this.ShortDescription = shortDes;
            this.LongDescription = longDes;
            this.Price = price;
            this.CategoryID = CategoryID;
        }
    }
}
