using People.Application.Interfaces.Repositories;
using People.Domain.Entities;
using People.Domain.Enums;

namespace People.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _people = [];

        public PersonRepository()
        {
            GeneratePeopleData();
        }

        private void GeneratePeopleData()
        {
            var firstNames = new[] { "Alice", "John", "Jane", "Michael", "Sarah", "David", "Laura", "Robert", "Emily", "James" };
            var lastNames = new[] { "Nguyen", "Doe", "Smith", "Johnson", "Brown", "Williams", "Jones", "Garcia", "Miller", "Davis" };
            var birthPlaces = new[] { "Hanoi", "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas" };
            var random = new Random();

            for (int i = 0; i < 50; i++)
            {
                var person = new Person
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstNames[random.Next(firstNames.Length)],
                    LastName = lastNames[random.Next(lastNames.Length)],
                    DateOfBirth = new DateTime(random.Next(1960, 2010), random.Next(1, 13), random.Next(1, 29)),
                    Gender = (GenderType)random.Next(3),
                    BirthPlace = birthPlaces[random.Next(birthPlaces.Length)]
                };
                _people.Add(person);
            }
        }
        public IEnumerable<Person> GetAll() => _people;

        public Person? GetById(Guid id) => _people.FirstOrDefault(p => p.Id == id);

        public void Add(Person person) => _people.Add(person);

        public void Delete(Guid id) => _people.RemoveAll(p => p.Id == id);

        public Person? Update(Person person)
        {
            var existingPerson = _people.FirstOrDefault(p => p.Id == person.Id);

            if (existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Gender = person.Gender;
                existingPerson.DateOfBirth = person.DateOfBirth;
                existingPerson.BirthPlace = person.BirthPlace;
            }

            return existingPerson;
        }
    }
}
