using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task AddPerson(string identification, string firstName, string lastName, DateTime birthDate)
        {
            var person = new Person()
            {
                Identification = identification,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
            };

            await _peopleRepository.InsertOneAsync(person);
        }

        [HttpGet]
        public IEnumerable<Person> GetPeopleData()
        {
            var people = _peopleRepository.FilterBy(
                filter => true,
                person => new Person
                {
                    Identification = person.Identification,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate
                }
            );
            return people;
        }
    }
}
