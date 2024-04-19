using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

using static ForAnimalsWithLove.Service.Tests.DatabaseSeeder;

namespace ForAnimalsWithLove.Service.Tests
{
	public class DoctorServiceTests
	{

		private DbContextOptions<ForAnimalsWithLoveDbContext> optionsBuilder;
		private ForAnimalsWithLoveDbContext dbContext;
		private ITrainerService trainerService;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			this.optionsBuilder = new DbContextOptionsBuilder<ForAnimalsWithLoveDbContext>()
				.UseInMemoryDatabase("ForAnimalsWithLoveInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new ForAnimalsWithLoveDbContext(this.optionsBuilder);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.trainerService = new TrainerService(this.dbContext);
		}

		[SetUp]
		public void Setup()
		{
		}
	}
}
