using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Application.Abstract
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> Create(EmployeeDto employeeDto);
        Task<EmployeeDto> GetById(Guid id);
        Task<EmployeeDto> Update(Guid id, EmployeeDto employeeDto);
        Task Delete(Guid id);
        Task<EmployeeViewModel> GetByDepartmentIdAndPeriodDate(Guid deparmentId, DateTime startDate, DateTime endDate, int page, int limit);
    }
}
