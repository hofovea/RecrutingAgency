using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces.Repositories
{
    interface ICompositKeyRepository<T, in TFirstId, in TSecondId> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(TFirstId firstId, TSecondId secondId);
        void Insert(T item);
        void Update(T item, TFirstId firstId, TSecondId secondId);
        void Delete(TFirstId firstId, TSecondId secondId);
    }
}
