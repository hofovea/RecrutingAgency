using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Identity;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    class UserRepository : BaseRepository<User, string>
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
