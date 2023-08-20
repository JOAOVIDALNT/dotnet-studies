using Microsoft.AspNetCore.Identity;

namespace villa_app_api.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
