using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepo;

        public LocationController(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocationVM_Input locationVM_Input) 
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _locationRepo.AddAsync(locationVM_Input);

            return Ok("Add Successfully");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _locationRepo.GetByIdAsync(id);

            if (location is null)
                return NotFound();

            return Ok(location);
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var location = await _locationRepo.EditAsync(id);

            if (location is null)
                return NotFound();

            return Ok(location);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _locationRepo.DeleteAsync(id);

            if (result == 0)
                return NotFound();

            return Ok("Delete Successfully");
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, LocationVM_Details locationVM_Details)
        {
            if (id != locationVM_Details.Id)
                return BadRequest("Invalid Input");

            var result = await _locationRepo.EditAsync(id, locationVM_Details);

            if(result == 0) 
                return NotFound();

            return Ok("Edit Successfully");
        }
    }
}
