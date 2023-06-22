using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Common.Validations
{
    public static class EntityValidations
    {
        public static class Animal
        { 
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;
            public const int AgeMinValue = 0;
            public const int AgeMaxValue = 50;
            public const int KindOfAnimalMinLength = 2;
            public const int KindOfAnimalMaxLength = 30;
            public const int BreedMinLength = 2;
            public const int BreedMaxLength = 30;
            public const int ColorMinLength = 2;
            public const int ColorMaxLength = 30;

        }

        public static class Doctor
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 20;
            public const int LastNameMinLength = 5;
            public const int LastNameMaxLength = 20;
            public const int DirectionMinLength = 5;
            public const int DirectionMaxLength = 30;
            public const int PhoneNumberLength = 10;
            public const int AddressMinLength = 10;
            public const int AddressMaxLength = 50;
            
        }

        public static class Owner
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 20;
            public const int LastNameMinLength = 5;
            public const int LastNameMaxLength = 20;
            public const int PhoneNumberLength = 10;
            public const int AddressMinLength = 10;
            public const int AddressMaxLength = 50;

        }
    }
}
