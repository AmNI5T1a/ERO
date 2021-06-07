using System;
using System.Collections.Generic;

using System.Linq;

using Data.Interfaces;
using Data.Models;

namespace Data.Moqs
{
    public class MoqCars : IGetAllAvaliableCars, IGetAllCars, IGetCarWithID, IGetTopCars
    {
        private IGetCarCategories _carCategories = new MoqCarCategories();

        public IEnumerable<Car> GetAllAvaliableCars { get; set; }



        public IEnumerable<Car> GetAllCars
        {
            get
            {
                List<CarCategory> listOfCarCategories = _carCategories.GetCarCategories.ToList();

                return new List<Car>
                {
                    new Car{
                        id=1,
                        name="Tesla",
                        shortDescription="Tesla cars",
                        longDescription="Long description about tesla cars",
                        img="rn is empty",
                        price=45000,
                        isPopular=true,
                        isAvaliable=false,
                        categoryId=0,
                        category= _carCategories.GetCarCategories.First()
                    },
                    new Car{
                        id=2,
                        name="BWM",
                        shortDescription="BWM cars",
                        longDescription="Long description about BWM cars",
                        img="rn is empty",
                        price=35000,
                        isPopular=true,
                        isAvaliable=true,
                        categoryId=1,
                        category= listOfCarCategories[1]
                    },
                    new Car{
                        id=3,
                        name="Audi",
                        shortDescription="Audi cars",
                        longDescription="Long description about Audi cars",
                        img="rn is empty",
                        price=40000,
                        isPopular=false,
                        isAvaliable=true,
                        categoryId=1,
                        category= listOfCarCategories[1]
                    },
                    new Car{
                        id=4,
                        name="Nissan",
                        shortDescription="Nissan cars",
                        longDescription="Long description about Nissan cars",
                        img="rn is empty",
                        price=20000,
                        isPopular=false,
                        isAvaliable=true,
                        categoryId=1,
                        category= listOfCarCategories[1]
                    },
                    new Car{
                        id=4,
                        name="HAVAL",
                        shortDescription="HAVAL cars",
                        longDescription="Long description about HAVAL cars",
                        img="rn is empty",
                        price=15000,
                        isPopular=true,
                        isAvaliable=true,
                        categoryId=0,
                        category= listOfCarCategories[2]
                    }
                };
            }
        }

        public IEnumerable<Car> GetAllTopCars
        {
            get
            {
                List<Car> listOfTopCars = new List<Car>();

                foreach (Car car in GetAllCars)
                {
                    if (car.isPopular)
                        listOfTopCars.Add(car);
                }

                return listOfTopCars;
            }
        }

        public Car GetCarWithID(ushort carID)
        {
            throw new NotImplementedException();
        }

    }
}
