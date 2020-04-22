using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IEmployerRequirementRepository
    {
        Task<IEnumerable<EmployerRequirement>> GetAll();
        Task<EmployerRequirement> Get(string idEmployerId, int requirementId);
        void Insert(EmployerRequirement item);
        void Update(EmployerRequirement item);
        void Delete(string employerId, int requirementId);
    }
}