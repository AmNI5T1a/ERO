using System;
using System.Collections.Generic;

using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Data.Interfaces;
using ViewModels;

namespace Controllers
{
    public class HomeController : Controller
    {
        private IGetTopCars _topCars;

        public HomeController(IGetTopCars allTopCars)
        {
            _topCars = allTopCars;
        }

        public ViewResult Index()
        {
            var carsForMainPage = new HomeViewModel
            {
                listOfTopCars = _topCars.GetAllTopCars()
            };

            return View();
        }
    }
}
