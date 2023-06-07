using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Mvc;
using MVP.Models;
using MVP.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MVP.Controllers
{
    public class ContentController : Controller
    {
        private ApplicationContext db;
        public ContentController(ApplicationContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Account()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.Users.Add(new User { Email = model.Email, Password = model.Password, Login = model.Login });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
		[Authorize]
		[HttpGet]
        public IActionResult Upload()
        {
            return View(); 
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile f)
        {

            IFormFile file = Request.Form.Files[0];
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("Upload", "Content");
            }
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var userName = User.Identity.Name;
                    var user = await db.Users.FirstOrDefaultAsync(item => item.Email == userName);
                    var fileData = new FileData
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        Data = memoryStream.ToArray(),
                        UserId = user.Id,
                    };

                    // Сохраните файл в базе данных
                    db.Projects.Add(fileData);

                }
                await db.SaveChangesAsync();

                return RedirectToAction("Account");
            }
            catch
            {
                Response.StatusCode = 404;
                await Response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
                return BadRequest();
            }
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "Cookies");
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Information()
        { 
            return View();
        }
    }
}

