﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Owner;

namespace ForAnimalsWithLove.Data.Models
{
    public class Owner
    {
        public Owner()
        {
            this.MyAnimals = new HashSet<Animal>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        public virtual ICollection<Animal> MyAnimals { get; set; }
    }
}