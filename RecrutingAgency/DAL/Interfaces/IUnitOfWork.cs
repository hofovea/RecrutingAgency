using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces.Repositories;

namespace DAL.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<Emploee, string> Emploees { get; }
        IRepository<Employer, string> Employers { get; }
        IRepository<Project, int> Projects { get; }
        IRepository<Requirement, int> Requirements { get; }
        IRepository<Skill, int> Skills { get; }
        IRepository<WorkExperience, int> WorkExperiences { get; }
        IEmploeeSkillRepository EmploeeSkills { get; }
        IEmployerRequirementRepository EmployerRequirement { get; }
        AppEmploeeManager AppEmploeeManager { get; }
        AppRoleManager AppRoleManager { get; }
        AppEmployerManager AppEmployerManager { get; }
        Task SaveAsync();
    }
}
