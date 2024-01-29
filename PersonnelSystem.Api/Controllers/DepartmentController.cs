using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelSystem.Application.Abstract;
using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;
using PersonnelSystem.Core.Entities;

namespace PersonnelSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) 
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        [Route("")]
        public async Task<DepartmentDto> Create(DepartmentDto departmentDto)
        {
            return await _departmentService.Create(departmentDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<DepartmentDto> GetById(Guid id)
        {
            return await _departmentService.GetById(id);
        }
        [HttpGet]
        [Route("getMains")]
        public async Task<DepartmentViewModel> GetChildsByParentId(int page, int limit)
        {
            return await _departmentService.GetMainDepartments(page,limit);
        }
        [HttpGet]
        [Route("getChilds")]
        public async Task<DepartmentViewModel> GetChildsByParentId(int page, int limit, Guid id)
        {
            return await _departmentService.GetChildsByParentId(page, limit,id);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _departmentService.Delete(id);
            return NoContent();
        }
        [HttpPatch]
        [Route("assignParent/{id}")]
        public async Task<DepartmentDto> AssingParentToDepartment([FromBody] Guid parentId, Guid childId)
        {
            return await _departmentService.AssingParentToDepartment(childId, parentId);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<DepartmentDto> Update(Guid id, DepartmentDto departmentDto)
        {
            return await _departmentService.Update(id, departmentDto);
        }
    }
}
