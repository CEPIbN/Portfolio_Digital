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
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private ApplicationContext db;
        public UserApiController(ApplicationContext context)
        {
            db = context;
        }
        public async Task GetData()
        {
            var userName = User.Identity.Name;
            var user = db.Users.FirstOrDefaultAsync(item => item.Email == userName);
            if (user == null) 
            {
                Response.StatusCode = 404;
                await Response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
            else
            {
                await Response.WriteAsJsonAsync(user);
            }
        }
        public async Task Update()
        {
            UserInfoModel? userData = await Request.ReadFromJsonAsync<UserInfoModel>();
            var userName = User.Identity.Name;
            var user = await db.Users.FirstOrDefaultAsync(item => item.Email == userName);
            if (userData != null)
            {
                byte[] imageData;

                using (var memoryStream = new MemoryStream())
                {
                    await userData.Avatar.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }
                user.Age = userData.Age;
                user.Name = userData.Name;
                user.LastName = userData.LastName;
                user.PhoneNumber = userData.PhoneNumber;
                user.Avatar = imageData;
                await db.SaveChangesAsync();
                await Response.WriteAsJsonAsync(user);
            }
        }
    }
}
