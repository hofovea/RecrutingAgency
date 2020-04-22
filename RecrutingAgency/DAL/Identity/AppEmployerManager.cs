using System;
using System.Collections.Generic;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DAL.Identity
{
    class AppEmployerManager : UserManager<EmployerAppUser>
    {
        public AppEmployerManager(IUserStore<EmployerAppUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<EmployerAppUser> passwordHasher,
            IEnumerable<IUserValidator<EmployerAppUser>> userValidators,
            IEnumerable<IPasswordValidator<EmployerAppUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<EmployerAppUser>> logger) :
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
                services, logger)
        {
        }
    }
}
