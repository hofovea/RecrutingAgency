using System;
using System.Collections.Generic;
using System.Text;
using DAL.Identity;

namespace DAL.Entities
{
    public class JobPosting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Payment { get; set; }
        public bool IsActive { get; set; }
        public string EmployerId { get; set; }
        public virtual User Employer { get; set; }
    }
}
