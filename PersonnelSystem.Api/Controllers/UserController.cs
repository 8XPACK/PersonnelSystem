using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelSystem.Application.Abstract;
using PersonnelSystem.Application.Objects;
using PersonnelSystem.Application.ViewModels;

namespace PersonnelSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("")]
        public async Task<UserDto> Create(UserDto userDto)
        {
            return await _userService.Create(userDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> GetById(Guid id)
        {
            return await _userService.GetById(id);
        }
        [HttpGet]
        [Route("")]
        public async Task<UserViewModel> GetPaged(int page, int limit)
        {
            return await _userService.GetPaged(page,limit);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<UserDto> Update(Guid id, [FromBody] UserDto userDto)
        {
            return await _userService.Update(id, userDto);
        }
    }
}
