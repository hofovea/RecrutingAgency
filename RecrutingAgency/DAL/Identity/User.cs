using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class User : IdentityUser
    {
        public User()
        {
            JobPostings = new List<JobPosting>();
        }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string GitHub { get; set; }
        public virtual ICollection<UserToRole> Roles { get; set; }
        public virtual ICollection<JobPosting> JobPostings { get; set; }
    }
}
