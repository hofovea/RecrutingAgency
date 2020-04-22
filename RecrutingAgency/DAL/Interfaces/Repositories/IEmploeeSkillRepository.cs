using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces.Repositories
{
    interface IEmploeeSkillRepository
    {
        Task<IEnumerable<EmploeeSkill>> GetAll();
        Task<EmploeeSkill> Get(string emploeeId, int skillId);
        void Insert(EmploeeSkill item);
        void Update(EmploeeSkill item);
        void Delete(string emploeeId, int skillId);
    }
}
