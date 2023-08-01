using Microsoft.AspNetCore.Mvc;

using ForAnimalsWithLove.Data.Service.Interfaces;

namespace ForAnimalsWithLove.Controllers
{
    //Owner Controller is taking care of the owner's functionality
    public class OwnerController : BaseController
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
             this.ownerService = ownerService;
        }

        public async Task<IActionResult> Register()
        {
   //         var result = await ownerService.OwnerExistByPhone();
   //         if (!result)
   //         {
			//	return RedirectToAction("Index", "Home");
			//}
   //         else
   //         {
                return RedirectToAction("Login", "Home");

        }
    }
}
