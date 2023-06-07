using System.ComponentModel.DataAnnotations.Schema;

namespace MVP.Models
{
    public class FileData
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public byte[] Data { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
