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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Application.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IRepository<User> _repository;
        public UserService(
            IMapper mapper, 
            IRepository<User> repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<UserDto> Create(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid();
            await _repository.AddAsync(user);
            return await GetById(user.Id);
        }

        public async Task Delete(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(user);
        }

        public async Task<UserDto> GetById(Guid id)
        {
             return _mapper.Map<UserDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<UserViewModel> GetPaged(int page, int limit)
        {
            var offset = (page - 1) * limit;

            var spec = new BasePagedSpecification<User>(offset, limit);
            var users = await _repository.ListAsync(spec);

            var pagedViewModel = new PageViewModel(users.Count, page, limit);
            return new UserViewModel {
                PageInfo = pagedViewModel,
                Users = _mapper.Map<IEnumerable<UserDto>>(users) 
            };
        }

        public async Task<UserDto> Update(Guid id, UserDto userDto)
        {
            var user = await _repository.GetByIdAsync(id);

            user.Surname = userDto.Surname;
            user.Name = userDto.Name;
            user.Patronymic = userDto.Patronymic;

            await _repository.UpdateAsync(user);

            user = await _repository.GetByIdAsync(id);

            return _mapper.Map<UserDto>(user);
        }
    }
}
