using Microsoft.AspNetCore.Mvc;
using RendMyRide.Contracts.Users;
using RendMyRide.Infrastructure.Services;

namespace RendMyRide.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            await _userService
                .Register(registerUser.UserName, registerUser.UserLastName, registerUser.Phone, registerUser.Email, registerUser.Password);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            var token = _userService.Login(loginUser.Email, loginUser.Password);

            return Ok(token);
        }

    }
}
