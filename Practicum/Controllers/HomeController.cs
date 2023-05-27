using Microsoft.AspNetCore.Authorization;
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
    }
}
