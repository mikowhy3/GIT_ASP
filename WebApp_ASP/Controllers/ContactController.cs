using Microsoft.AspNetCore.Mvc;
using WebApp_ASP.Models;
using WebApp_ASP.Models.Services;

namespace WebApp_ASP.Controllers
{
    public class ContactController : Controller
    {
        //Lista kontaktow

        // musimy korzystac z IContactService,
        // dlatego bo nie definiujemy jak te dane sa przekazywane
        // jesli mbyloby memorycontactservice to ciezko bo trzeba
        // by zmieniac 
        private readonly IContactService _contactService;



        // stworzenie konstruktora 
        // musi zostac wywalony przy tworzeniu instancji kontrolera
        // sprawdza potrzebne parametry, widzi ze potrzebny jest parametr
        // IContactService, sprawdza czy jest taki pracownik
        // ktory implementuje ten interfejs
        // jest jedna taka metoda MemoryContactService
        // ( dziedziczy ona po IContactService)
        // jesli instancji nie ma to sam stworzy i tu przekaze 
        // jesli instancja zostala wczesnien tworzona to przekazuje referencje
        // singleton to jedno zrodlo prawdy
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        public IActionResult Index()
        {
            // przekazanie listy, bardziej uniwersalne
            // ODDZIELENIE LOGIKI PRZETWARZANIA DANYCH OD WYSWIETLANIA
            return View(_contactService.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            // przekierowanie do akcji index
            // index juz wie co przekazac do modelu
            return RedirectToAction(nameof(Index));
            //alternatywa
            //return View("Index", _contactService);
            // return View("Index", contacts);
        }


        public IActionResult Details(int id)
        {
            //W tym miejscu contacts[id] zwraca pojedynczy obiekt
            //ContactModel, który jest przekazywany jako model do widoku.
            return View(_contactService.GetById(id));
        }


        [HttpGet]
        // to wyswietla co edytujemy
        public IActionResult Edit(int id)
        {
            /*
            if (!_contactService.(id))
            {
                return NotFound(); // Zwracamy 404, jeśli kontakt nie istnieje
            }
            */
            // Przekazujemy dane kontaktu do widoku Edit.cshtml
            // to ze tutaj jest contacts[id] powoduje ze basicowo do
            //formularza przekazywane sa dane z id. bez tego bylyby 
            // puste pola bez aktualnych danych
            return View(_contactService.GetById(id));
        }


        [HttpPost]
        // tu juz mozna edytowac 
        public IActionResult Edit(ContactModel model)
        {
            // Sprawdzamy poprawność modelu
            if (!ModelState.IsValid)
            {
                return View(model); // Zwracamy formularz z błędami walidacyjnymi
            }

            /*
            // Sprawdzamy, czy kontakt istnieje
            if (!contacts.ContainsKey(model.Id))
            {
                return NotFound(); // Zwracamy 404, jeśli kontakt nie istnieje
            }
            */

            // Aktualizacja danych kontaktu
            _contactService.Update(model);


            return RedirectToAction(nameof(Index));

            // Powrót do widoku listy kontaktów
            //return View("Index", contacts);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        // odebranie danyc z formularza, zapis kontaktu i powrot do listy kontaktow
        [HttpPost]
        public IActionResult Add(ContactModel model)
        {
            // jesli model niepoprawny to zwracamy formularz
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // zapisanie danych, powrot do widoku listy

            //return View("Index", contacts);: jawnie określasz,
            //że chcesz użyć widoku "Index"
            //i przekazujesz mu model contacts.

            //PRZENIESIENIE DO MEMORY CONTACTSERVICE
            //model.Id = ++_cureentId;
            // contacts.Add(model.Id, model);


            // logika przeniesiona do memorycontactserive a tam dodawane
            // potem zwracane
            _contactService.Add(model);
            return RedirectToAction(nameof(Index));
        }

        // potrzebujemy znac ostatni id aby dodajac sie nie zdublowal
        private static int _cureentId = 3;


    }
}
