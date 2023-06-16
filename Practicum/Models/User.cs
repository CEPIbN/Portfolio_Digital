using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MVP.Models
{
    public class User
    {
        [InverseProperty("User")]
        public List<FileData> Projects { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public User()
        {
            Projects = new List<FileData>();
            Name = "";
            LastName = "";
            PhoneNumber = "";
            Login = "";
            Password = "";
            Email = "";
        }
    }
}
