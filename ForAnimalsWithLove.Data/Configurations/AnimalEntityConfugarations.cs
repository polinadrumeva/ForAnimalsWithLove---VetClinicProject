using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ForAnimalsWithLove.Data.Models;

namespace ForAnimalsWithLove.Data.Configurations
{
    public class AnimalEntityConfugarations : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData(GenerateAnimals());
        }

        private Animal[] GenerateAnimals()
        {
            var animals = new HashSet<Animal>();

            Animal animal;
            animal = new Animal()
            {
                Name = "Тито",
                Age = 0,
                Photo = "~/images/titocat.jpg",
                KindOfAnimal = "Котка",
                Breed = "Любов",
                Sex = 'M',
                Birthdate = new DateTime(2023, 06, 09),
                Color = "Оранжев",
                DoesHasOwner = false,
                OwnerId = null,
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = 1
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Майла",
                Age = 4,
                Photo = "~/images/mailadog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Любов",
                Sex = 'F',
                Birthdate = new DateTime(2019, 04, 06),
                Color = "Кафяво-черно",
                DoesHasOwner = false,
                OwnerId = null,
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = 2
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Пешо",
                Age = 2,
                Photo = "~/images/peshocat.jpg",
                KindOfAnimal = "Котка",
                Breed = "Сиамска",
                Sex = 'M',
                Birthdate = new DateTime(2022, 12, 12),
                Color = "Сив",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("251CFF84-1067-447F-88E1-071FD802ED16"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Хати",
                Age = 4,
                Photo = "~/images/haticat.jpg",
                KindOfAnimal = "Котка",
                Breed = "Хималайска",
                Sex = 'F',
                Birthdate = new DateTime(2019, 12, 12),
                Color = "Бял с кафеви петна",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("61D265A4-4A0A-4D49-B6DF-2A68F9A6DDE7"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null

            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Марио",
                Age = 1,
                Photo = "~/images/mariocat.jpg",
                KindOfAnimal = "Котка",
                Breed = "Регдол",
                Sex = 'M',
                Birthdate = new DateTime(2022, 08, 01),
                Color = "Бял",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("647F35A8-87E5-455B-A233-30E835E70AA2"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Маша",
                Age = 5,
                Photo = "~/images/mashacat.jpg",
                KindOfAnimal = "Котка",
                Breed = "Руска синя",
                Sex = 'F',
                Birthdate = new DateTime(2018, 07, 21),
                Color = "Сив",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("D4E17EFD-C288-4535-99F7-3DCE589E7602"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Монти",
                Age = 3,
                Photo = "~/images/monticat.jpg",
                KindOfAnimal = "Котка",
                Breed = "Любов",
                Sex = 'M',
                Birthdate = new DateTime(2021, 05, 30),
                Color = "Оранжев",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("840EA3F5-6147-4535-A2E9-5A2D696A56D5"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Рама",
                Age = 4,
                Photo = "~/images/ramacat.jpg",
                KindOfAnimal = "Котка",
                Breed = "Сфинкс",
                Sex = 'F',
                Birthdate = new DateTime(2019, 10, 05),
                Color = "Бял",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("75378AFE-3B3A-4A31-AB4E-5BC9671CDC28"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            }; 
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Бели",
                Age = 7,
                Photo = "~/images/belidog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Годън ретривър",
                Sex = 'M',
                Birthdate = new DateTime(2016, 11, 13),
                Color = "Оранжев",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("7867B0C8-A1C7-41BC-B783-764336B04ED6"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Белла",
                Age = 0,
                Photo = "~/images/belladog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Йоркширски териер",
                Sex = 'F',
                Birthdate = new DateTime(2023, 01, 02),
                Color = "Светло кафяв",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("82853A05-7F15-4636-86A2-8C08CD400BAF"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Боби",
                Age = 4,
                Photo = "~/images/bobidog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Мопс",
                Sex = 'M',
                Birthdate = new DateTime(2019, 09, 13),
                Color = "Бял с черни петна",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("D0381673-62B4-4298-B47D-A489E1CD12C0"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Кари",
                Age = 0,
                Photo = "~/images/carydog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Джак ръсел",
                Sex = 'F',
                Birthdate = new DateTime(2023, 04, 03),
                Color = "Бял с черни петна",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("C3356B8F-8570-428B-8E79-0A09975D947D"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Чоки",
                Age = 7,
                Photo = "~/images/chokidog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Джак ръсел",
                Sex = 'M',
                Birthdate = new DateTime(2016, 10, 11),
                Color = "Бял с кафеви петна",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("C3356B8F-8570-428B-8E79-0A09975D947D"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Джонсън",
                Age = 9,
                Photo = "~/images/jonsundog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Немска овчарка",
                Sex = 'M',
                Birthdate = new DateTime(2014, 09, 05),
                Color = "Кафяво-черно",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("A69E4EE8-70BE-487C-BC89-A539265AA4C0"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Макси",
                Age = 0,
                Photo = "~/images/maksidog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Лабрадор",
                Sex = 'M',
                Birthdate = new DateTime(2021, 07, 01),
                Color = "Кафяво",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("FA4970AB-2221-404A-9AFB-A976D210DCBB"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Сара",
                Age = 3,
                Photo = "~/images/saradog.jpg",
                KindOfAnimal = "Куче",
                Breed = "Акита ину",
                Sex = 'F',
                Birthdate = new DateTime(2020, 05, 10),
                Color = "Оранжево",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("ABE0F2E6-17F3-428D-B7EA-CC3EF2B855CD"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Бенду",
                Age = 2,
                Photo = "~/images/benduhamster.jpg",
                KindOfAnimal = "Морско свинче",
                Breed = "Морско свинче",
                Sex = 'M',
                Birthdate = new DateTime(2021, 09, 01),
                Color = "Бял с оранжеви и черни петна",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("96CF5FA4-B230-4C7A-802F-DEA17A7A229C"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null

            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Какару",
                Age = 5,
                Photo = "~/images/kakarupapagal.jpg",
                KindOfAnimal = "Папагал",
                Breed = "Африкански сив",
                Sex = 'M',
                Birthdate = new DateTime(2018, 12, 01),
                Color = "Сив",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("F4C4A26E-3DAB-4BD7-9AB7-F5AAFC78B0FB"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);


            animal = new Animal()
            {
                Name = "Малину",
                Age = 1,
                Photo = "~/images/malinupor.jpg",
                KindOfAnimal = "Пор",
                Breed = "Пор",
                Sex = 'M',
                Birthdate = new DateTime(2022, 04, 20),
                Color = "Сив с бели петна",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("F4C4A26E-3DAB-4BD7-9AB7-F5AAFC78B0FB"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);

            animal = new Animal()
            {
                Name = "Сарина",
                Age = 10,
                Photo = "~/images/sarinahorse.jpg",
                KindOfAnimal = "Кон",
                Breed = "Фризийски",
                Sex = 'F',
                Birthdate = new DateTime(2013, 03, 08),
                Color = "Черен",
                DoesHasOwner = true,
                OwnerId = Guid.Parse("5A59A1C0-DC04-4AF1-84D5-F9FE623C6068"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);


            return animals.ToArray();
        }
    }
}
