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
    class EmploeeRepository : BaseRepository<Emploee, string>
    {
        public EmploeeRepository(Context context) : base(context)
        { }
    }
}
