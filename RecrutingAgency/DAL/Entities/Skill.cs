using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<EmploeeSkill> EmploeeSkills { get; set; }
        public Skill()
        {
            EmploeeSkills = new List<EmploeeSkill>();
        }
    }
}