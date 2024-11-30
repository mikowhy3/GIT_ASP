using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult BirthdayResult(Birthday birth)
    {
        if (!birth.IsValid())
        {
            return View("Error");
        }
        return View(birth);
    }
    
    public IActionResult BirthdayForm()
    {
        return View();
    }
}