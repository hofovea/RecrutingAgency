using System.Collections.Generic;

namespace RecruitingAgency.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GitHub { get; set; }
        //Employer - Employee relation
        public string? EmployerId { get; set; }
        public ICollection<string> Recruits { get; set; }
        //Identity role
        public ICollection<string> Roles { get; set; }
        //Job posting
        public ICollection<int> JobPostings { get; set; }
    }
}
