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

        public static class Operation
        { 
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }

        public static class HealthRecord
        {
            public const int ChipMinLength = 9;
            public const int ChipMaxLength = 15;
            public const int GeneralConditionMinLength = 10;
            public const int GeneralConditionMaxLength = 500;
            public const int PrescriptionMinLength = 5;
            public const int PrescriptionMaxLength = 500;
        }

        public static class HospitalRecord 
        { 
            public const int DiagnosisMinLength = 6;
            public const int DiagnosisMaxLength = 500;
            public const int TreatmentMinLength = 5;
            public const int TreatmentMaxLength = 500;
            
        }

        public static class Hotel
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;
            public const int LocationMinLength = 10;
            public const int LocationMaxLength = 50;
        }

        public static class Grooming
        { 
            public const int ServiceMinLength = 5;
            public const int ServiceMaxLength = 50;
        }
    }
}
