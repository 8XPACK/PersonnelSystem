using AutoMapper;
using PersonnelSystem.Application.Abstract;
using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;
using PersonnelSystem.Core.Abstract;
using PersonnelSystem.Core.Entities;
using PersonnelSystem.Core.Specifications;
using PersonnelSystem.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IMapper _mapper;
        private IRepository<Department> _repository;
        public DepartmentService(
            IMapper mapper,
            IRepository<Department> repository
            )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DepartmentDto> AssingParentToDepartment(Guid childId, Guid parentId)
        {
            var deparment = await _repository.GetByIdAsync(childId);
            deparment.ParentId = parentId;
            await _repository.UpdateAsync( deparment );
            deparment = await _repository.GetByIdAsync(deparment.Id);
            return _mapper.Map<DepartmentDto>(deparment);
        }

        public async Task<DepartmentDto> Create(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);

            department.Id = Guid.NewGuid();
            department.DateOfCreation = DateTime.Now;

            await _repository.AddAsync(department);

            department = await _repository.GetByIdAsync(department.Id);

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task Delete(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(department);
        }

        public async Task<DepartmentDto> GetById(Guid id)
        {
            var deparment = await _repository.GetByIdAsync(id);
            return _mapper.Map<DepartmentDto>(deparment);
        }
        public async Task<DepartmentViewModel> GetMainDepartments(int page, int limit)
        {
            var offset = (page - 1) * limit;

            var specification = new GetMainDepartmentsSpecifictaion(offset, limit);
            var departments = await _repository.ListAsync(specification);

            var pageViewModel = new PageViewModel(departments.Count, page, limit);
            return new DepartmentViewModel
            {
                Departments = _mapper.Map<IEnumerable<DepartmentDto>>(departments),
                PageInfo = pageViewModel
            };
        }
        public async Task<DepartmentViewModel> GetChildsByParentId(int page, int limit, Guid id)
        {
            var offset = (page - 1) * limit;


            var specification = new GetChildByParentIdSpecification(offset, limit, id);
            var departments = await _repository.ListAsync(specification);

            var pageViewModel = new PageViewModel(departments.Count, page, limit);
            return new DepartmentViewModel
            {
                Departments = _mapper.Map<IEnumerable<DepartmentDto>>(departments),
                PageInfo = pageViewModel
            };
        }

        public Task<DepartmentDto> Update(Guid id, DepartmentDto departmentDto)
        {
            throw new NotImplementedException();
        }
    }
}
