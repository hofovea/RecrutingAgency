using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using DAL.Repositories;

namespace DAL
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private UserRepository _userRepository;
        private JobPostingRepository _jobPostingRepository;

        public IRepository<User, string> Users => 
            _userRepository ?? new UserRepository(_context);

        public IRepository<JobPosting, int> JobPostings =>
            _jobPostingRepository ?? new JobPostingRepository(_context);

        public UnitOfWork(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
