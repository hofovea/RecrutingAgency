using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class EmployerAppUser : IdentityUser
    {
        public virtual Employer Employer { get; set; }
        public string EmployerId { get; set; }
    }
}