using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    class WorkExperienceRepository : BaseRepository<WorkExperience, int>
    {
        public WorkExperienceRepository(Context context) : base(context)
        {
        }
    }
}
