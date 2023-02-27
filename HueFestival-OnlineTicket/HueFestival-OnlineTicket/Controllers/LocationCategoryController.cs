using AutoMapper;
using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationCategoryController : ControllerBase
    {
        private readonly ILocationCategoryService locationCategoryService;

        public LocationCategoryController(ILocationCategoryService _locationCategoryService)
        {
            locationCategoryService = _locationCategoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocationCategoryVM_Input locationCategoryVM_Input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await locationCategoryService.AddAsync(locationCategoryVM_Input);

            return Ok("Successfully");
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await locationCategoryService.UpdateAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(LocationCategoryVM locationCategoryVM)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if(await locationCategoryService.UpdateAsync(locationCategoryVM))
                return Ok("Update Successfully");

            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await locationCategoryService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return NotFound();
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await locationCategoryService.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await locationCategoryService.GetAllAsync());
    }
}
