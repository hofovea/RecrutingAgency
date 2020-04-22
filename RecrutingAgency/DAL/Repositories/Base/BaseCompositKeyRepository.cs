using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Base
{
    public abstract class BaseCompositKeyRepository<T, TFirstId, TSecondId> :
        ICompositKeyRepository<T, TFirstId, TSecondId> where T : class
    {
        protected readonly Context Context;
        protected BaseCompositKeyRepository(Context context)
        {
            Context = context;
        }

        /* * * * * * * * * * * * * * * * * * * * *
         *                                       *
         *   IF GET AND GETALL ARE NOT WORKING   *
         *    MAKE METHODS SYNC AND SWITCH TO    *
         *             FIRST RETURN.             *
         *                                       *
         * * * * * * * * * * * * * * * * * * * * */

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(TFirstId emploeeId, int skillId)
        {
            return await Context.Set<T>().FindAsync(emploeeId, skillId);
        }

        public async void Insert(T item)
        {
            await Context.Set<T>().AddAsync(item);
        }

        public async void Update(T item, TFirstId firstId, TSecondId secondId)
        {
            var localEntity = await Context.Set<T>().FindAsync(firstId, secondId);
            if (localEntity != null)
            {
                Context.Entry(localEntity).State = EntityState.Detached;
            }
            Context.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(TFirstId firstId, TSecondId secondId)
        {
            var entity = await Context.Set<T>().FindAsync(firstId, secondId);
            if (entity != null)
                Context.Set<T>().Remove(entity);
        }
    }
}