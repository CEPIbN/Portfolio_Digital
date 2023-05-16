using System.Linq;

namespace MVP.Models
{
    public interface IPersonRepository
    {
        Dictionary<int, Person> People
        {
            get;
        }
        public Person AddPerson(Person person);
        Person UpdatePerson(Person person);
        void DeletePerson(int id);
        Person GetPersonById(int id);
    }
}
