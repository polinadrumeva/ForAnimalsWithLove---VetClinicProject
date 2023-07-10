using ForAnimalsWithLove.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                OwnerId = Guid.Parse("251CFF84-1067-447F-88E1-071FD802ED16"),
                GroomingId = null,
                HealthRecordId = Guid.NewGuid(),
                SearchHomeId = null
            };
            animals.Add(animal);



65  Белла   0   ~/ images / belladog.jpg   Куче Йоркширски териер F   2023 - 01 - 02 00:00:00.0000000 Светло кафяв    1   8   2   9   NULL
66  Боби    4   ~/ images / bobidog.jpg    Куче Мопс    M   2019 - 09 - 13 00:00:00.0000000 Бял с черни петна   1   9   NULL    10  NULL
67  Кари    0   ~/ images / carydog.jpg    Куче Джак ръсел F   2023 - 04 - 03 00:00:00.0000000 Бял с черни петна   1   10  NULL    11  NULL
68  Чоки    7   ~/ images / chokidog.jpg   Куче Джак ръсел M   2016 - 10 - 11 00:00:00.0000000 Бял с кафеви петна  1   10  NULL    12  NULL
69  Джонсън 9   ~/ images / jonsundog.jpg  Куче Немска овчарка M   2014 - 09 - 05 00:00:00.0000000 Кафяво - черно    1   11  NULL    13  NULL

71  Макси   0   ~/ images / maksidog.jpg   Куче Лабрадор    M   2014 - 07 - 01 00:00:00.0000000 Кафяво  1   12  NULL    15  NULL
72  Сара    3   ~/ images / saradog.jpg    Куче Акита ину F   2020 - 05 - 10 00:00:00.0000000 Оранжево    1   13  NULL    16  NULL
73  Бенду   2   ~/ images / benduhamster.jpg   Морско свинче   Морско свинче   M   2021 - 09 - 01 00:00:00.0000000 Бял с оранжеви и черни петна    1   14  NULL    17  NULL
74  Какару  5   ~/ images / kakarupapagal.jpg  Папагал Африкански сив M   2018 - 12 - 01 00:00:00.0000000 Сив 1   15  NULL    18  NULL
75  Малину  1   ~/ images / malinupor.jpg  Пор Пор M   2022 - 04 - 20 00:00:00.0000000 Сив с бели петна    1   16  NULL    19  NULL
76  Сарина  10  ~/ images / sarinahorse.jpg    Кон Фризийски   F   2013 - 03 - 08 00:00:00.0000000 Черен   1   17  NULL    20  NULL

        }
    }
}
