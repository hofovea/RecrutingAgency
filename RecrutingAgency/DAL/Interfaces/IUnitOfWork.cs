using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, string> Users { get; }
        IRepository<JobPosting, int> JobPostings { get; }
        Task<int> SaveAsync();
    }
}
