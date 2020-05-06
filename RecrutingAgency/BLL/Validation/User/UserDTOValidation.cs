using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using BLL.DTO.Identity;
using FluentValidation;

namespace BLL.Validation.User
{
    public class UserDtoValidation : AbstractValidator<UserDto>
    {
        public UserDtoValidation()
        {
            RuleFor(user => user.Id)
                .NotEmpty();
            RuleFor(user => user.FullName)
                .NotEmpty()
                .Length(4, 20);
            RuleFor(user => user.Phone)
                .NotEmpty()
                .Matches("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}"); //phone check regex
            RuleFor(user => user.Age)
                .NotEmpty();
            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(user => user.GitHub)
                .NotEmpty()
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$"); //link check regex

            RuleFor(user => user.Roles)
                .InjectValidator()
                .When(user => user.Roles != null);
            RuleFor(user => user.JobPostings)
                .InjectValidator()
                .When(user => user.JobPostings != null);
            RuleFor(user => user.Recruits)
                .InjectValidator()
                .When(user => user.Recruits != null);
        }
    }
}
