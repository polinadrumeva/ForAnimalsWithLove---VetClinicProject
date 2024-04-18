using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;
using ForAnimalsWithLove.ViewModels.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
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
		public async Task GetHealthModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetHealthModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetHealthModelAsync_ReturnsInstanceOfAdminHealthModel()
		{
			var result = await adminService.GetHealthModelAsync();

			Assert.IsInstanceOf<AdminHealthModel>(result);
		}

		[Test]
		public async Task GetHealthModelAsync_ReturnsEmptyAdminHealthModel()
		{
			var result = await adminService.GetHealthModelAsync();

			Assert.IsFalse(result.FirstVaccine);
			Assert.IsFalse(result.Microchip);
		}

		[Test]
		public async Task GetGroomingModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetGroomingModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetGroomingModelAsync_ReturnsInstanceOfAdminGroomingModel()
		{
			var result = await adminService.GetGroomingModelAsync();

			Assert.IsInstanceOf<AdminGroomingModel>(result);
		}

		[Test]
		public async Task GetGroomingModelAsync_ReturnsEmptyAdminGroomingModel()
		{
			var result = await adminService.GetGroomingModelAsync();

			Assert.IsNull(result.Service);
		}


		[Test]
		public async Task AddGroomingAsync_ThrowsException_WhenAnimalIdNotFound()
		{
			var model = new AdminGroomingModel
			{
				Service = "Grooming Service",
				Date = DateTime.Now
			};
			var nonExistentAnimalId = "3FA15101-2A77-453B-9891-97301E778C37"; 

			Assert.ThrowsAsync<NullReferenceException>(() => adminService.AddGroomingAsync(model, nonExistentAnimalId));
		}

		[Test]
		public async Task EditGroomingAsync_DoesNotUpdateNonExistentGroomingRecord()
		{
			
			var nonExistentGroomingId = "3FA15101-2A77-453B-9891-97301E778C39"; // Provide a non-existent grooming ID
			var updatedModel = new AdminGroomingModel
			{
				Id = nonExistentGroomingId,
				Service = "Updated Grooming Service",
				Date = DateTime.Now.AddDays(1)
			};

			await adminService.EditGroomingAsync(updatedModel);

			var updatedGrooming = await dbContext.Groomings.FirstOrDefaultAsync(g => g.Id.ToString() == nonExistentGroomingId);
			Assert.IsNull(updatedGrooming);
		}

		[Test]
		public async Task GetEducationModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetEducationModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetEducationModelAsync_ReturnsInstanceOfAdminEducationModel()
		{
			var result = await adminService.GetEducationModelAsync();

			Assert.IsInstanceOf<AdminEducationModel>(result);
		}

		[Test]
		public async Task GetEducationModelAsync_ReturnsAdminEducationModelWithTrainers()
		{
			var result = await adminService.GetEducationModelAsync();

			Assert.IsNotNull(result.AdminTrainers);
			Assert.IsFalse(result.AdminTrainers.Any());
		}


		[Test]
		public async Task GetBookingModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetBookingModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetBookingModelAsync_ReturnsInstanceOfAdminBookingModel()
		{
			var result = await adminService.GetBookingModelAsync();

			Assert.IsInstanceOf<AdminBookingModel>(result);
		}

		[Test]
		public async Task GetBookingModelAsync_ReturnsAdminBookingModelWithHotels()
		{
			var result = await adminService.GetBookingModelAsync();

			Assert.IsNotNull(result.Hotels);
			Assert.IsTrue(result.Hotels.Any());
		}

		[Test]
		public async Task AddBookingAsync_AddsNewBooking()
		{
			var model = new AdminBookingModel
			{
				HotelId = 1, 
				StartDate = DateTime.Today,
				EndDate = DateTime.Today.AddDays(1),
				Days = 2
			};
			var animalId = "3FA15101-2A77-453B-9891-97301E778C39"; 

			await adminService.AddBookingAsync(model, animalId);

			var bookingRecord = await dbContext.Bookings.FirstOrDefaultAsync(b => b.HotelId == model.HotelId && b.StartDate == model.StartDate && b.EndDate == model.EndDate && b.Days == model.Days);
			Assert.IsNotNull(bookingRecord);
		}


		[Test]
		public async Task AddBookingAsync_DoesNotAddBooking_WhenModelIsNull()
		{
			Assert.ThrowsAsync<NullReferenceException>(() => adminService.AddBookingAsync(null, "3FA15101-2A77-453B-9891-97301E778C39"));
		}

		[Test]
		public async Task GetSearchHomeModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetSearchHomeModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetSearchHomeModelAsync_ReturnsInstanceOfAdminSearchHomeModel()
		{
			var result = await adminService.GetSearchHomeModelAsync();

			Assert.IsInstanceOf<AdminSearchHomeModel>(result);
		}

		[Test]
		public async Task GetSearchHomeModelAsync_ReturnsEmptyModel()
		{
			var result = await adminService.GetSearchHomeModelAsync();

			Assert.IsNull(result.Habits);
			Assert.IsNull(result.Location);
		}


		[Test]
		public async Task AddSearchHomeAsync_DoesNotAddSearchHome_WhenModelIsNull()
		{
			
			Assert.ThrowsAsync<NullReferenceException>(() => adminService.AddSearchHomeAsync(null, "3FA15101-2A77-453B-9891-97301E778C39"));
		}

		[Test]
		public async Task GetOwnerModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetOwnerModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetOwnerModelAsync_ReturnsInstanceOfAdminOwnerModel()
		{
			var result = await adminService.GetOwnerModelAsync();

			Assert.IsInstanceOf<AdminOwnerModel>(result);
		}

		[Test]
		public async Task GetOwnerModelAsync_ReturnsEmptyModel()
		{
			var result = await adminService.GetOwnerModelAsync();

			Assert.IsNull(result.FirstName);
			Assert.IsNull(result.LastName);
		}

		[Test]
		public async Task AddOwnerAsync_AddsNewOwner()
		{
			var model = new AdminOwnerModel
			{
				FirstName = "John",
				LastName = "Doe",
				PhoneNumber = "1234567890",
				Address = "123 Main St"
			};
			var animalId = "7a090717-e16a-45e7-9d46-bd804ec499b5"; 

			await adminService.AddOwnerAsync(model, animalId);

			var addedOwner = await dbContext.Owners.FirstOrDefaultAsync(o => o.FirstName == model.FirstName && o.LastName == model.LastName);
			Assert.IsNotNull(addedOwner);
		}

		[Test]
		public async Task AddOwnerAsync_AssignsOwnerToAnimal()
		{
			var model = new AdminOwnerModel
			{
				FirstName = "John",
				LastName = "Doe",
				PhoneNumber = "1234567890",
				Address = "123 Main St"
			};
			var animalId = "7a090717-e16a-45e7-9d46-bd804ec499b5"; 

			await adminService.AddOwnerAsync(model, animalId);

			var animal = await dbContext.Animals.FirstOrDefaultAsync(a => a.Id.ToString() == animalId);
			Assert.IsNotNull(animal);
			Assert.AreEqual(model.FirstName, animal.Owner.FirstName);
			Assert.AreEqual(model.LastName, animal.Owner.LastName);
		}

		[Test]
		public async Task AddOwnerAsync_DoesNotAddOwner_WhenModelIsNull()
		{
			Assert.ThrowsAsync<NullReferenceException>(() => adminService.AddOwnerAsync(null, "7a090717-e16a-45e7-9d46-bd804ec499b5"));

		}

		[Test]
		public async Task GetGroomingDetailsAsync_ReturnsNotNull_WhenGroomingExists()
		{
			var existingAnimalId = "3fa15101-2a77-453b-9891-97301e778c39"; 
			var result = await adminService.GetGroomingDetailsAsync(existingAnimalId);

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetGroomingDetailsAsync_ReturnsNull_WhenNoGroomingExists()
		{
			var nonExistingAnimalId = "3fa15101-2a77-453b-9891-97301e778c38"; 
			var result = await adminService.GetGroomingDetailsAsync(nonExistingAnimalId);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetGroomingDetailsAsync_ReturnsCorrectGroomingModel_WhenGroomingExists()
		{
			
			var existingAnimalId = "3fa15101-2a77-453b-9891-97301e778c39"; 
			var result = await adminService.GetGroomingDetailsAsync(existingAnimalId);

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetHealthRecordDetailsAsync_ReturnsNotNull_WhenHealthRecordExists()
		{
			var existingAnimalId = "3fa15101-2a77-453b-9891-97301e778c39"; 
			var result = await adminService.GetHealthRecordDetailsAsync(existingAnimalId);

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetHealthRecordDetailsAsync_ReturnsCorrectModel_WhenHealthRecordExists()
		{
			var existingAnimalId = "3fa15101-2a77-453b-9891-97301e778c39"; 
			var result = await adminService.GetHealthRecordDetailsAsync(existingAnimalId);

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetHospitalModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetHospitalModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetHospitalModelAsync_ReturnsInstanceOfAdminHospitalModel()
		{
			var result = await adminService.GetHospitalModelAsync();

			Assert.IsInstanceOf<AdminHospitalModel>(result);
		}

		[Test]
		public async Task GetHospitalModelAsync_ReturnsEmptyAdminHospitalModel()
		{
			var result = await adminService.GetHospitalModelAsync();

			Assert.AreEqual(default(string), result.Diagnosis);
		}

		[Test]
		public async Task GetMedicalModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetMedicalModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetMedicalModelAsync_ReturnsInstanceOfAdminMedicalModel()
		{
			var result = await adminService.GetMedicalModelAsync();

			Assert.IsInstanceOf<AdminMedicalModel>(result);
		}

		[Test]
		public async Task GetMedicalModelAsync_ReturnsCorrectDoctorModels()
		{
			var result = await adminService.GetMedicalModelAsync();

			Assert.IsNotNull(result.Doctors);
		}


		//Tests for Doctors part
		[Test]
		public async Task GetAllDoctors_ReturnsNotEmptyCollection()
		{
			var result = await adminService.GetAllDoctors();

			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);
		}

		[Test]
		public async Task GetAllDoctors_ReturnsCorrectIndexDoctorModels()
		{
			var result = await adminService.GetAllDoctors();

			Assert.IsNotNull(result);
			foreach (var doctor in result)
			{
				Assert.IsNotNull(doctor.Id);
				Assert.IsNotNull(doctor.FirstName);
				Assert.IsNotNull(doctor.LastName);
				Assert.IsNotNull(doctor.ImageUrl);
				Assert.IsNotNull(doctor.PhoneNumber);
			}
		}

		[Test]
		public async Task GetAllDoctors_ReturnsCorrectNumberOfDoctors()
		{
			var expectedCount = 1; 

			var result = await adminService.GetAllDoctors();

			Assert.IsNotNull(result);
			Assert.AreEqual(expectedCount, result.Count());
		}

		[Test]
		public async Task GetAllDoctorsFiltredServiceModelAsync_ReturnsNotNull()
		{
			var queryModel = new AllDoctorsQueryModel
			{
				Direction = "SomeDirection",
				SearchString = "SomeSearchString",
				CurrentPage = 1,
				DoctorsPerPage = 10
			};

			var result = await adminService.GetAllDoctorsFiltredServiceModelAsync(queryModel);

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetAllDoctorsFiltredServiceModelAsync_ReturnsCorrectTotalDoctorsCount()
		{
			var queryModel = new AllDoctorsQueryModel
			{
				Direction = "SomeDirection",
				SearchString = "SomeSearchString",
				CurrentPage = 1,
				DoctorsPerPage = 10
			};
			var expectedTotalCount = 0; 

			var result = await adminService.GetAllDoctorsFiltredServiceModelAsync(queryModel);

			Assert.AreEqual(expectedTotalCount, result.TotalDoctorsCount);
		}


		[Test]
		public async Task AllDirectionsNamesAsync_ReturnsNotNull()
		{
			var result = await adminService.AllDirectionsNamesAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task AllDirectionsNamesAsync_ReturnsNotEmptyCollection()
		{
			var result = await adminService.AllDirectionsNamesAsync();

			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);
		}

		[Test]
		public async Task AllDirectionsNamesAsync_ReturnsCorrectNames()
		{
			var expectedNames = new string[] { "Хирургия" }; 
			var result = await adminService.AllDirectionsNamesAsync();

			CollectionAssert.AreEquivalent(expectedNames, result);
		}

		[Test]
		public async Task GetDoctorModelAsync_ReturnsNotNull()
		{
			var result = await adminService.GetDoctorModelAsync();

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task GetDoctorModelAsync_ReturnsValidDirectories()
		{
			var result = await adminService.GetDoctorModelAsync();

			Assert.IsNotNull(result.Directories);
			Assert.IsNotEmpty(result.Directories);
		}

		[Test]
		public async Task GetDoctorModelAsync_ReturnsCorrectNumberOfDirectories()
		{
			var expectedCount = 1; 
			var result = await adminService.GetDoctorModelAsync();

			Assert.AreEqual(expectedCount, result.Directories.Count);
		}

	}
}