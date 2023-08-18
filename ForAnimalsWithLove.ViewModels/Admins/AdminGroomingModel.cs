using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Grooming;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminGroomingModel
    {
        public AdminGroomingModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string AnimalId { get; set; }


        [StringLength(ServiceMaxLength, MinimumLength = ServiceMinLength)]
        [Display(Name = "Услуга")]
        public string Service { get; set; } = null!;
    }
}
