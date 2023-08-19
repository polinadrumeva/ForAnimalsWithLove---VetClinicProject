using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Data.Models;
using NUnit.Framework.Internal.Execution;

namespace ForAnimalsWithLove.Service.Tests
{
	public class DatabaseSeeder
	{
		public static ApplicationUser AdminUser;
		public static ApplicationUser OwnerUser;
		public static Administrator Administrator;

		public static void SeedDatabase(ForAnimalsWithLoveDbContext dbContext)
		{
			AdminUser = new ApplicationUser()
			{
				UserName = "doneva@foranimalswithlove.bg",
				NormalizedUserName = "DONEVA@FORANIMALSWITHLOVE.BG",
				Email = "doneva@foranimalswithlove.bg",
				NormalizedEmail = "DONEVA@FORANIMALSWITHLOVE.BG",
				EmailConfirmed = false,
				PasswordHash = "AQAAAAEAACcQAAAAEMH3yUfPhQ8RB1qX+DJwXQKPRCxLLwpbUIOT1g+/zZK3OOMMwqX7VsN0RFRB6Ed+dg==",
				ConcurrencyStamp = "c7ea46c7-1007-4c36-8e54-e45e00cd5dce",
				SecurityStamp = "25IO6SPZRST5MQARVFJTDDZWOKRMG7FG",
				TwoFactorEnabled = false
			};
			OwnerUser = new ApplicationUser()
			{
				UserName = "creator@softuni.bg",
				NormalizedUserName = "CREATOR@SOFTUNI.BG",
				Email = "creator@softuni.bg",
				NormalizedEmail = "CREATOR@SOFTUNI.BG",
				EmailConfirmed = false,
				PasswordHash = "AQAAAAEAACcQAAAAEAQaPg7NZbeXCRB+T8sZ9vvV5EG6gyOsdRJhryLKf4aVt7saTmsEdl/ZrchXTgDDeg==",
				ConcurrencyStamp = "6fd79cd5-1103-4a35-b86a-4f4885c722a2",
				SecurityStamp = "XWMRYEHMONJLBYXMYQHZBEFJEVFQ6Y67",
				TwoFactorEnabled = false
			};
			Administrator = new Administrator()
			{
				PhoneNumber = "0887328173",
				User = AdminUser
			};

			dbContext.Users.Add(AdminUser);
			dbContext.Users.Add(OwnerUser);
			dbContext.Administrators.Add(Administrator);

			dbContext.SaveChanges();
		}
	}
}

