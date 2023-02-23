using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLocationController : ControllerBase
    {
        private readonly ITickerLocationRepository _ticketLocationRepo;

        public TicketLocationController(ITickerLocationRepository tickerLocationRepo)
        {
            _ticketLocationRepo = tickerLocationRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _ticketLocationRepo.GetAllAsync());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TicketLocationVM_Input ticketLocationVM_Input)
        {
            await _ticketLocationRepo.AddAsync(ticketLocationVM_Input);

            return Ok("Successfully");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ticketLocationRepo.DeleteAsync(id);

            if (result == 0)
                return NotFound();

            return Ok("Delete Successfully");
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _ticketLocationRepo.EditAsync(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, TicketLocationVM ticketLocationVM)
        {
            var result = await _ticketLocationRepo.EditAsync(id, ticketLocationVM);

            if (result == 0)
                return NotFound();

            return Ok("Update Successfully");
        }
    }
}
