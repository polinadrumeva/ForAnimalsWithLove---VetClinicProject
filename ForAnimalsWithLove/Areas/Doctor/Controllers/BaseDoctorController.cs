using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ForAnimalsWithLove.Common.AreaConstants;

namespace ForAnimalsWithLove.Areas.Doctor.Controllers
{
	[Area(DoctorArea)]
	[Authorize(Roles = DoctorRoleName)]
	public class BaseDoctorController : Controller
	{
		
	}
}
