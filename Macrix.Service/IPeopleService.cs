using Macrix.Contract;

namespace Macrix.Service
{
    public interface IPeopleService
    {
        Task<bool> AddPerson(Person person);
        Task<bool> DeletePersonById(Guid personId);
        Task<IEnumerable<Person>> GetAllPeople();
        Person GetPersonById(Guid id);
    }
}