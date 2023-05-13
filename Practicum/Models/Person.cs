using System.ComponentModel.DataAnnotations;

namespace MVP.Models
{
    public class Person
    {
        [Required]
        public string? Login { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
