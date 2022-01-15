using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller
    {
        

        public ViewResult Index()
        {
            ViewBag.Title = "Home";

            return View();
        }
    }
}
