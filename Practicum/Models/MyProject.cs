namespace MVP.Models
{
    public class MyProject
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? ViewName { get; set; }
        public string? ContentType { get; set; }
        public string? Description { get; set; }
        public byte[]? Data { get; set; }
        public MyProject(FileData data)
        {
            Id = data.Id;
            FileName = data.FileName;
            ViewName = data.ViewName;
            ContentType= data.ContentType;
            Description= data.Description;
            Data = data.Data;
        }
    }
}
