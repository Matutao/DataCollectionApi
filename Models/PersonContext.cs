using Microsoft.EntityFrameworkCore;


namespace DataCollection.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)

        {
            Database.EnsureCreated();

        }
        public DbSet<Person> People { get; set; }
    }
}
