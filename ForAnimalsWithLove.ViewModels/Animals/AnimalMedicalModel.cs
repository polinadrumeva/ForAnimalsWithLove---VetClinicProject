using ForAnimalsWithLove.ViewModels.Admins;
using System.ComponentModel.DataAnnotations;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecordValidtions;

namespace ForAnimalsWithLove.ViewModels.Animals
{
	public class AnimalMedicalModel
	{

		public string DoctorId { get; set; } = null!;

		[Required]
		public string DoctorFirstName { get; set; } = null!;

		[Required]
		public string DoctorLastName { get; set; } = null!;

		[Required]
		public Guid HealthRecordId { get; set; }


		[Required]
		public DateTime Date { get; set; }

		[Required]
		[StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
		[Display(Name = "Причина")]
		public string Reason { get; set; } = null!;

		[Required]
		[StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
		[Display(Name = "Констатация")]
		public string Constatation { get; set; } = null!;

		[StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
		public string? PrescribedTreatment { get; set; }

	}
}
