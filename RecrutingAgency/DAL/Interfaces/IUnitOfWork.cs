using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces.Repositories;

namespace DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<User, string> Users { get; }
        IRepository<Project, int> Projects { get; }
        IRepository<Requirement, int> Requirements { get; }
        IRepository<Skill, int> Skills { get; }
        IRepository<WorkExperience, int> WorkExperiences { get; }
        ICompositKeyRepository<UserToSkill, string, int> UserSkills { get; }
        ICompositKeyRepository<UserToRequirement, string, int> UserRequirement { get; }
        Task<int> SaveAsync();
    }
}
