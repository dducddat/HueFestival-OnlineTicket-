using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLocationController : ControllerBase
    {
        private readonly ITicketLocationService ticketLocationService;

        public TicketLocationController(ITicketLocationService _ticketLocationService)
        {
            ticketLocationService = _ticketLocationService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await ticketLocationService.GetAllAsync());

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TicketLocationVM_Input ticketLocationVM_Input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await ticketLocationService.AddASync(ticketLocationVM_Input);

            return Ok("Successfully");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await ticketLocationService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return NotFound();
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await ticketLocationService.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(TicketLocationVM ticketLocationVM)
        {
            if(await ticketLocationService.UpdateAsync(ticketLocationVM))
                return Ok("Update Successfully");
        
            return BadRequest();
        }
    }
}
