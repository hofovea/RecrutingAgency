using System;
using DAL.Identity;

namespace DAL.Entities
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}