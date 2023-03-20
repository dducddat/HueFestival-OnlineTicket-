using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if (await userService.GetByPhone(input.PhoneNumber) != null)
                return BadRequest("Số điện thoại đã tồn tại");

            if (await userService.AddAsync(input))
                return Ok("Successfully");

            return Problem();
        }

        [HttpDelete("delete_user")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await userService.DeleteAsync(id))
                return Ok("Successfully");

            return Problem("User not found or error, please try again");
        }

        [Authorize]
        [HttpPut("change_password")]
        public async Task<IActionResult> ChangePassword(UserVM_ChangePassword input)
        {
            if (input.NewPassword != input.ConfirmNewPassword)
                return BadRequest("Other new password confirm new password");

            string userId = User.FindFirstValue("id");

            if (!await userService.ChangePassword(Int32.Parse(userId), input))
                return BadRequest("Wrong password");

            return Ok("Successfully");
        }

        [Authorize]
        [HttpGet("location_and_show_favorite")]
        public async Task<IActionResult> GetAllShowAndLocationFavorive()
        {
            string userId = User.FindFirstValue("id");

            return Ok(await userService.GetAllShowAndLocationFavoriveAsync(Int32.Parse(userId)));
        }

        [HttpPut("update_role")]
        public async Task<IActionResult> UpdateRole(UserVM_UpdateRole input)
        {
            if (await userService.UpdateRoleAsync(input))
                return Ok("Successfully");

            return BadRequest();
        }

        [HttpGet("get_list_user")]
        public async Task<IActionResult> GetAll()
            => Ok(await userService.GetAllAsync());

        [HttpPut("update_infomation")]
        public async Task<IActionResult> UpdateInfo(UserVM_UpdateInfo input)
        {
            if (await userService.UpdateInfoAsync(input)) return Ok("Successfully");

            return BadRequest();
        }
    }
}
