using System;
using System.Collections.Generic;

using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Data.Interfaces;
using ViewModels;

namespace Controllers
{
    public class CarsController : Controller
    {
        private readonly IGetAllCars _listOfCars;
        private readonly IGetCarCategories _listOfCarCategories;

        public CarsController(IGetAllCars listOfCars,IGetCarCategories listOfCarCategories) 
        {
            _listOfCarCategories = listOfCarCategories;
            _listOfCars = listOfCars;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Page with cars";

            CarsListViewModel tempCLVM_Obj = new CarsListViewModel();
            tempCLVM_Obj.allCars = _listOfCars.GetAllCars;
            tempCLVM_Obj.currentCategory = "Cars";

            return View(tempCLVM_Obj);
        }
    }
}
