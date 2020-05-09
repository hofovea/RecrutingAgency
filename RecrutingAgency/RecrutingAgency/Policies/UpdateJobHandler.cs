using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO.JobPosting;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.Identity;

namespace RecruitingAgency.Policies
{
    public class UpdateJobHandler : AuthorizationHandler<UpdateJobPostingRequirement, int>
    {
        private readonly IJobPostingService _jobPostingService;
        private readonly RecrutingAgencyUserManager _userManager;

        public UpdateJobHandler(IJobPostingService jobPostingService, RecrutingAgencyUserManager userManager)
        {
            _jobPostingService = jobPostingService;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UpdateJobPostingRequirement requirement, int jobToUpdateId)
        {
            var jobToUpdate = await _jobPostingService.GetById(jobToUpdateId);
            var owner = await _userManager.FindByIdAsync(jobToUpdate.EmployerId);
            var jobsCount = owner.JobPostings.Count(j => j.Id == jobToUpdateId);
            if (jobsCount > 0)
            {
                context.Succeed(requirement);
            }
        }
    }
}

public class UpdateJobPostingRequirement : IAuthorizationRequirement { }