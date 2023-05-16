using System.Linq;

namespace MVP.Models
{
    public class FakePersonRepository : IPersonRepository
    {
        public Dictionary<int, Person> People { get; }
        public FakePersonRepository()
        {
            People = new Dictionary<int, Person>();
            People[0] = new Person { Login = "bugaggga", Password = 123, Email = "bogachev762@gmail.com" };
        }
        public Person AddPerson(Person person)
        {
            if (person.Id==0)
            {
                int key = People.Count; 
                while (People.ContainsKey(key))
                {
                    key++;
                }
                person.Id = key;
            }
            People[person.Id] = person;
            return person;
        }
        public void DeletePerson(int id) => People.Remove(id);
        public Person UpdatePerson(Person person) => AddPerson(person);
        public Person GetPersonById(int id)
        {
            try
            {
                return People.First(item => item.Key==id).Value;
            }
            catch(Exception)
            {
                throw new Exception("Not Found");
            }
        }
    }
}
