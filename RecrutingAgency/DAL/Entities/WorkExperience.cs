using System;

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
        public string EmploeeId { get; set; }
        public virtual Emploee Emploee { get; set; }
    }
}