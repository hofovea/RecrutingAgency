﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<T, in TId> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TId id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        void AddAsync(T item);
        void Update(T item, TId id);
        void Delete(TId id);
    }
}