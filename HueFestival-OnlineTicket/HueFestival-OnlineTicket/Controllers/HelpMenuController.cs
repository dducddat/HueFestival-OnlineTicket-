using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpMenuController : ControllerBase
    {
        private readonly IHelpMenuService helpMenuService;

        public HelpMenuController(IHelpMenuService _helpMenuService)
        {
            helpMenuService = _helpMenuService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(HelpMenuVM_Input input)
        {
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await helpMenuService.AddAsync(input);

            return Ok("Successfully");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await helpMenuService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return BadRequest();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await helpMenuService.GetAllAsync());

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int id) 
        {
            var result = await helpMenuService.GetDetailsAsync(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, HelpMenuVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await helpMenuService.UpdateAsync(id, input))
                return Ok("Update Successfully");

            return BadRequest();
        }
    }
}
