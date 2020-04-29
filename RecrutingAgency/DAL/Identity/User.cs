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
            Recruits = new List<User>();
        }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string GitHub { get; set; }
        //Employer - Employee relation
        public string? EmployerId { get; set; }
        public virtual User Employer { get; set; }
        public virtual ICollection<User> Recruits { get; set; }
        //Identity role
        public virtual ICollection<UserToRole> Roles { get; set; }
        //Job posting
        public virtual ICollection<JobPosting> JobPostings { get; set; }
    }
}
