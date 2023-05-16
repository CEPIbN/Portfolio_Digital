using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVP.Models;

namespace MVP.Controllers
{
    [Route("users/{id}")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        /* IPersonRepository repository;
        public PersonController(IPersonRepository repo) => repository = repo;
        [HttpGet("Information")]
        public Person Get(int id) => repository.People[id];
        [HttpPost]
        public Person Post([FromBody] Person res) => repository.AddPerson(new Person { Login = res.Login, Password = res.Password, Email = res.Email });
        [HttpPut]
        public Person Put([FromBody] Person res) => repository.UpdatePerson(res);
        [HttpDelete("Information")] 
        public void Delete(int id) => repository.DeletePerson(id);*/
    }
}
