using InfoAPI.Models;

namespace InfoAPI.Services 
{
    public class PersonService : IPerson {


        private PostgresSQLContext _context;
        public PersonService(PostgresSQLContext context) 
        {
            this._context = context;
        }
        public List<Person> getAllPersons() {
            return _context.Person.ToList();
        }
    }
}
