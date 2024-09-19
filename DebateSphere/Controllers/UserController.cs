using AutoMapper;
using DebateSphere.BLL;
using DebateSphere.BLL.Interfaces;
using DebateSphere.Models;
using DebateSphere.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateSphere.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO userCreateDTO)
        {
            var userReadDTO = await _userService.RegisterUserAsync(userCreateDTO);
            return CreatedAtAction(nameof(GetUserById), new { userId = userReadDTO.UserID }, userReadDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var userReadDTO = await _userService.LoginUserAsync(userLoginDTO);
            return Ok(userReadDTO);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var userReadDTO = await _userService.GetUserByIdAsync(userId);
            if (userReadDTO == null)
            {
                return NotFound();
            }
            return Ok(userReadDTO);
        }

        [HttpPut("{userId}")]
        public async Task <IActionResult> UpdateUser(int userId, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            if (userId != userUpdateDTO.UserID)
            {
                return BadRequest("User ID mismatch");
            }

            await _userService.UpdateUserAsync(userUpdateDTO);
            return NoContent();
        }
    }
}
