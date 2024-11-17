using Microsoft.AspNetCore.Mvc;
using WebApp_ASP.Models;
using static WebApp_ASP.Controllers.HomeController;

namespace WebApp_ASP.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }

        // nasz formularz
        public IActionResult Form()
        {
            return View();
        }

        // PO STWORZENIU MODELU
        //W metodzie wskazano, które dane żądania powinny utworzyć model.
        //Atrybut [FromForm] wskazuje, że model
        //typu Calculator powinien zostać utworzony na podstawie
        //ciała żądania, w którym są dane z formularza
        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            return View(model);
        }

        // uzywamy modelu wiec to w kontrolerze niepotrzebne
        /*
        public IActionResult Result(Operator op, double? a, double? b)
        {
            double? result = null;

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

            ViewBag.Op = op;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.Result = result;

            return View();
        }
        */
    }
}
