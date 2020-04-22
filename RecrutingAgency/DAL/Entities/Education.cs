using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string NameInstitution { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string EmploeeId { get; set; }
        public virtual Emploee EmploeeProfile { get; set; }
    }
}