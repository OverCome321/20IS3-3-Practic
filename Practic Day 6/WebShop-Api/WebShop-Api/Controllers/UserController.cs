using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebShop_Api.Contracts.User;
using Mapster;

namespace WebShop_Api.Controllers
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
        /// <summary>
        ///Просмотр записей в бд
        /// </summary>
        // POST api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        ///Просмотр записи по id
        /// </summary>
        // POST api/<UsersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse();
            var responseResult = response.Adapt<User>();
            return Ok(responseResult);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        ///         Email : "coolmail@mail.ru",
        ///         Login : "231ffdg",
        ///         Password : "!Pa$$word123@",
        ///         RoleId : 1,
        ///         IsDeleted : 0,
        ///         Adress : "Любой"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///         UserId : 1
        ///         Email : "coolmail@mail.ru",
        ///         Login : "231ffdg",
        ///         Password : "!Pa$$word123@",
        ///         RoleId : 1,
        ///         IsDeleted : 0,
        ///         Adress : "Любой"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserResponse response)
        {
            var user = response.Adapt<User>();
            await _userService.Update(user);
            return Ok();
        }
        /// <summary>
        ///удаление записи по id
        /// </summary>
        // POST api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}