using People.Application.DTO.Request;
using People.Domain.Entities;

namespace People.Application.Interfaces.Services
{
    public interface IPersonService
    {

        Person AddPerson(PersonRequestDTO newPerson);
        bool UpdatePerson(Guid id, PersonRequestDTO updatedPerson);
        bool DeletePerson(Guid id);
        IEnumerable<Person> Filter(PersonFilterDTO filter);
    }
}
