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

        [HttpPut("change_password")]
        public async Task<IActionResult> ChangePassword(UserVM_ChangePassword input)
        {
            if (input.NewPassword != input.ConfirmNewPassword)
                return BadRequest("Other new password confirm new password");

            var result = await userService.ChangePassword(1, input);

            switch(result)
            {
                case 1:
                    return NotFound();
                case 2:
                    return BadRequest("Old password is incorrect");
                case 3:
                    return Ok("Successfully");
                default:
                    return NoContent();
            }    
        }

        [HttpGet("location_and_show_favorite")]
        public async Task<IActionResult> GetAllShowAndLocationFavorive(int userId)
        {
            return Ok(await userService.GetAllShowAndLocationFavoriveAsync(userId));
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
