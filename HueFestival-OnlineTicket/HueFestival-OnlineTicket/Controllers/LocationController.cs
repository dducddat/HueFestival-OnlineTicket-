using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService _locationService)
        {
            locationService = _locationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocationVM_Input locationVM_Input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await locationService.AddAsync(locationVM_Input))
                return Ok("Add Successfully");
            
            return BadRequest();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await locationService.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await locationService.UpdateAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await locationService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Delete Successfully");
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(LocationVM_Update locationVM_Update)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if(await locationService.UpdateAsync(locationVM_Update))
                return Ok("Edit Successfully");

            return BadRequest();
        }
    }
}
