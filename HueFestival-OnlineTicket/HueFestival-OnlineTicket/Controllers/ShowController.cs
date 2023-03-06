using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService showService;

        public ShowController(IShowService _showService)
        {
            showService = _showService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ShowVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = await showService.AddAsync(input);

            switch(result)
            {
                case 1:
                    return NotFound(new { Success = false ,Message = "Location, program or location category not found" });
                case 2:
                    return Problem();
                case 3:
                    return Ok("Successfully");
                default:
                    return NoContent();
            }
        }

        [HttpGet("get_calendar_list")]
        public async Task<IActionResult> GetCalendarList()
            => Ok(await showService.GetCalendarList());

        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetByDate(DateTime date)
            => Ok(await showService.GetByDate(date));
    }
}
