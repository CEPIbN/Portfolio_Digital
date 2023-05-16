using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Mvc;
using MVP.Models;

namespace MVP.Controllers
{
    [Route("[controller]/{login}")]
    public class ContentController : Controller
    {
        private IPersonRepository repository;
        public ContentController(IPersonRepository repo)
        {
            repository = repo;
        }
        public IActionResult Account(string login)
        {
            try
            {
                return View(repository.People.First(item => item.Value.Login == login).Value);
            }
            catch (Exception) 
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Upload(string login)
        {
            IFormFileCollection files = Request.Form.Files;
            // путь к папке, где будут храниться файлы
            var uploadPath = $"{Directory.GetCurrentDirectory()}/{login}";
            // создаем папку для хранения файлов
            Directory.CreateDirectory(uploadPath);
            foreach (var file in files)
            {
                // путь к папке uploads
                string fullPath = $"{uploadPath}/{file.FileName}";

                // сохраняем файл в папку uploads
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            //return Ok(files);
            return View("Account", repository.People.First(item => item.Value.Login == login).Value);
        }
        [Route("[action]")]
        public IActionResult Privacy(int id)
        {
            return View(repository.People[id]);
        }
        [Route("home")]
        public IActionResult Home(string login)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}

