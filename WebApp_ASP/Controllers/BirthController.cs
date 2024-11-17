using Microsoft.AspNetCore.Mvc;
using WebApp_ASP.Models;

namespace WebApp_ASP.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result([FromForm] Birth model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            //double wynik = model.Calculate();  
            // ViewBag.Result = wynik;  
            return View(model);
        }
    }
}
