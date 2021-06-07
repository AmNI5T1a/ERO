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
                        name="Aston Martin One-77",
                        shortDescription="Powered by a 7.3-liter Cosworth V12, the One-77 produced 750 horsepower",
                        longDescription="Production of the pretty Aston Martin One-77 lasted just four years, from 2009 to 2012. And in that timeframe, the company only churned out 77 examples (as its name suggests) to some very lucky – and very wealthy – clients. At a cost of $1.4 million when new, the One-77 is one of the most expensive production Aston Martin models ever. Powered by a 7.3-liter Cosworth V12, the One-77 produced 750 horsepower (559 kilowatts) and could hit 60 miles per hour in just 3.5 seconds.",
                        img="/img/one77_bg_pic.jpg",
                        price=1400000,
                        isPopular=false,
                        isAvaliable=true,
                        categoryId=0,
                        category= _carCategories.GetCarCategories.First()
                    },
                    new Car{
                        id=2,
                        name="Zenvo TSR-R",
                        shortDescription="The total output for the TSR-S is listed at 1,177 horsepower",
                        longDescription="You may or may not have heard of the next car on this list, the Zenvo TSR-S. It debuted early in 2020 as a follow-up to the infamous ST1, sporting carbon fiber wheels, a wild adjustable rear wing, and a flat-plane 5.8-liter V8 with two superchargers. The total output for the TSR-S is listed at 1,177 horsepower (878 kilowatts), while the company estimates this car will hit 60 miles per hour in just 2.8 seconds. Zenvo plans to build just five cars per year at a cost of €1.45 million – or about $1.63M in US dollars.",
                        img="/img/zenvo-tsr_bg_pic.jpg",
                        price=1600000,
                        isPopular=true,
                        isAvaliable=true,
                        categoryId=1,
                        category= listOfCarCategories[1]
                    },
                    new Car{
                        id=3,
                        name="Hennessey Venom F5",
                        shortDescription="Powered by a twin-turbocharged 6.6-liter V8, the company touts 1,817 horsepower",
                        longDescription="Hennessey finally pulled the wraps off of its production Venom F5 back in December. Powered by a twin-turbocharged 6.6-liter V8, the company touts 1,817 horsepower (1,354 kilowatts), 1,193 pound-feet (1,617 Newton-meters), and a record-shattering top speed of 311 miles per hour (500 kilometers per hour) – although, we’ll have to see it to actually believe it. The price for all that performance is a steep $2.1 million, and deliveries are expected to kick off sometime this year.",
                        img="/img/hennessey-venom-bg_pic.jpg",
                        price=2100000,
                        isPopular=false,
                        isAvaliable=true,
                        categoryId=1,
                        category= listOfCarCategories[1]
                    },
                    new Car{
                        id=4,
                        name="Pininfarina Battista",
                        shortDescription="Complete with 1,827 fully electric horses (1,362 kilowatts) and a 0-60 mile-per-hour time of under 2.0 seconds",
                        longDescription="In 2019, Pininfarina surprised us all with the announcement of a high-end hypercar dubbed Battista, named after the company’s founder. The Battista’s full reveal came in March of that same year at the Geneva Motor Show, complete with 1,827 fully electric horses (1,362 kilowatts) and a 0-60 mile-per-hour time of under 2.0 seconds. Although we haven’t seen any full production versions yet, the company promises a limited run of 150 examples at a cost of $2.5 million each.",
                        img="/img/pininfarina_battista_bg_pic.jpg",
                        price=2500000,
                        isPopular=false,
                        isAvaliable=true,
                        categoryId=1,
                        category= listOfCarCategories[1]
                    },
                    new Car{
                        id=4,
                        name="Mercedes-AMG Project One",
                        shortDescription="Mercedes has promised a production version of the Project One hypercar for quite a while now",
                        longDescription="Mercedes has promised a production version of the Project One hypercar for quite a while now. The first official announcement was in March of 2017 before the first concept debuted later that same year. But after nearly five years of teasing, it appears as if the Project One will finally hit public roads. And when it does, the hybrid hypercar will have over 1,200 horsepower (895 kilowatts) and a price tag of $2.7 million.",
                        img="/img/mercedes-amg-project-one_bg_pic.jpg",
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
