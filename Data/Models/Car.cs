using System;
using System.Collections.Generic;

using System.Linq;

namespace Data.Models
{
    public class Car
    {
        public ushort id { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string img { get; set; }
        public decimal price { get; set; }
        public bool isPopular { get; set; }
        public bool isAvaliable { get; set; }
        public int categoryId { get; set; }

        public virtual CarCategory category { get; set; }
    }
}
