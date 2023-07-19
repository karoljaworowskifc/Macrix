using Macrix.Contract;
using Macrix.Repository;

namespace Macrix.Service
{
    public class PeopleService : IPeopleService
    {
        private readonly IRepository _repository;

        public PeopleService(IRepository repository)
        {
            _repository = repository;

        }
        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _repository.GetAll();
        }

        public Person GetPersonById(Guid id)
        {
            return _repository.GetById(id);
        }

        public async Task<bool> AddPerson(Person person)
        {
            return await _repository.Add(person);
        }

        public async Task<bool> DeletePersonById(Guid personId)
        {
            return await _repository.RemoveById(personId);
        }
    }
}