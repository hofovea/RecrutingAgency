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
        public virtual ICollection<UserToSkill> UserSkills { get; set; }
        public Skill()
        {
            UserSkills = new List<UserToSkill>();
        }
    }
}