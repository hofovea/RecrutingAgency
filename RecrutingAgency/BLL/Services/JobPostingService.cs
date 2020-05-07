using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.DTO.JobPosting;
using BLL.Exceptions;
using BLL.Identity;
using BLL.Interfaces;
using BLL.Validation.JobPosting;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services
{
    class JobPostingService : IJobPostingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public JobPostingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<JobPostingDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<JobPosting>, IEnumerable<JobPostingDto>>(
                await _unitOfWork.JobPostings.GetAllAsync());

        }

        public async Task<JobPostingDto> GetById(int id)
        {
            var jobPosting = await _unitOfWork.JobPostings.GetByIdAsync(id);
            if (jobPosting is null)
            {
                throw ExceptionBuilder.Create("JobPosing with such Id does not exist");
            }

            return _mapper.Map<JobPosting, JobPostingDto>(jobPosting);
        }

        public async Task<JobPostingDto> Add(CreateJobPostingDto jobPostingDto)
        {
            var validator = new CreateJobPostingDtoValidation();
            var validationResult = await validator.ValidateAsync(jobPostingDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var jobPostingToAdd = _mapper.Map<CreateJobPostingDto, JobPosting>(jobPostingDto);
            await _unitOfWork.JobPostings.AddAsync(jobPostingToAdd);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<JobPosting, JobPostingDto>(jobPostingToAdd);
        }

        public async Task Update(int id, UpdateJobPostingDto newJobPosting)
        {
            var validator = new UpdateJobPostingDtoValidation();
            var validationResult = await validator.ValidateAsync(newJobPosting);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var jobPostingToCheck = await _unitOfWork.JobPostings.GetByIdAsync(id);
            if (jobPostingToCheck is null)
            {
                throw ExceptionBuilder.Create("JobPosing with such Id does not exist");
            }

            var jobPosting = _mapper.Map<UpdateJobPostingDto, JobPosting>(newJobPosting);
            await _unitOfWork.JobPostings.Update(jobPosting, id);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var jobPosting = await _unitOfWork.JobPostings.GetByIdAsync(id);
            if (jobPosting is null)
            {
                throw ExceptionBuilder.Create("JobPosing with such Id does not exist");
            }

            await _unitOfWork.JobPostings.Delete(id);
            await _unitOfWork.SaveAsync();

        }
    }
}
