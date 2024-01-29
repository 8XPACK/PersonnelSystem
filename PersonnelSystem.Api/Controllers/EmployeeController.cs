using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelSystem.Application.Abstract;
using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;

namespace PersonnelSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        [Route("")]
        public async Task<EmployeeDto> Create(EmployeeDto employeeDto)
        {
            return await _employeeService.Create(employeeDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeDto> Get(Guid id)
        {
            return await _employeeService.GetById(id);
        }
        [HttpGet]
        [Route("departments/")]
        public async Task<EmployeeViewModel> GetByDepartmentIdAndPeriodDate(Guid departmentId, DateTime startDate, DateTime endDate, int page, int limit)
        {
            return await _employeeService.GetByDepartmentIdAndPeriodDate(departmentId, startDate, endDate, page, limit);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeService.Delete(id);
            return NoContent();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<EmployeeDto> Update(Guid id, EmployeeDto employeeDto)
        {
            return await _employeeService.Update(id,employeeDto);
        }
    }
}
