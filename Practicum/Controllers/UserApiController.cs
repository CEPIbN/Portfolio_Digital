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
            var userName = User.Identity.Name;
            var user = await db.Users.FirstOrDefaultAsync(item => item.Email == userName);
            if (user == null) 
            {
                Response.StatusCode = 404;
                await Response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
            else
            {
                await Response.WriteAsJsonAsync(new {login  =  $"{user.Login}" });
            }
            return Ok(new { login = $"{user.Login}" });
        }
        [HttpPost]
        public async Task Update([FromBody] UserInfoModel userData)
        {
            //UserInfoModel? userData = await Request.ReadFromJsonAsync<UserInfoModel>();
            var userName = User.Identity.Name;
            var user = await db.Users.FirstOrDefaultAsync(item => item.Email == userName);
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
    }
}
