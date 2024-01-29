using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Application.Abstract
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto userDto);
        Task<UserDto> Update(Guid id, UserDto userDto);
        Task Delete(Guid id);
        Task<UserDto> GetById(Guid id);
        Task<UserViewModel> GetPaged(int page, int limit);
    }
}
