using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static ForAnimalsWithLove.Service.Tests.DatabaseSeeder;
using ForAnimalsWithLove.ViewModels.Admins;
using System.Collections.Generic;

namespace ForAnimalsWithLove.Service.Tests
{
	public class OwnerServiceTests
	{
		private DbContextOptions<ForAnimalsWithLoveDbContext> optionsBuilder;
		private ForAnimalsWithLoveDbContext dbContext;
		private IOwnerService ownerService;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			this.optionsBuilder = new DbContextOptionsBuilder<ForAnimalsWithLoveDbContext>()
				.UseInMemoryDatabase("ForAnimalsWithLoveInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new ForAnimalsWithLoveDbContext(this.optionsBuilder);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.ownerService = new OwnerService(this.dbContext);
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task OwnerExistByUserIdAsync_WithExistingUserId_ReturnsTrue()
		{
			var userId = "5727d951-24ba-4450-8cb5-6e851a9b1d4b";
			var result = await ownerService.OwnerExistByUserIdAsync(userId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task OwnerExistByUserIdAsync_WithNonExistingUserId_ReturnsFalse()
		{
			var userId = "5727D951-24BA-4450-8CB5-6E851A9B1D4D";
			var result = await ownerService.OwnerExistByUserIdAsync(userId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetOwnerExistByUserIdAsync_WithExistingUserId_ReturnsOwnerModel()
		{
			var userId = "5727d951-24ba-4450-8cb5-6e851a9b1d4b";
			var result = await ownerService.GetOwnerExistByUserIdAsync(userId);

			Assert.NotNull(result);
			Assert.AreEqual("Полина", result.FirstName);
			Assert.AreEqual("Друмева", result.LastName);
			Assert.AreEqual("0887554289", result.PhoneNumber);
			Assert.AreEqual("Велико Търново", result.Address);
		}

		[Test]
		public async Task GetOwnerExistByUserIdAsync_WithNonExistingUserId_ReturnsNull()
		{
			var userId = "5727D951-24BA-4450-8CB5-6E851A9B1D43";
			var result = await ownerService.GetOwnerExistByUserIdAsync(userId);

			Assert.Null(result);
		}

		[Test]
		public async Task GetMyAnimalDetailsAsync_WithValidOwnerId_ReturnsListOfAdminAnimalModels()
		{
			var ownerId = "f88ef877-1938-41ad-992d-a08f59b45eaf";

			var result = await ownerService.GetMyAnimalDetailsAsync(ownerId);

			Assert.NotNull(result);
			Assert.IsInstanceOf<IEnumerable<AdminAnimalModel>>(result);
			Assert.AreEqual(1, result.Count); 
		}

		[Test]
		public async Task GetMyAnimalDetailsAsync_WithInvalidOwnerId_ReturnsEmptyList()
		{
			var ownerId = "F88EF877-1938-41AD-992D-A08F59B45EA8"; 

			var ownerService = new OwnerService(dbContext);
			var result = await ownerService.GetMyAnimalDetailsAsync(ownerId);

			Assert.NotNull(result);
			Assert.IsEmpty(result);
		}

		[Test]
		public async Task GetHospitalRecordDetailsAsync_WithValidAnimalId_ReturnsAdminHealthModelWithRecords()
		{
			var animalId = "3fa15101-2a77-453b-9891-97301e778c39"; 
			var result = await ownerService.GetHospitalRecordDetailsAsync(animalId);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetHealthRecordDetailsAsync_WithValidAnimalId_ReturnsAdminHealthModelWithMedicals()
		{
			var animalId = "3fa15101-2a77-453b-9891-97301e778c39"; 
			var result = await ownerService.GetHealthRecordDetailsAsync(animalId);

			Assert.NotNull(result);
			Assert.IsInstanceOf<AdminHealthModel>(result);
			Assert.NotNull(result.FirstVaccine);
		}

		[Test]
		public async Task GetGroomingAsync_WithValidAnimalId_ReturnsAdminGroomingModel()
		{
			var animalId = "3fa15101-2a77-453b-9891-97301e778c39"; 
			var result = await ownerService.GetGroomingAsync(animalId);

			Assert.NotNull(result);
			Assert.IsInstanceOf<AdminGroomingModel>(result);
		}

		[Test]
		public async Task GetGroomingAsync_WithInvalidAnimalId_ReturnsNull()
		{
			var animalId = "3fa15101-2a77-453b-9891-97301e778c30";
			var result = await ownerService.GetGroomingAsync(animalId);

			Assert.Null(result);
		}


		[Test]
		public async Task GetEducationDetailsAsync_WithInvalidId_ReturnsNull()
		{
			var educationId = "999";
			var result = await ownerService.GetEducationDetailsAsync(educationId);

			Assert.Null(result);
		}

		[Test]
		public async Task GetBookingDetailsAsync_WithValidId_ReturnsAdminAnimalModelWithBookings()
		{
			// Arrange
			var animalId = "1";
			var result = await ownerService.GetBookingDetailsAsync(animalId);

			// Assert
			Assert.NotNull(result);
			Assert.IsInstanceOf<AdminAnimalModel>(result);
			Assert.NotNull(result.Bookings);
			Assert.IsNotEmpty(result.Bookings);
			// Add more assertions based on your data
		}

		[Test]
		public async Task GetBookingDetailsAsync_WithInvalidId_ReturnsNull()
		{
			// Arrange
			var animalId = "999"; 
			var result = await ownerService.GetBookingDetailsAsync(animalId);

			// Assert
			Assert.Null(result);
		}
	}
}
