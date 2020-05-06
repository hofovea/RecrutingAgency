using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO.JobPosting;

namespace BLL.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GitHub { get; set; }
        //Employer - Employee relation
        public string? EmployerId { get; set; }
        //public virtual UserDto Employer { get; set; }
        public virtual ICollection<UserDto> Recruits { get; set; }
        //Identity role
        public virtual ICollection<RoleDto> Roles { get; set; }
        //Job posting
        public virtual ICollection<JobPostingDto> JobPostings { get; set; }
    }
}
