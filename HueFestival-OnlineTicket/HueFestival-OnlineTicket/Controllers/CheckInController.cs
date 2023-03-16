using AutoMapper;
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
    public class CheckInController : ControllerBase
    {
        private readonly ICheckInService checkInService;

        public CheckInController(ICheckInService _checkInService)
        {
            checkInService = _checkInService;
        }

        [Authorize]
        [HttpPost("check_in")]
        public async Task<IActionResult> CheckIn(string code)
        {
            string employeeId = User.FindFirstValue("id");

            var resultCheckIn = await checkInService.CheckInAsync(code, employeeId);

            return Ok(resultCheckIn);
        }
    }
}
