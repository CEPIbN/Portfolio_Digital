using Microsoft.AspNetCore.Mvc;
using MVP.Models;
using MVP.ViewModels;
using System;

namespace MVP.Controllers
{
    public class HomeController : Controller
    {
        private IPersonRepository repository;
        public HomeController(IPersonRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.People);
        }
        [Route("logIn")]
        public IActionResult LogIn()
        {
            return View();
        }
        [Route("Load")]
        [HttpGet]
        public IActionResult Load(int id)
        {
            try
            {
                var _person = repository.GetPersonById(id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        [Route("logUp")]
        public IActionResult LogUp()
        {
            return View();
        }
        [Route("LogUp")]
        [HttpPost]
        public IActionResult LogUp(Person person)
        {
            repository.AddPerson(person);
            return RedirectToAction("Index");
        }
    }
}
