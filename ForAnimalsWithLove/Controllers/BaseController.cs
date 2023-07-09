using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
		
	}
}
