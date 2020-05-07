﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class Role : IdentityRole
    {
        public Role(string roleName) : base(roleName)
        {
        }
        public Role() : base()
        {
        }
        public virtual ICollection<UserToRole> UserRoles { get; set; }
    }
}
