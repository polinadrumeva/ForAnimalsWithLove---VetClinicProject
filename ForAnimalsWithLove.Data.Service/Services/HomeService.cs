﻿using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly ForAnimalsWithLoveDbContext dbContext;

        public HomeService(ForAnimalsWithLoveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<IndexModel>> GetAllAnimalsAsync()
        {
            var animals = await dbContext.Animals
                                .Select(a => new IndexModel()
                                {
                                    Name = a.Name
                                })
                                .ToListAsync();

            return animals;
        }

        public async Task<IndexCountsModel> GetAllCount()
        {
            var countModel = new IndexCountsModel()
            {
                AnimalsCount = await dbContext.Animals.CountAsync(),
                DoctorCount = await dbContext.Doctors.CountAsync(),
                ForAdoptionCount = await dbContext.SearchHomes.CountAsync()
            };

            return countModel;
        }

        public async Task<IEnumerable<IndexDoctorModel>> GetAllDoctors()
        {
            var doctors = await dbContext.Doctors
                                .Select(d => new IndexDoctorModel()
                                {
                                    FirstName = d.FirstName
                                })
                                .ToListAsync();

            return doctors;
        }

        public async Task<IEnumerable<IndexForAdoptionModel>> GetAllForAdoption()
        {
            var forAdoption = await dbContext.Animals
                                .Select(a => new IndexForAdoptionModel()
                                {
                                    Name = a.Name
                                })
                                .ToListAsync(); 

            return forAdoption;
        }

      

        //public async Task<IEnumerable<IndexModel>> GetAnimals()
        //{
        //    //var animals = await dbContext.Animals
        //    //                              .Select(a => new IndexViewModel()
        //    //                              {
        //    //                                  ImageUrl = a.Photo
        //    //                              })
        //    //                              .Take(10)
        //    //                              .ToArrayAsync();

        //    //return animals;
        //}
    }
}