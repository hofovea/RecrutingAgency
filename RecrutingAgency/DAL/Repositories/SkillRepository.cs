using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    public class SkillRepository : BaseRepository<Skill, int>
    {
        public SkillRepository(Context context) : base(context)
        {
        }
    }
}
