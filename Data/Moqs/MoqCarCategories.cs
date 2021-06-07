using System;
using System.Collections.Generic;

using System.Linq;

using Data.Interfaces;
using Data.Models;

namespace Data.Moqs
{
    public class MoqCarCategories : IGetCarCategories
    {
        public IEnumerable<CarCategory> GetCarCategories
        {
            get
            {
                return new List<CarCategory>
                {
                    new CarCategory {id = 0,categoryName="Electric Cars",description="Cars on electric engine"},
                    new CarCategory{id =1, categoryName="IC Cars",description="Internal combustion engine"},
                    new CarCategory{id =1, categoryName="Disel Cars",description="Cars on disel engine"}
                };
            }
        }
    }
}
