using Microsoft.AspNetCore.Mvc;
using People.Application.DTO.Request;
using People.Application.Interfaces.Services;

namespace People.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var people = _personService.GetAllPeople();
            return Ok(people); // Return the list of people
        }
        [HttpGet("{id}")]
        public IActionResult GetPersonById(Guid id)
        {
            var person = _personService.GetPersonById(id);
            return person == null ? NotFound() : Ok(person); // Return the person details
        }
        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonRequestDTO newPerson)
        {
            var addedPerson = _personService.AddPerson(newPerson);
            return CreatedAtAction(nameof(GetPersonById), new { id = addedPerson.Id }, addedPerson); // Return the created person
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, [FromBody] PersonRequestDTO updatedRequestPerson)
        {
            var updatedPerson = _personService.UpdatePerson(id, updatedRequestPerson);
            return updatedPerson == null ? NotFound() : Ok(updatedPerson); // Return no content on success
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            var deleted = _personService.DeletePerson(id);
            return deleted ? Ok("Person deleted successfully!") : NotFound(); // Return no content on success
        }

        [HttpGet("filter")]
        public IActionResult Filter([FromQuery] PersonFilterDTO filterDto)
        {
            var result = _personService.Filter(filterDto);
            return Ok(result);
        }
    }

}

