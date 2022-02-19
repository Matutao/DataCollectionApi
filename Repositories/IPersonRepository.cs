using DataCollection.Models;


//Here we have all the commands that we need to use. 


namespace DataCollection.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> Get();
        Task<Person> Get(int id);

        Task<Person> Create(Person person);

        Task Update(Person person);
        Task Delete(int id);

    }
}
