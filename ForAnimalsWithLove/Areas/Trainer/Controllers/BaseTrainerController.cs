using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ForAnimalsWithLove.Common.AreaConstants;

namespace ForAnimalsWithLove.Areas.Trainer.Controllers
{
	[Area(TrainerArea)]
	[Authorize(Roles = TrainerRoleName)]
	public class BaseTrainerController : Controller
	{
		
	}
}
