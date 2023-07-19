using Macrix.Contract;
using Macrix.Service;
using Microsoft.AspNetCore.Mvc;

namespace Macrix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PersonController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _peopleService.GetAllPeople());
        }

        [HttpGet("id")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_peopleService.GetPersonById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            return Ok(await _peopleService.AddPerson(person));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid personId)
        {
            return Ok(await _peopleService.DeletePersonById(personId));
        }
    }
}
