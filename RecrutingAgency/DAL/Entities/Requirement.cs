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
        public virtual ICollection<UserToRequirement> UserRequirements { get; set; }
        public Requirement()
        {
            UserRequirements = new List<UserToRequirement>();
        }
    }
}