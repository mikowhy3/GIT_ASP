using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers;

public class ContaktController : Controller
{
    private readonly IContactService _contactService;

    public ContaktController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }
    // formularz dodania kontatku
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    //Odebranie danych z formularza, zapis kontaktu i powrót do listy kontaków
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Add(model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    public ActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }

    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(model);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }
}