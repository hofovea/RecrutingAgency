using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO.JobPosting;
using FluentValidation;

namespace BLL.Validation.JobPosting
{
    class CreateUpdateJobPostingDtoValidation : AbstractValidator<CreateUpdateJobPosingDto>
    {
        public CreateUpdateJobPostingDtoValidation()
        {
            RuleFor(jobPosting => jobPosting.Description).NotEmpty().Length(10, 100);
            RuleFor(jobPosting => jobPosting.Payment).NotEmpty();
            RuleFor(jobPosting => jobPosting.Name).NotEmpty().Length(2, 20);
        }
    }
}
