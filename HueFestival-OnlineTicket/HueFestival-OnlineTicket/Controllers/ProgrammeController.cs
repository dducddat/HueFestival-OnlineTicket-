using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammeController : ControllerBase
    {
        private readonly IProgrammeService programmeService;

        public ProgrammeController(IProgrammeService _programmeService)
        {
            programmeService = _programmeService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProgrammeVM_Input input)
        {
            await programmeService.AddAsync(input);

            return Ok("Successfully");
        }
    }
}
