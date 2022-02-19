using DataCollection.Models;
using DataCollection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PeopleController(IPersonRepository personRepository)
        {

            _personRepository = personRepository;

        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await _personRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPeople(int id)
        {
            return await _personRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPeople([FromBody] Person person)
        {
            var newPerson = await _personRepository.Create(person);
            return CreatedAtAction(nameof(GetPeople), new { id = newPerson.Id }, newPerson);

        }

        [HttpPut]
        public async Task<ActionResult> PutPeople(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            await _personRepository.Update(person);

            return NoContent();


        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var personToDelete = await _personRepository.Get(id);
            if (personToDelete == null)
                return NotFound();

            await _personRepository.Delete(personToDelete.Id);
            return NoContent();
        }
    }
}
