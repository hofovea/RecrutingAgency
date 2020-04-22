using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class EmploeeAppUser : IdentityUser
    {
        public virtual Emploee Emploee { get; set; }
        public string EmploeeId { get; set; }
    }
}