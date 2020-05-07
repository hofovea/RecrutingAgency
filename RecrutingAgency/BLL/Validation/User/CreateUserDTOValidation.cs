using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BLL.DTO.Identity;
using FluentValidation;

namespace BLL.Validation.User
{
    public class CreateUserDtoValidation : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidation()
        {
            RuleFor(user => user.FullName).NotEmpty().Length(4, 20);
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
        }
    }
}
