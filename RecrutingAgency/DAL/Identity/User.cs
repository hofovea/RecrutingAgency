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
            UserSkills = new List<UserToSkill>();
            Educations = new List<Education>();
            Projects = new List<Project>();
            WorkExperiences = new List<WorkExperience>();
            UserRequirements = new List<UserToRequirement>();
        }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageProfileUrl { get; set; }
        public string GitHub { get; set; }
        //Identity
        public virtual ICollection<UserToRole> Roles { get; set; }
        //Employee
        public virtual ICollection<UserToSkill> UserSkills { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        //Employer
        public virtual ICollection<UserToRequirement> UserRequirements { get; set; }
    }
}
