using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PersonsApi.Data;
using PersonsApi.Models;

namespace PersonsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController:ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetPersons()
        {
            return await _context.person.ToListAsync();
        }

        //GET: api/person/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonId(int id)
        {
            var person = await _context.person.FindAsync(id);
            if (person == null)
                return NotFound();
            return person;
        }

        //GET: api/person/search?name=Joel
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PersonModel>>> SearchName(string name)
        {
            return await _context.person
                .Where(p => p.person_firstName.Contains(name) || p.person_lastName.Contains(name))
                .ToListAsync();
        }

        //GET: api/person
        [HttpPost]
        public async Task<ActionResult<PersonModel>> CreatePerson(PersonModel person)
        {
            _context.person.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersons), new { id = person.person_serial }, person);
        }

        //PUT: api/person/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, PersonModel updatePerson)
        {
            if (id != updatePerson.person_serial)
                return BadRequest("El ID de la url no coincide con el ID del cuerpo");

            var personInDb = await _context.person.FindAsync(id);
            if (personInDb == null)
                return NotFound();

            //Actualizamos los campos
            personInDb.person_firstName = updatePerson.person_firstName;
            personInDb.person_lastName = updatePerson.person_lastName;
            personInDb.person_dateOfBirth = updatePerson.person_dateOfBirth;
            personInDb.person_id = updatePerson.person_id;

            await _context.SaveChangesAsync();
            return NoContent();//204
        }

        //DELETE: api//person/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.person.FindAsync(id);
            if (person == null)
                return NotFound();

            _context.person.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
