﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Animal;

namespace ForAnimalsWithLove.Data.Models
{
    public class Animal
    {
        public Animal()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(AgeMinValue, AgeMaxValue)]
        public int Age { get; set; }

        public string? Photo { get; set; }

        [Required]
        [StringLength(KindOfAnimalMaxLength, MinimumLength = KindOfAnimalMinLength)]
        public string KindOfAnimal { get; set; } = null!;

        [Required]
        [StringLength(BreedMaxLength, MinimumLength = BreedMinLength)]
        public string Breed { get; set; } = null!;

        [Required]
        public char Sex { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; } = null!;

        [Required]
        public bool DoesHasOwner { get; set; }

        public Guid? OwnerId { get; set; }

        public Owner? Owner { get; set; }

        public Guid? GroomingId { get; set; }

        public Grooming? Grooming { get; set; }

        [Required]
        public Guid HealthRecordId { get; set; }

        [Required]
        public HealthRecord HealthRecord { get; set; } = null!;

        public int? SearchHomeId { get; set; }
        public SearchHome? SearchHome { get; set; }

    }

}