using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<EmployerRequirement> EmployerRequirements { get; set; }
        public Requirement()
        {
            EmployerRequirements = new List<EmployerRequirement>();
        }
    }
}