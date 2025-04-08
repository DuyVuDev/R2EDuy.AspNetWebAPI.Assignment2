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

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonRequestDTO newPerson)
        {
            try
            {
                var addedPerson = _personService.AddPerson(newPerson);
                return CreatedAtAction(nameof(AddPerson), new { id = addedPerson.Id }, addedPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, [FromBody] PersonRequestDTO updatedRequestPerson)
        {
            try
            {
                var updatedPerson = _personService.UpdatePerson(id, updatedRequestPerson);
                return updatedPerson ? Ok("Person updated successfully!") : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            try
            {
                var deleted = _personService.DeletePerson(id);
                return deleted ? Ok("Person deleted successfully!") : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("filter")]
        public IActionResult Filter([FromQuery] PersonFilterDTO filterDto)
        {
            try
            {
                var result = _personService.Filter(filterDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

