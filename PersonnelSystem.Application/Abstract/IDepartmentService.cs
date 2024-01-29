using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Application.Abstract
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> Create(DepartmentDto departmentDto);
        Task<DepartmentDto> Update(Guid id, DepartmentDto departmentDto);
        Task Delete(Guid id);
        Task<DepartmentDto> GetById(Guid id);
        Task<DepartmentDto> AssingParentToDepartment(Guid childId, Guid parentId);
        Task<DepartmentViewModel> GetChildsByParentId(int page, int limit, Guid id);
        Task<DepartmentViewModel> GetMainDepartments(int page, int limit);
    }
}
