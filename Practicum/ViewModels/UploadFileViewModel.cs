using System.ComponentModel.DataAnnotations;

namespace MVP.ViewModels
{
    public class UploadFileViewModel
    {
        [Required]
        public string? FileName { get; set; }
        public string? Description { get; set; }
        [Required]
        public IFormFile? FileData { get; set; }
        public UploadFileViewModel()
        {
            Description = "";
        }
    }
}
