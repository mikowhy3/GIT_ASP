using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_ASP.Models;

namespace WebApp_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Calculator(Operator? op, decimal? a, decimal? b)
        {
            
           
            decimal? result=0.0m;

            // Sprawdzenie, czy wartoœci a i b s¹ poprawne (nie null)
            if (a == null || b == null)
            {
                ViewBag.ErrorMessage = "Nieprawid³owe wartoœci dla a lub b.";
                return View();
            }

            if (a.HasValue && b.HasValue)
            {
                switch (op)
                {
                    case Operator.Add:
                        result = a + b;
                        break;
                    case Operator.Sub:
                        result = a - b;
                        break;
                    case Operator.Mul:
                        result = a * b;
                        break;
                    case Operator.Div:
                        if (b != 0)
                            result = a / b;
                        break;
                    default:
                        ViewBag.ErrorMessage = "Nieznany operator";
                        break;
                }
            }

            ViewBag.Result = result;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.Operator = op;
            return View();

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
