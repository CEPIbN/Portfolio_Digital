using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVP.Models;

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
    }
}
