namespace RecruitingAgency.Models.JobPosting
{
    public class JobPostingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Payment { get; set; }
        public bool IsActive { get; set; }
        public string EmployerId { get; set; }
    }
}
