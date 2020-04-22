using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    public class ProjectRepository : BaseRepository<Project, int>
    {
        public ProjectRepository(Context context) : base(context)
        {
        }
    }
}
