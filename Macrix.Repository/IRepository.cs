using Macrix.Contract;

namespace Macrix.Repository
{
    public interface IRepository
    {
        Task<bool> Add(Person person);
        Task<IEnumerable<Person>> GetAll();
        Person GetById(Guid id);
        Task<bool> RemoveById(Guid personId);
        Task Save();
    }
}