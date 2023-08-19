using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static ForAnimalsWithLove.Service.Tests.DatabaseSeeder;

namespace ForAnimalsWithLove.Service.Tests
{
	public class AdminServiceTests
	{
		private DbContextOptions<ForAnimalsWithLoveDbContext> optionsBuilder;
		private ForAnimalsWithLoveDbContext dbContext;
		private IAdminService adminService;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			optionsBuilder = new DbContextOptionsBuilder<ForAnimalsWithLoveDbContext>()
				.UseInMemoryDatabase("ForAnimalsWithLoveInMemory" + Guid.NewGuid().ToString())
				.Options;
			dbContext = new ForAnimalsWithLoveDbContext(this.optionsBuilder);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.adminService = new AdminService(this.dbContext);
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task AdminExistByUserIdAsyncShouldReturnTrueWhenExists()
		{
			
		}
	}
}