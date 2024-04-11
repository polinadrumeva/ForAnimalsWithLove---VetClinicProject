using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using static ForAnimalsWithLove.Common.AreaConstants;

namespace ForAnimalsWithLove.Areas.Admin.Controllers
{
    [Area(AdminArea)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
       
    }
}
