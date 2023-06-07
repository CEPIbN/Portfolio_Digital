using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVP.Models;
using MVP.ViewModels;
using System;

namespace MVP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private ApplicationContext db;
        public UserApiController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var user = await GetAuthUser();
            if (user == null) 
            {
                Response.StatusCode = 404;
                await Response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
            else
            {
                await Response.WriteAsJsonAsync(user);
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task Update([FromBody] UserInfoModel userData)
        {
            //UserInfoModel? userData = await Request.ReadFromJsonAsync<UserInfoModel>();
            var user = await GetAuthUser();
            if (userData != null)
            {
                /*byte[] imageData;
                if (userData.Avatar != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await userData.Avatar.CopyToAsync(memoryStream);
                        imageData = memoryStream.ToArray();
                        user.Avatar = imageData;
                    }
                }
                else
                    user.Avatar = new byte[0];*/
                user.Age = userData.Age;
                user.Name = userData.Name ?? "";
                user.LastName = userData.LastName ?? "";
                user.PhoneNumber = userData.PhoneNumber ?? "";
                await db.SaveChangesAsync();
                await Response.WriteAsJsonAsync(user);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileViewModel model)
        {

            //IFormFile file = model.FileData;
            try
            {
                IFormFile file = model.FileData;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var user = await GetAuthUser();
                    var fileData = new FileData
                    {
                        FileName = model.FileName,
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
                return RedirectToAction("Upload", "Content");
            }
        }
        private async Task<User> GetAuthUser()
        {
            var userName = User.Identity.Name;
            var user = await db.Users.FirstOrDefaultAsync(item => item.Email == userName);
            return user;
        }
    }
}
