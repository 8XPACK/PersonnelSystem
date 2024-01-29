using AutoMapper;
using PersonnelSystem.Application.Abstract;
using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;
using PersonnelSystem.Core.Abstract;
using PersonnelSystem.Core.Entities;
using PersonnelSystem.Core.Specifications;
using PersonnelSystem.Core.ViewModels;

namespace PersonnelSystem.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IMapper _mapper;
        private IRepository<Employee> _repository;
        public EmployeeService(
            IMapper mapper, 
            IRepository<Employee> repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<EmployeeDto> Create(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.DateOfEmployment = DateTime.Now;
            await _repository.AddAsync(employee);
            return await GetById(employee.UserId);
        }

        public async Task Delete(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(employee);
        }

        public async Task<EmployeeViewModel> GetByDepartmentIdAndPeriodDate(Guid deparmentId, DateTime startDate, DateTime endDate, int page, int limit)
        {
            var offset = (page - 1) * limit;

            var spec = new GetUsersByDepartmentIdAndPeriodDateSpecification(deparmentId, startDate, endDate, offset, limit);
            var employees = await _repository.ListAsync(spec);

            var pageViewModel = new PageViewModel(employees.Count, page, limit);

            return new EmployeeViewModel
            {
                PageInfo = pageViewModel,
                Users = _mapper.Map<IEnumerable<EmployeeDto>>(employees)
            };

        }

        public async Task<EmployeeDto> GetById(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(user);
        }

        public Task<EmployeeDto> Update(Guid id, EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
