using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVP.Models;
using MVP.ViewModels;
using System;

namespace MVP.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private ApplicationContext db;
        public UserApiController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = db.Projects.ToList();
            return Ok(projects);
        }
        [HttpGet]
        public IActionResult GetProjectsWithQuery()
        {
            //if (searchInput == "" || searchInput == null)
            //{
            var users = db.Users.ToList();
            var projects = db.Projects.ToList();
            return Ok(projects);
        //}
            /*else
            {
                var projects = db.Projects.Where(item => item.ViewName == searchInput).ToList();
                return Ok(projects);
            }*/
        }
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var user = await GetAuthUser();
            if (user == null) 
            {
                Response.StatusCode = 404;
                return BadRequest(new { message = "Пользователь не найден" });
            }
            else
            {
                var projects = db.Projects.Where(item => item.UserId == user.Id).Select(fileData => new MyProject(fileData)).ToList();
                var users = db.Users.ToList();
                return Ok(new { user, projects });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UserInfoModel userData)
        {
            try
            {
                var user = await GetAuthUser();
                user.Name = userData.Name ?? "";
                user.LastName = userData.LastName ?? "";
                user.PhoneNumber = userData.PhoneNumber ?? "";
                db.Users.Update(user);
                await db.SaveChangesAsync();
                return Ok(new InfoData(user));
            }
            catch
            {
                Response.StatusCode = 404;
                return BadRequest(new { message = "Пользователь не найден" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetInfoData()
        {
            var user = await GetAuthUser();
            if (user == null)
            {
                Response.StatusCode = 404;
                return BadRequest(new { message = "Пользователь не найден" });
            }
            else
            {
                return Ok(new InfoData(user));
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileViewModel model)
        {
            try
            {
                var user = await GetAuthUser();
                IFormFile file = model.FileData;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    
                    var fileData = new FileData
                    {
                        Description = model.Description,
                        FileName = file.FileName,
                        ViewName = model.FileName,
                        ContentType = file.ContentType,
                        Data = memoryStream.ToArray(),
                        //UserId = user.Id,
                        //User = user
                    };
                    // Сохраните файл в базе данных
                    user.Projects.Add(fileData);
                }
                await db.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                Response.StatusCode = 404;
                return BadRequest(new { message = "Пользователь не найден" });
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
