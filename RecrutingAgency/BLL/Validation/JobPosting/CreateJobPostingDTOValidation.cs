using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO.JobPosting;
using FluentValidation;

namespace BLL.Validation.JobPosting
{
    class CreateJobPostingDtoValidation : AbstractValidator<CreateJobPostingDto>
    {
        public CreateJobPostingDtoValidation()
        {
            RuleFor(jobPosting => jobPosting.Description).NotEmpty().Length(10, 100);
            RuleFor(jobPosting => jobPosting.Payment).NotEmpty();
            RuleFor(jobPosting => jobPosting.Name).NotEmpty().Length(2, 20);
            RuleFor(jobPosting => jobPosting.EmployerId).NotEmpty();
        }
    }
}
