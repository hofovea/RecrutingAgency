using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class EducationRepository : BaseRepository<Education, int>
    {
        public EducationRepository(Context context) : base(context)
        { }
    }
}
