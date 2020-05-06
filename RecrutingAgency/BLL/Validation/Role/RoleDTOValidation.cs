using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using FluentValidation;

namespace BLL.Validation.Role
{
    class RoleDTOValidation : AbstractValidator<RoleDto>
    {
        public RoleDTOValidation()
        {
            RuleFor(role => role.Id).NotEmpty();
            RuleFor(role => role.Name).NotEmpty();
        }
    }
}
