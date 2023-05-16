using System.ComponentModel.DataAnnotations;

namespace MVP.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string? Login { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
