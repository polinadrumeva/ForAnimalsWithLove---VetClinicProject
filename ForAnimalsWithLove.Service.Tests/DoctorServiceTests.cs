using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

using static ForAnimalsWithLove.Service.Tests.DatabaseSeeder;
using System.Threading.Tasks;
using ForAnimalsWithLove.ViewModels.Admins;
using System.Collections.Generic;
using ForAnimalsWithLove.ViewModels.Animals;

namespace ForAnimalsWithLove.Service.Tests
{
	public class DoctorServiceTests
	{

		private DbContextOptions<ForAnimalsWithLoveDbContext> optionsBuilder;
		private ForAnimalsWithLoveDbContext dbContext;
		private IDoctorService doctorService;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			this.optionsBuilder = new DbContextOptionsBuilder<ForAnimalsWithLoveDbContext>()
				.UseInMemoryDatabase("ForAnimalsWithLoveInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new ForAnimalsWithLoveDbContext(this.optionsBuilder);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.doctorService = new DoctorService(this.dbContext);
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task DoctorExistByUserIdAsync_ExistingUserId_ReturnsTrue()
		{
			var existingUserId = "f5218d46-e826-44f3-b63e-f5ddabc63806"; 
			var expectedResult = true;
			var result = await doctorService.DoctorExistByUserIdAsync(existingUserId);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public async Task DoctorExistByUserIdAsync_NonExistingUserId_ReturnsFalse()
		{
			var nonExistingUserId = "f5218d46-e826-44f3-b63e-f5ddabc63800"; 
			var expectedResult = false;
			var result = await doctorService.DoctorExistByUserIdAsync(nonExistingUserId);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public async Task GetDoctorExistByUserIdAsync_ExistingUserId_ReturnsIndexDoctorModel()
		{
			var userId = "a6acfe86-1725-4acc-a49a-36eedb304176"; 
			var expectedId = "f5218d46-e826-44f3-b63e-f5ddabc63810";
			var expectedFirstName = "Димитър"; 
			var doctor = new Doctor
			{
				Id = Guid.Parse(expectedId),
				UserId = Guid.Parse(userId), 
				FirstName = expectedFirstName,
				LastName = "Петров",
				PhoneNumber = "0888888888",
				Photo = "https://www.google.com",
				Address = "ул. Витоша 10"
			};
			dbContext.Doctors.Add(doctor);
			await dbContext.SaveChangesAsync();

			var result = await doctorService.GetDoctorExistByUserIdAsync(userId);

			Assert.IsNotNull(result);
			Assert.AreEqual(expectedId, result.Id);
			Assert.AreEqual(expectedFirstName, result.FirstName);
		}

		[Test]
		public async Task GetDoctorExistByUserIdAsync_NonExistingUserId_ReturnsNull()
		{
			var userId = "f5218d46-e826-44f3-b63e-f5ddabc63809"; 
			var result = await doctorService.GetDoctorExistByUserIdAsync(userId);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetDoctorExistByUserIdAsync_NullUserId_ReturnsNull()
		{
			string userId = null; 
			var result = await doctorService.GetDoctorExistByUserIdAsync(userId);

			Assert.IsNull(result);
		}


		[Test]
		public async Task EditHealthRecordAsync_NonExistingRecordId_NoUpdate()
		{
			var model = new AdminHealthModel
			{
				Id = "6F66D5E0-4B8F-45C3-931A-D5833C63DB22",
				Microchip = true,
				MicrochipNumber = "2948506294859681",
				FirstVaccine = true,
				SecondVaccine = true,
				ThirdVaccine = true,
				AnnualVaccine = true,
				GeneralCondition = "Good"
			};

			await doctorService.EditHealthRecordAsync(model);
			var updatedRecord = await dbContext.HealthRecords.FirstOrDefaultAsync(x => x.Id == Guid.Parse(model.Id));

			Assert.IsNull(updatedRecord);
		}


		[Test]
		public async Task AddHealthRecordAsync_NullModel_NoAddition()
		{
			var animalId = "3FA15101-2A77-453B-9891-97301E778C39";
			
			Assert.ThrowsAsync<NullReferenceException>(() => doctorService.AddHealthRecordAsync(null, animalId));
			
		}

		[Test]
		public async Task GetMedicalModelAsync_ReturnsDoctors()
		{
			var expectedDoctorCount = 3; 
			var doctors = new List<Doctor>();
			for (int i = 1; i <= expectedDoctorCount; i++)
			{
				doctors.Add(new Doctor
				{
					Id = Guid.NewGuid(),
					FirstName = $"Doctor{i}",
					LastName = $"LastName{i}",
					Address = $"Address{i}",
					PhoneNumber = $"088888888{i}",
					Photo = $"https://www.google.com"
				});
			}
			dbContext.Doctors.AddRange(doctors);
			await dbContext.SaveChangesAsync();

			var medicalModel = await doctorService.GetMedicalModelAsync();

			Assert.IsNotNull(medicalModel);
		}

		[Test]
		public async Task GetMedicalModelAsync_NoDoctors_ReturnsEmptyList()
		{
			var medicalModel = await doctorService.GetMedicalModelAsync();

			Assert.IsNotNull(medicalModel);
			Assert.IsNotEmpty(medicalModel.Doctors);
		}

		[Test]
		public async Task GetMedicalModelAsync_NullDbContext_ReturnsNull()
		{
			var medicalModel = await doctorService.GetMedicalModelAsync();

			Assert.IsNotNull(medicalModel);
		}

		[Test]
		public async Task AddMedicalAsync_AddsMedicalRecord()
		{
			var healthRecordId = Guid.NewGuid().ToString();
			var doctorId = Guid.NewGuid().ToString();
			var model = new AnimalMedicalModel
			{
				DoctorId = doctorId,
				Date = DateTime.Now,
				Reason = "Test Reason",
				Constatation = "Test Constatation",
				PrescribedTreatment = "Test Prescribed Treatment"
			};
			await doctorService.AddMedicalAsync(model, healthRecordId);

			var addedMedical = await dbContext.Medicals.FirstOrDefaultAsync(m => m.Reason == model.Reason);
			Assert.IsNotNull(addedMedical);
			Assert.AreEqual(doctorId, addedMedical.DoctorId.ToString());
			Assert.AreEqual(model.Date, addedMedical.Date);
			Assert.AreEqual(model.Reason, addedMedical.Reason);
			Assert.AreEqual(model.Constatation, addedMedical.Constatation);
			Assert.AreEqual(model.PrescribedTreatment, addedMedical.PrescribedTreatment);
		}

	}
}
