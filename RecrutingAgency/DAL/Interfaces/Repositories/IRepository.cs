using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<T, in TId> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(TId id);
        void Insert(T item);
        void Update(T item, TId id);
        void Delete(TId id);
    }
}