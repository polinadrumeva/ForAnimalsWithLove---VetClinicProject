﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Grooming;

namespace ForAnimalsWithLove.Data.Models
{
    public class Grooming
    {
        public Grooming()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; } = null!;

        [Required]
        [StringLength(ServiceMaxLength, MinimumLength = ServiceMinLength)]
        public string Service { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }
    }
}