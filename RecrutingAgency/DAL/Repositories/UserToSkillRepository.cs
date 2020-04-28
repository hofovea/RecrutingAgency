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
    public class UserToSkillRepository : BaseCompositKeyRepository<UserToSkill, string, int>
    {
        public UserToSkillRepository(Context context) : base(context)
       {
       }
    }
}