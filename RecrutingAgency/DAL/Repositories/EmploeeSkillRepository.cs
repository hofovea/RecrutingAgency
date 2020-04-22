using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces.Repositories;
using DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmploeeSkillRepository : BaseCompositKeyRepository<EmploeeSkill, string, int>
    {
        public EmploeeSkillRepository(Context context) : base(context)
       {
       }
    }
}