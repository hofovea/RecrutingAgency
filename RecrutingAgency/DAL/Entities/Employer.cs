using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Employer
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageProfileUrl { get; set; }
        public virtual EmployerAppUser EmployerAppUser { get; set; }
        public virtual ICollection<EmployerRequirement> Requirements { get; set; }
    }
}