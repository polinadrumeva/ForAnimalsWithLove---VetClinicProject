using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Grooming;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminGroomingModel
    {
       
        public Guid AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public AdminOwnerModel Animal { get; set; } = null!;

        
        [StringLength(ServiceMaxLength, MinimumLength = ServiceMinLength)]
        [Display(Name = "Услуга")]
        public string Service { get; set; } = null!;
    }
}
