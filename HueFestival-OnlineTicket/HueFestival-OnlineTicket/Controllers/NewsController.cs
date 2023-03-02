using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService newsService;

        public NewsController(INewsService _newsService)
        {
            newsService = _newsService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
            => Ok(await newsService.GetAllAsync());

        [HttpPost("Add")]
        public async Task<IActionResult> Add(NewsVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await newsService.AddAsync(input))
                return Ok("Successfully");

            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await newsService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return NotFound();
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await newsService.GetDetailsAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, NewsVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await newsService.UpdateAsync(id, input))
                return Ok("Edit Successfully");

            return BadRequest();
        }
    }
}
