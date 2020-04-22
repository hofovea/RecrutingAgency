using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    public class EmployerRequirementRepository : BaseCompositKeyRepository<EmployerRequirement, string, int>
    {
        public EmployerRequirementRepository(Context context) : base(context)
        {
        }
    }
}
