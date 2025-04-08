using People.Application.DTO.Request;
using People.Application.Interfaces.Repositories;
using People.Application.Interfaces.Services;
using People.Domain.Entities;

namespace People.Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }


        public Person AddPerson(PersonRequestDTO newPerson)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = newPerson.FirstName,
                LastName = newPerson.LastName,
                DateOfBirth = newPerson.DateOfBirth,
                Gender = newPerson.Gender,
                BirthPlace = newPerson.BirthPlace
            };
            _personRepository.Add(person);
            return person;
        }

        public bool UpdatePerson(Guid id, PersonRequestDTO updatedPerson)
        {
            var existingPerson = _personRepository.GetById(id);

            if (existingPerson == null)
            {
                return false;
            }

            existingPerson.FirstName = updatedPerson.FirstName;
            existingPerson.LastName = updatedPerson.LastName;
            existingPerson.Gender = updatedPerson.Gender;
            existingPerson.DateOfBirth = updatedPerson.DateOfBirth;
            existingPerson.BirthPlace = updatedPerson.BirthPlace;

            return true;
        }
        public bool DeletePerson(Guid id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                return false;
            }
            else
            {
                _personRepository.Delete(id);
                return true;
            }
        }
        public IEnumerable<Person> Filter(PersonFilterDTO filter)
        {
            var people = _personRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                people = people.Where(p =>
                    (p.FirstName + " " + p.LastName).Contains(filter.Name));
            }

            if (filter.Gender.HasValue)
            {
                people = people.Where(p => p.Gender == filter.Gender.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.BirthPlace))
            {
                people = people.Where(p => p.BirthPlace == filter.BirthPlace);
            }

            return people;
        }
    }
}
