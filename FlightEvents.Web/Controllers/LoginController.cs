using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightEvents.Web.Controllers
{
    public class LoginController : ControllerBase
    {
        [Route("Login/Microsoft")]
        public IActionResult Microsoft([FromQuery] string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("~/");

            return Challenge(new AuthenticationProperties
            {
                RedirectUri = ReturnUrl
            }, "Microsoft");
        }

        [Route("Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("Microsoft");
        }
    }
}
