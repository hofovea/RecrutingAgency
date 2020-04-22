using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Emploee
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageProfileUrl { get; set; }
        public virtual EmploeeAppUser EmploeeAppUser { get; set; }
        public string GitHub { get; set; }
        public virtual ICollection<EmploeeSkill> EmploeeSkills { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}