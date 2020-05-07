using BLL.DTO.JobPosting;
using FluentValidation;

namespace BLL.Validation.JobPosting
{
    class UpdateJobPostingDtoValidation : AbstractValidator<UpdateJobPostingDto>
    {
        public UpdateJobPostingDtoValidation()
        {
            RuleFor(jobPosting => jobPosting.Description).NotEmpty().Length(10, 100);
            RuleFor(jobPosting => jobPosting.Payment).NotEmpty();
            RuleFor(jobPosting => jobPosting.Name).NotEmpty().Length(2, 20);
        }
    }
}