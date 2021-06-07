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
        

        public ViewResult Index()
        {
            

            return View();
        }
    }
}
