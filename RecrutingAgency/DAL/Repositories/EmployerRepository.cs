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
    public class EmployerRepository : BaseRepository<Employer, string>
    {
        public EmployerRepository(Context context) : base(context)
        { }
    }
}
