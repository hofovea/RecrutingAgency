using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Identity;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RecruitingAgency.Policies
{
    public class DeleteJobHandler : AuthorizationHandler<DeleteJobPostingRequirement, int>
    {
        private readonly IJobPostingService _jobPostingService;
        private readonly RecrutingAgencyUserManager _userManager;
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DeleteJobPostingRequirement requirement, int jobToDeleteId)
        {
            if (context.User.IsInRole("Admins"))
            {
                context.Succeed(requirement);
                return;
            }

            var jobToDelete = await _jobPostingService.GetById(jobToDeleteId);
            var owner = await _userManager.FindByIdAsync(jobToDelete.EmployerId);
            var jobsCount = owner.JobPostings.Count(j => j.Id == jobToDeleteId);
            if (jobsCount > 0)
            {
                context.Succeed(requirement);
            }
        }
    }
}

public class DeleteJobPostingRequirement : IAuthorizationRequirement { }