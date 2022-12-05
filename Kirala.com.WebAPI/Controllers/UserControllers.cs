using Kirala.com.Business.Abstract;
using Kirala.com.Entities.Dto_s.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kirala.com.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        IUserManager _userManager;
        public UserControllers(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("([Action])")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            return Ok(await _userManager.Login(userLoginDto));
        }

        [HttpPost]
        [Route("([Action])")]
        public async Task<IActionResult> Create(UserRegisterDto userRegister)
        {
            if (userRegister != null)
                return Ok(await _userManager.Create(userRegister));
            return NotFound();
        }

        [HttpPut]
        [Route("([Action])")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdate)
        {
            if (userUpdate != null)
                return Ok(await _userManager.Update(userUpdate));
            return NotFound();
        }

        [HttpDelete]
        [Route("([Action])")]
        public async Task<IActionResult> Delete(UserDto user)
        {
            if (user != null)
                return Ok(await _userManager.Delete(user));
            return NotFound();
        }

        [HttpDelete]
        [Route("([Action]/{id})")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await _userManager.DeleteById(id));
        }

        [HttpGet]
        [Route("([Action])")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userManager.GetAll();
            if (users != null)
                return Ok(users.Data);
            return NotFound();
        }

        [HttpGet]
        [Route("([Action]/{id})")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userManager.GetById(id);
            if (user != null)
                return Ok(user.Data);
            return NotFound();
        }
    }
}
