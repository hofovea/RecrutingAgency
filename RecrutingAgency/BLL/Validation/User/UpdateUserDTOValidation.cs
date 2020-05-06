using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO.Identity;
using FluentValidation;

namespace BLL.Validation.User
{
    public class UpdateUserDtoValidation : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidation()
        {
            RuleFor(user => user.Phone)
                .NotEmpty()
                .Matches("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}"); //phone check regex
            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(user => user.GitHub)
                .NotEmpty()
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$"); //link check regex
        }
    }
}
