using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class EmployerRequirement
    {
        public string EmployerId { get; set; }
        public int RequirementId { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Requirement Requirement { get; set; }
        public int MinimumKnowledgeLevel { get; set; }
    }
}