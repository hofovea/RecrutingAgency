using System;
using System.Collections.Generic;
using System.Text;
using DAL.Identity;

namespace DAL.Entities
{
    public class UserToRequirement
    {
        public string UserId { get; set; }
        public int RequirementId { get; set; }
        public virtual User User { get; set; }
        public virtual Requirement Requirement { get; set; }
        public int MinimumKnowledgeLevel { get; set; }
    }
}