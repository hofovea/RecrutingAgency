using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    public class UserToRequirementRepository : BaseCompositKeyRepository<UserToRequirement, string, int>
    {
        public UserToRequirementRepository(Context context) : base(context)
        {
        }
    }
}
