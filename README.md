[![Build and Test](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/actions/workflows/dotnet.yml/badge.svg)](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/actions/workflows/dotnet.yml)

# ForAnimalsWithLove---VetClinicProject
The project was created at C#. The following technologies were used: ASP. NET Core, ASP.NET Core areas, Entity Framework Core, MS SQL, jQuery, JS, Bootstrap 4, NUnit, Selenium. Including automated build and test with github actions. 
![1](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/20dc9a9d-99cc-4ba4-897f-ed617d9e9090)

The logo was made by me personally for the purposes of the project.
![logo](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/09589c35-402a-42b8-80fa-be3253a12f29)

## Functionality
1. User registration;
2. Owner access - each owner's access to their pet's file - health file details, hospital accommodation, hotel accommodation, last used grooming services and training.;
3. Admin access - Administrators have access to three categories - Customers, Doctors and Trainers. In the section "Clients" they can add new clients, change data of existing ones, their owners, hairdressing services, hotel accommodation, they can see the health and hospital files of the clients. In the Doctors section, they can add new doctors, change information about existing ones and remove them. In the "Coaches" section, they can add new coaches, change information about existing ones and remove them.;
4. Doctor access - Doctors have access to the Clients section, can edit patients' health records, add hospital admissions, perform tests, surgeries, view clients' health records and their details, including hospital admissions. Only doctors have access to these features.;
5. Trainer access - Trainers have access to the "Clients" section, can add new trainings, see the clients' health record and details about them. Only trainers have access to these functionalities.;

## Database Diagram
![Database](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/5eeabeab-fb56-4ab2-8676-68d8f13cda12)

## Project Architecture
1. ForAnimalsWithLove - ASP .NET Core Web App MVC.
2. ForAnimalsWithLove.Infrastructure - holding Extensions.   
3. ForAnimalsWithLove.Data.Models - holding DB-Models.
4. ForAnimalsWithLove.Data.Service.Model - holding Service Models.
5. ForAnimalsWithLove.Data.Service  - holding Services.
6. ForAnimalsWithLove.Data - holding DBContext and Migrations.
7. ForAnimalsWithLove.ViewModels - holding ViewModels.
8. ForAnimalWithLove.UITests - Test Project, holding UI Tests.
9. ForAnimalsWithLove.Service.Tests - NUnit Test Project, holding Service Tests.
10. ForAnimalsWithLove.Common

## Tests - over 150 tests
1. Unit tests - NUnit; over 100 tests;
2. UI tests - Selenium, Selenium Chrome; 50 tests;
## App Images
![2](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/e1032b5d-f376-431f-bd38-f5c2a56c094d)
![3](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/cf75b610-dd61-4d51-b59a-0a3653dd1ee6)
![4](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/044ae2c9-8db7-4403-8dac-82e12aa69f4d)
![5](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/ffd4ba9a-381f-4939-9972-b19a1ba14a10)
![6](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/c81590e3-3676-4d12-96f4-2c5f2ba484f2)
![13](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/88d44f98-19f1-4ba7-a41a-cb456c6a5aa3)


### Login Administrator
![11](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/0cf96712-05ae-4acf-b206-dc6fff9288e4)
![14](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/1afcc375-d076-41a9-8d02-e000dc900a3f)
![20](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/aa30f53d-5993-45e6-bebb-6e448f165e7b)


### Login Trainer/Doctor
![12](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/4db0eb33-7712-4cfb-8b68-c9df77fad797)
![19](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/1369b408-9244-4fdb-a813-6a1929332d09)

### Login Owner
![16](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/0b9c00e7-2aaf-425d-a6c4-1003edb760c4)
![17](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/02fcdb19-b6dc-4473-b3e8-f6f1bfcdd83e)
![18](https://github.com/polinadrumeva/ForAnimalsWithLove---VetClinicProject/assets/97524018/ba270cf9-b8a3-4e22-af4b-b438250fc5dd)


