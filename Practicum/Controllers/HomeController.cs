using Microsoft.AspNetCore.Mvc;
using MVP.Models;
using MVP.ViewModels;
using System;

namespace MVP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("logIn")]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(string login, int password)
        {
            Person _person = IndexViewModel.People.FirstOrDefault(c => login == c.Login && password == c.Password);
            if (_person != null)
            {
                return NotFound();
            }
            return Content($"{_person.Login}-{_person.Email}");
        }

        [Route("logUp")]
        public IActionResult LogUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogUp(Person person)
        {
            Person _person = IndexViewModel.People.FirstOrDefault(c => person.Email == c.Email);
            if (_person == null)
            {  
                return View(person);
            }
            IndexViewModel.People.Add(person);
            return Content($"{person.Login}-{person.Email}");
        }
        public IActionResult GetUser(string login, string password)
        {
            return Content($"{login}-{password}");
        }
    }
}
