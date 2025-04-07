using People.Application.DTO.Request;
using People.Domain.Entities;

namespace People.Application.Interfaces.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPeople();
        Person? GetPersonById(Guid id);
        Person AddPerson(PersonRequestDTO newPerson);
        Person? UpdatePerson(Guid id, PersonRequestDTO updatedPerson);
        bool DeletePerson(Guid id);
        IEnumerable<Person> Filter(PersonFilterDTO filter);
    }
}
