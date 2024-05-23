using Microsoft.AspNetCore.Mvc;
using RendMyRide.Contracts.Users;
using RendMyRide.Domain.Interfaces.Services;
using RendMyRide.Infrastructure.Services;

namespace RendMyRide.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("register")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            await _userService
                .Register(registerUser.UserName, registerUser.UserLastName, registerUser.Phone, registerUser.Email, registerUser.Password);

            return Ok();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("login")]
        public async Task<ActionResult> Login(LoginUser loginUser, HttpContext context)
        {
            var token = await _userService.Login(loginUser.Email, loginUser.Password);

            context.Response.Cookies.Append("tasty-cookies", token);

            return Ok();
        }

    }
}
