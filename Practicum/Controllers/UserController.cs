using Microsoft.AspNetCore.Mvc;
using MVP.Models;

namespace MVP.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(Person person)
        {
            return Content($"{person.Login} - {person.Password}");
        }


    }
}

