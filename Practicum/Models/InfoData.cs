namespace MVP.Models
{
    public class InfoData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public InfoData(User user) 
        {
            Name= user.Name;
            LastName= user.LastName;
            PhoneNumber= user.PhoneNumber;
        }
    }
}
