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
        private ProjectRepository _projectRepository;
        private RequirementRepository _requirementRepository;
        private SkillRepository _skillRepository;
        private WorkExperienceRepository _workExperienceRepository;
        private UserToSkillRepository _userToSkillRepository;
        private UserToRequirementRepository _userToRequirementRepository;

        public IRepository<User, string> Users => 
            _userRepository ?? new UserRepository(_context);

        public IRepository<Project, int> Projects => 
            _projectRepository ?? new ProjectRepository(_context);

        public IRepository<Requirement, int> Requirements => 
            _requirementRepository ?? new RequirementRepository(_context);

        public IRepository<Skill, int> Skills => 
            _skillRepository ?? new SkillRepository(_context);

        public IRepository<WorkExperience, int> WorkExperiences =>
            _workExperienceRepository ?? new WorkExperienceRepository(_context);

        public ICompositKeyRepository<UserToSkill, string, int> UserSkills =>
            _userToSkillRepository ?? new UserToSkillRepository(_context);

        public ICompositKeyRepository<UserToRequirement, string, int> UserRequirement =>
            _userToRequirementRepository ?? new UserToRequirementRepository(_context);

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
