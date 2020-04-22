using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    public class RequirementRepository : BaseRepository<Requirement, int>
    {
        public RequirementRepository(Context context) : base(context)
        {
        }
    }
}
