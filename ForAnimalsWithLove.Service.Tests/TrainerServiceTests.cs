using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using static ForAnimalsWithLove.Service.Tests.DatabaseSeeder;
using System.Threading.Tasks;
using ForAnimalsWithLove.ViewModels.Admins;

namespace ForAnimalsWithLove.Service.Tests
{
	public class TrainerServiceTests
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

		[Test]
		public async Task TrainerExistByUserIdAsync_WithValidUserId_ReturnsTrue()
		{
			var userId = "e4eb79d7-bcf1-4bce-be35-259351ee6f88"; 
			var result = await trainerService.TrainerExistByUserIdAsync(userId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task TrainerExistByUserIdAsync_WithInvalidUserId_ReturnsFalse()
		{
			var userId = "E4EB79D7-BCF1-4BCE-BE35-259351EE6F80"; 
			var result = await trainerService.TrainerExistByUserIdAsync(userId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetTrainerExistByUserIdAsync_WithValidUserId_ReturnsTrainer()
		{
			var userId = "e4eb79d7-bcf1-4bce-be35-259351ee6f88"; 
			var result = await trainerService.GetTrainerExistByUserIdAsync(userId);

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetTrainerExistByUserIdAsync_WithInvalidUserId_ReturnsNull()
		{
			var userId = "E4EB79D7-BCF1-4BCE-BE35-259351EE6F80"; 
			var result = await trainerService.GetTrainerExistByUserIdAsync(userId);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetEducationModelAsync_ReturnsEducationModelWithTrainers()
		{
			var result = await trainerService.GetEducationModelAsync();

			// Assert
			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result.AdminTrainers);
		}

		[Test]
		public async Task AddEducationAsync_AddsEducationAndAnimalEducationToDatabase()
		{
			var trainerId = Guid.NewGuid().ToString();
			var animalId = Guid.NewGuid().ToString();
			var model = new AdminEducationModel
			{
				TrainerId = trainerId,
				Days = 5
			};

			await trainerService.AddEducationAsync(model, animalId);

			var education = dbContext.Educations.FirstOrDefaultAsync(e => e.TrainerId.ToString() == trainerId);
			var animalEducation = dbContext.AnimalsEducations.FirstOrDefaultAsync(ae => ae.AnimalId.ToString() == animalId);

			Assert.IsNotNull(education);
			Assert.IsNotNull(animalEducation);
		}

		
	}
}
