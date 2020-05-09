using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.DTO.JobPosting;


namespace BLL.Interfaces
{
    public interface IJobPostingService
    {
        Task<IEnumerable<JobPostingDto>> GetAll();
        Task<JobPostingDto> GetById(int id);
        Task<JobPostingDto> Add(CreateJobPostingDto jobPostingDto);
        Task Update(int id, UpdateJobPostingDto newJobPostingDto);
        Task Delete(int id);
    }
}
