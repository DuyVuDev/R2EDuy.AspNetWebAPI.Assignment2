using People.Domain.Entities;

namespace People.Application.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person? GetById(Guid id);
        void Add(Person person);
        Person? Update(Person person);
        void Delete(Guid id);
    }
}
