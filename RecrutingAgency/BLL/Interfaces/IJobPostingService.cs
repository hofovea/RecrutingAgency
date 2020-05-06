using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.DTO.JobPosting;


namespace BLL.Interfaces
{
    interface IJobPostingService
    {
        Task<IEnumerable<JobPostingDto>> GetAll();
        Task<JobPostingDto> GetById(int id);
        Task<JobPostingDto> Add(CreateUpdateJobPosingDto jobPostingDto);
        Task Update(int id, CreateUpdateJobPosingDto newJobPostingDto);
        Task Delete(int id);
    }
}
