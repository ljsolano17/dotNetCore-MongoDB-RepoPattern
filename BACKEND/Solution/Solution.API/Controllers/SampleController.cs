using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Solution.DAL.Repository;
using Solution.DO.Objects;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IMongoRepository<Person> _peopleRepository;

        public SampleController(IMongoRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        /// <summary>
        /// Other way to create a Post
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        /*  [HttpPost]
          public async Task AddPerson(string identification, string firstName, string lastName, DateTime birthDate)
          {
           
           var person = new Person()
           {
               Identification = identification,
               FirstName = firstName,
               LastName = lastName,
               BirthDate = birthDate,
           };
           new BS.Person(_peopleRepository).Insert(person);
           
          }*/

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            new BS.Person(_peopleRepository).Insert(person);
            return CreatedAtAction("GetPersons", new { id = person.Id }, person);
        }

        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {

            return new BS.Person(_peopleRepository).GetAll();

        }

        [HttpGet("{oid}")]
        public async Task<ActionResult<Person>> GetPersonById(string oid)
        {
            var person = new BS.Person(_peopleRepository).GetOneById(oid);
            if (person == null)
            {
                return BadRequest();
            }
            return person;

        }

        [HttpDelete("{oid}")]
        public async Task<ActionResult<Person>> Delete(string oid)
        {
            var person = new BS.Person(_peopleRepository).GetOneById(oid);
            if (person == null)
            {
                return NotFound();
            }
            new BS.Person(_peopleRepository).Delete(person);
            return person;

        }

        [HttpPut("oid")]
        public async Task<IActionResult> PutPerson(string oid, Person person)
        {
            if (string.IsNullOrEmpty(oid))
            {
                return BadRequest();
            }

            try
            {
                person.Id = ObjectId.Parse(oid);
                new BS.Person(_peopleRepository).Update(person);
            }
            catch (Exception ee)
            {
                if (PersonExists(oid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool PersonExists(string oid)
        {
            return (new BS.Person(_peopleRepository).GetOneById(oid) != null);
        }
    }
}
