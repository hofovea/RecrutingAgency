using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DAL.Identity
{
    class AppEmploeeManager : UserManager<EmploeeAppUser>
    {
        public AppEmploeeManager(IUserStore<EmploeeAppUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<EmploeeAppUser> passwordHasher, IEnumerable<IUserValidator<EmploeeAppUser>> userValidators,
            IEnumerable<IPasswordValidator<EmploeeAppUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<EmploeeAppUser>> logger) :
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
                services, logger)
        {
        }
    }
}
