using Microsoft.AspNetCore.Identity;


namespace ForAnimalsWithLove.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
