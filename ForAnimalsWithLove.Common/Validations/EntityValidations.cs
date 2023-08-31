namespace ForAnimalsWithLove.Common.Validations
{
    public static class EntityValidations
    {
        public static class Animal
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;
            public const int AgeMinValue = 0;
            public const int AgeMaxValue = 100;
            public const int KindOfAnimalMinLength = 2;
            public const int KindOfAnimalMaxLength = 30;
            public const int BreedMinLength = 2;
            public const int BreedMaxLength = 30;
            public const int ColorMinLength = 2;
            public const int ColorMaxLength = 30;
            public const int SexMinLength = 1;
            public const int SexMaxLength = 1;

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
        public static class Booking
        {
            public const string AmountMinValue = "0";
            public const string AmountMaxValue = "5000";
            public const int ValidMinDays = 1;
            public const int ValidMaxDays = 60;
        }

        public static class Education
        {
            public const string AmountPerDayMinValue = "0";
            public const string AmountPerDayMaxValue = "50";
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
            public const string AmountMinValue = "0";
            public const string MaxPriceOperation = "5000";
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
            public const string AmountMinValue = "0";
            public const string MaxPriceMedical = "500";

        }

        public static class Hotel
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;
            public const int LocationMinLength = 10;
            public const int LocationMaxLength = 50;
            public const string AmountPerDayMinValue = "0";
            public const string AmountPerDayMaxValue = "100";
        }

        public static class Grooming
        {
            public const int ServiceMinLength = 5;
            public const int ServiceMaxLength = 50;
            public const decimal AmountMinValue = 0;

        }

       
        public static class User
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 12;
            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 20;
        }
    }
}
