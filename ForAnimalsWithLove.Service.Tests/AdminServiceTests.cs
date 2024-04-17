using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;
using ForAnimalsWithLove.ViewModels.Enums;
using Microsoft.EntityFrameworkCore;
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
			this.optionsBuilder = new DbContextOptionsBuilder<ForAnimalsWithLoveDbContext>()
				.UseInMemoryDatabase("ForAnimalsWithLoveInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new ForAnimalsWithLoveDbContext(this.optionsBuilder);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.adminService = new AdminService(this.dbContext);
		}

		[SetUp]
		public void Setup()
		{
		}


		[Test]
		public void AdminExistsByUserIdAsync_ReturnTrue_WhenExist()
		{ 
			var existAdmin = AdminUser.Id.ToString();
			var result = this.adminService.AdminExistByUserIdAsync(existAdmin);
			Assert.IsTrue(result.Result);
		}

		[Test]
		public void AdminExistsByUserIdAsync_ReturnFalse_WhenNotExist()
		{
			var notExistAdmin = OwnerUser.Id.ToString();
			var result = this.adminService.AdminExistByUserIdAsync(notExistAdmin);
			Assert.IsFalse(result.Result);
		}

		[Test]
		public async Task GetAdminExistByUserIdAsync_ReturnsAdminIndexModel_WhenAdminExists()
		{
			var adminId = AdminUser.Id.ToString();
			var result = await this.adminService.GetAdminExistByUserIdAsync(adminId);

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetAdminExistByUserIdAsync_ReturnsNull_WhenAdminDoesNotExist()
		{
			var nonExistentAdminId = Guid.NewGuid().ToString(); 
			var result = await this.adminService.GetAdminExistByUserIdAsync(nonExistentAdminId);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetAllAnimals_ReturnsNotEmptyCollection()
		{
			var result = await this.adminService.GetAllAnimals();

			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);
		}

		[Test]
		public async Task GetAllAnimals_ReturnsCorrectAnimalModelProperties()
		{
			var result = await this.adminService.GetAllAnimals();

			foreach (var animal in result)
			{
				Assert.IsNotNull(animal.Id);
				Assert.IsNotNull(animal.Name);
				Assert.IsNotNull(animal.Age);
				Assert.IsNotNull(animal.KindOfAnimal);
				Assert.IsNotNull(animal.Breed);
				Assert.IsNotNull(animal.Color);
				Assert.IsNotNull(animal.Birthdate);
				Assert.IsNotNull(animal.Sex);
				Assert.IsNotNull(animal.DoesHasOwner);
				Assert.IsNotNull(animal.OwnerId);
				Assert.IsNotNull(animal.Owner);
			}
		}

		[Test]
		public async Task AllAnimalsAsync_ReturnsCorrectTotalAnimalsCount()
		{
			var queryModel = new AllAnimalsQueryModel
			{
				SearchString = "searchString",
				AnimalSorting = AnimalSorting.Name,
				CurrentPage = 1,
				AnimalsPerPage = 10
			};

			var result = await this.adminService.AllAnimalsAsync(queryModel);

			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.TotalAnimalsCount);
		}

		[Test]
		public async Task AllAnimalsAsync_ReturnsCorrectAnimalsPerPage()
		{
			var queryModel = new AllAnimalsQueryModel
			{
				SearchString = "searchString",
				AnimalSorting = AnimalSorting.Name,
				CurrentPage = 1,
				AnimalsPerPage = 10
			};

			var result = await this.adminService.AllAnimalsAsync(queryModel);

			Assert.IsNotNull(result);
			Assert.AreEqual(queryModel.AnimalsPerPage, 10);
		}

		[Test]
		public async Task GetAnimalByIdAsync_ReturnsNull_WhenAnimalNotFound()
		{
			var nonExistentAnimalId = Guid.NewGuid().ToString(); 

			var result = await this.adminService.GetAnimalByIdAsync(nonExistentAnimalId);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetAnimalByIdAsync_ReturnsAdminAnimalModel_WhenAnimalFound()
		{
			var existingAnimalId = Animal.Id.ToString(); 

			var result = await this.adminService.GetAnimalByIdAsync(existingAnimalId);

			Assert.IsNotNull(result);
			Assert.IsInstanceOf<AdminAnimalModel>(result);
			Assert.AreEqual(Animal.Name, result.Name);
		}

		[Test]
		public async Task GetAnimalByIdAsync_ReturnsCorrectProperties_WhenAnimalFound()
		{
			var existingAnimalId = Animal.Id.ToString(); 
			var result = await this.adminService.GetAnimalByIdAsync(existingAnimalId);

			Assert.IsNotNull(result);
			Assert.AreEqual(Animal.Name, result.Name);
			Assert.AreEqual(Animal.Age, result.Age);
			Assert.AreEqual(Animal.Photo, result.Photo);
			Assert.AreEqual(Animal.KindOfAnimal, result.KindOfAnimal);
			Assert.AreEqual(Animal.Breed, result.Breed);
			Assert.AreEqual(Animal.Color, result.Color);
			Assert.AreEqual(Animal.Birthdate, result.Birthdate);
			Assert.AreEqual(Animal.Sex.ToString(), result.Sex);
			Assert.AreEqual(Animal.DoesHasOwner, result.DoesHasOwner);
		}

		[Test]
		public async Task GetAnimalModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetAnimalModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetAnimalModelAsync_ReturnsInstanceOfAdminAnimalModel()
		{
			var result = await adminService.GetAnimalModelAsync();

			Assert.IsInstanceOf<AdminAnimalModel>(result);
		}

		[Test]
		public async Task GetAnimalModelAsync_ReturnsEmptyAdminAnimalModel()
		{
			var result = await adminService.GetAnimalModelAsync();

			Assert.IsNull(result.Name);
			Assert.AreEqual(0, result.Age);
		}

		[Test]
		public async Task EditAnimalAsync_UpdatesExistingAnimal_WhenAnimalExists()
		{
			var existingAnimalId = Animal.Id.ToString(); 
			var updatedName = "UpdatedName";

			await this.adminService.EditAnimalAsync(new AdminAnimalModel
			{
				Id = existingAnimalId,
				Name = updatedName,
				Age = Animal.Age,
				Photo = Animal.Photo,
				KindOfAnimal = Animal.KindOfAnimal,
				Breed = Animal.Breed,
				Color = Animal.Color,
				Birthdate = Animal.Birthdate,
				Sex = Animal.Sex.ToString(),
				DoesHasOwner = Animal.DoesHasOwner

			});

			var updatedAnimal = await this.dbContext.Animals.FindAsync(Guid.Parse(existingAnimalId));
			Assert.IsNotNull(updatedAnimal);
			Assert.AreEqual(updatedName, updatedAnimal.Name);
		}

		[Test]
		public async Task EditAnimalAsync_DoesNotUpdateAnimal_WhenAnimalDoesNotExist()
		{
			var nonExistentAnimalId = Guid.NewGuid().ToString(); 
			var updatedName = "UpdatedName";

			await this.adminService.EditAnimalAsync(new AdminAnimalModel
			{
				Id = nonExistentAnimalId,
				Name = updatedName
			});

			var updatedAnimal = await this.dbContext.Animals.FindAsync(Guid.Parse(nonExistentAnimalId));
			Assert.IsNull(updatedAnimal);
		}

		[Test]
		public async Task AddAnimalAsync_AddsNewAnimal_WhenModelIsValid()
		{
			var newAnimalModel = new AdminAnimalModel
			{
				Id = Guid.NewGuid().ToString(),
				Name = "NewAnimal",
				Age = 5,
				KindOfAnimal = "Котка",
				Breed = "Порода",
				Color = "Цвят",
				Sex = 'M'.ToString(),
				Birthdate = DateTime.UtcNow,
				DoesHasOwner = false,
			};

			await this.adminService.AddAnimalAsync(newAnimalModel);

			var addedAnimal = await this.dbContext.Animals.FindAsync(Guid.Parse(newAnimalModel.Id));
			Assert.IsNotNull(addedAnimal);
		}

		[Test]
		public async Task AddAnimalAsync_DoesNotAddAnimal_WhenModelIsNull()
		{
			await this.adminService.AddAnimalAsync(null);

			var allAnimalsCount = await this.dbContext.Animals.CountAsync();
			Assert.AreEqual(0, allAnimalsCount);
		}

		[Test]
		public async Task AddAnimalAsync_DoesNotAddAnimal_WhenModelIdExists()
		{
			var existingAnimalId = Animal.Id.ToString(); 

			await this.adminService.AddAnimalAsync(new AdminAnimalModel
			{
				Id = existingAnimalId,
				Name = "NewAnimal",
				Age = 5,
				KindOfAnimal = "Котка",
				Breed = "Порода",
				Color = "Цвят",
				Sex = 'M'.ToString(),
				Birthdate = DateTime.UtcNow,
				DoesHasOwner = false
			});

			var allAnimalsCount = await this.dbContext.Animals.CountAsync();
			Assert.AreEqual(1, allAnimalsCount);
		}
	}
}