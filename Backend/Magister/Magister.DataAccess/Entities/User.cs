using Microsoft.AspNetCore.Identity;

namespace Magister.DataAccess.Entities
{
    public class User : IdentityUser<Guid>
    {
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }

    }
}
