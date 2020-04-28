using System;
using System.Collections.Generic;
using System.Text;
using DAL.Identity;

namespace DAL.Entities
{
    public class UserToSkill
    {
        public string UserId { get; set; }
        public int SkillId { get; set; }
        public virtual User User { get; set; }
        public virtual Skill Skill { get; set; }
        public int KnowledgeLevel { get; set; }
    }
}