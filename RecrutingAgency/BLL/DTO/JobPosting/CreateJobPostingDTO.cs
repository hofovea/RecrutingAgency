﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.JobPosting
{
    public class CreateJobPostingDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Payment { get; set; }
        public string EmployerId { get; set; }
    }
}
