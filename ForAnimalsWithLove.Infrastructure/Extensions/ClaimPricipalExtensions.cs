using System.Security.Claims;

namespace ForAnimalsWithLove.Infrastructure.Extensions
{
    public static class ClaimPricipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
			return user.IsInRole("Administrator");
		}

		public static bool IsTrainer(this ClaimsPrincipal user)
		{
			return user.IsInRole("Trainer");
		}

		public static bool IsDoctor(this ClaimsPrincipal user)
		{
			return user.IsInRole("Doctor");
		}
	}
}
