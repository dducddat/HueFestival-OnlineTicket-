using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IMapper _mapper, IEmployeeService _employeeService)
        {
            mapper = _mapper;
            employeeService = _employeeService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(EmployeeVM_Create input)
        {
            try
            {
                var employee = mapper.Map<Employee>(input);

                employee.Id = Guid.NewGuid();
                employee.Activate = false;

                await employeeService.AddAsync(employee);

                return Ok("Add thành công");
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("get_list_employee")]
        public async Task<IActionResult> GetAll()
            => Ok(mapper.Map<List<EmployeeVM>>(await employeeService.GetAllAsync()));

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            await employeeService.DeleteAsync(employee);

            return Ok("Delete thành công");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, EmployeeVM_Update input)
        {
            try
            {
                var employee = await employeeService.GetByIdAsync(id);

                if (employee == null)
                    return NotFound();

                mapper.Map<EmployeeVM_Update, Employee>(input, employee);

                await employeeService.UpdateAsync(employee);

                return Ok("Update thành công");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
