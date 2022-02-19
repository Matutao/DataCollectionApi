using DataCollection.Models;
using Microsoft.EntityFrameworkCore;

//We execute the commands here 

namespace DataCollection.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<Person> Create(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task Delete(int id)
        {
            var personToDelete = await _context.People.FindAsync(id);
            _context.People.Remove(personToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> Get(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
