using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDates = await _userService.GetById(id);
            if (userDates == null)
            {
                return NotFound();
            }
            return Ok(userDates);
        }
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.Create(user);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
