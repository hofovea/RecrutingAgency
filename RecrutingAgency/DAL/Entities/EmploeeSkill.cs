using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class EmploeeSkill
    {
        public string EmploeeId { get; set; }
        public int SkillId { get; set; }
        public virtual Emploee Emploee { get; set; }
        public virtual Skill Skill { get; set; }
        public int KnowledgeLevel { get; set; }
    }
}