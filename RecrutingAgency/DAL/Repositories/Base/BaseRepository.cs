using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Base
{
    public abstract class BaseRepository<T, TId> : IRepository<T, TId> where T : class
    {
        protected readonly Context Context;

        protected BaseRepository(Context context)
        {
            Context = context;
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async void AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public async void Update(T entity, TId id)
        {
            var localEntity = await Context.Set<T>().FindAsync(id);
            if (localEntity != null)
            {
                Context.Entry(localEntity).State = EntityState.Detached;
            }
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async void Delete(TId id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity != null)
                Context.Set<T>().Remove(entity);
        }
    }
}
