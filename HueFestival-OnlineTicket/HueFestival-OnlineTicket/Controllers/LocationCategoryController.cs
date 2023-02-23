using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationCategoryController : ControllerBase
    {
        private readonly ILocationCategoryRepository _locationCategoryRepo;

        public LocationCategoryController(ILocationCategoryRepository locationCategoryRepo)
        {
            _locationCategoryRepo = locationCategoryRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _locationCategoryRepo.GetAllAsync());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _locationCategoryRepo.GetByIdAsync(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _locationCategoryRepo.EditAsync(id);

            if(result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, LocationCategoryVM locationCategoryVM)
        {
            if(id != locationCategoryVM.Id) 
                return BadRequest("Invalid Input");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = await _locationCategoryRepo.EditAsync(id, locationCategoryVM);

            if (result == 0)
                return NotFound();

            return Ok("Update Successfully");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocationCategoryVM_Input locationCategoryVM_Input)
        {
            if(!ModelState.IsValid) 
                return UnprocessableEntity(ModelState);

            await _locationCategoryRepo.AddAsync(locationCategoryVM_Input);

            return Ok("Add Successfully");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _locationCategoryRepo.DeleteAsync(id);

            if(result == 0)
                return NotFound();

            return Ok("Delete Successfully");
        }
    }
}
