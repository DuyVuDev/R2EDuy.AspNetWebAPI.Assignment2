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

        public IEnumerable<Person> GetAllPeople()
        {
            return _personRepository.GetAll();
        }

        public Person? GetPersonById(Guid id)
        {
            return _personRepository.GetById(id);
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

        public Person? UpdatePerson(Guid id, PersonRequestDTO updatedPerson)
        {
            var person = _personRepository.GetById(id);

            if (person != null)
            {
                person.FirstName = updatedPerson.FirstName;
                person.LastName = updatedPerson.LastName;
                person.DateOfBirth = updatedPerson.DateOfBirth;
                person.Gender = updatedPerson.Gender;
                person.BirthPlace = updatedPerson.BirthPlace;

                _personRepository.Update(person);
            }

            return person;
        }
        public bool DeletePerson(Guid id)
        {
            var person = _personRepository.GetById(id);

            if (person != null)
            {
                _personRepository.Delete(id);
                return true;
            }
            else
            {
                return false;
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
