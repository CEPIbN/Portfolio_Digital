using System.ComponentModel.DataAnnotations;

namespace MVP.Models
{
    public class User
    {
        public byte[] Avatar { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
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
            Avatar = new byte[0];
            Name = "";
            LastName = "";
            PhoneNumber = "";
            Login = "";
            Password = "";
            Email = "";
        }
    }
}
