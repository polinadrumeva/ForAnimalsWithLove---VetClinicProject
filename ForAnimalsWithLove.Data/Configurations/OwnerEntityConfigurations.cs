using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ForAnimalsWithLove.Data.Models;

namespace ForAnimalsWithLove.Data.Configurations
{
    public class OwnerEntityConfigurations : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasData(GenerateOwners());
        }

        private Owner[] GenerateOwners()
        {
            var owners = new HashSet<Owner>();

            Owner owner;
            owner = new Owner()
            {
                FirstName = "Марин",
                MiddleName = null,
                LastName = "Велев",
                PhoneNumber = "098977283",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Марияна",
                MiddleName = "Георгиева",
                LastName = "Иванова",
                PhoneNumber = "0834772389",
                Address = "Ихтиман"
            };
            owners.Add(owner);
            
            owner = new Owner()
            {
                FirstName = "Стефан",
                MiddleName = "Петров",
                LastName = "Петров",
                PhoneNumber = "0989775680",
                Address = "Елин Пелин"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Мария",
                MiddleName = null,
                LastName = "Петрова",
                PhoneNumber = "0884788900",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Валентина",
                MiddleName = null,
                LastName = "Дюрова",
                PhoneNumber = "0885666218",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Станимир",
                MiddleName = null,
                LastName = "Хаджиев",
                PhoneNumber = "0898322211",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Иван",
                MiddleName = null,
                LastName = "Валентинов",
                PhoneNumber = "0886755349",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Мария",
                MiddleName = null,
                LastName = "Кръстева",
                PhoneNumber = "0887334785",
                Address = "Дупница"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Галина",
                MiddleName = "Недева",
                LastName = "Кръстева",
                PhoneNumber = "0878611282",
                Address = "Дупница"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Полина",
                MiddleName = null,
                LastName = "Друмева",
                PhoneNumber = "0878644619",
                Address = "Велико Търново"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Симона",
                MiddleName = null,
                LastName = "Иванова",
                PhoneNumber = "0885565213",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Йоанна",
                MiddleName = null,
                LastName = "Здравкова",
                PhoneNumber = "0888672662",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Магдалена",
                MiddleName = null,
                LastName = "Иванова",
                PhoneNumber = "0887721356",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Ивета",
                MiddleName = null,
                LastName = "Манолова",
                PhoneNumber = "072826786",
                Address = "Тетевен"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Красимир",
                MiddleName = "Недялков",
                LastName = "Иванов",
                PhoneNumber = "0898268776",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Росица",
                MiddleName = null,
                LastName = "Маринова",
                PhoneNumber = "0878221112",
                Address = "София"
            };
            owners.Add(owner);

            owner = new Owner()
            {
                FirstName = "Деница",
                MiddleName = "Иванова",
                LastName = "Иванова",
                PhoneNumber = "0898217888",
                Address = "Самоков"
            };
            owners.Add(owner);


            return owners.ToArray();

        }
    }
}
