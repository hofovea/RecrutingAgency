using System;
using System.Collections.Generic;
using System.Text;
using DAL.Identity;

namespace DAL.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string NameInstitution { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}