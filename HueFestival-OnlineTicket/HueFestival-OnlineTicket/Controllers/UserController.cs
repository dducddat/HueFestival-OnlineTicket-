using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UserVM_Input input)
        {
            if (await userService.AddAsync(input))
                return Ok("Successfully");

            return Problem();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserVM_Login input)
        {
            return Ok(await userService.LoginAsync(input));
        }
    }
}
