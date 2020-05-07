using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitingAgency.Models.JobPosting
{
    public class UpdateJobPostingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Payment { get; set; }
    }
}
