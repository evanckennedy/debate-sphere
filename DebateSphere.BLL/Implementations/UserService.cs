using AutoMapper;
using DebateSphere.BLL.Interfaces;
using DebateSphere.DAL.Interfaces;
using DebateSphere.Models;
using DebateSphere.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.BLL.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;

        public UserService(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public async Task<UserReadDTO> RegisterUserAsync(UserCreateDTO userCreateDTO)
        {
            var user = _mapper.Map<User>(userCreateDTO);
            user.CreatedAt = DateTime.UtcNow;
            await _userDAL.AddUserAsync(user);
            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task<UserReadDTO> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _userDAL.AuthenticateUserAsync(userLoginDTO.Email, userLoginDTO.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }
            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task<UserReadDTO> GetUserByIdAsync(int id)
        {
            var user = await _userDAL.GetUserByIdAsync(id);
            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task UpdateUserAsync(UserUpdateDTO userUpdateDTO)
        {
            var user = await _userDAL.GetUserByIdAsync(userUpdateDTO.UserID);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            // Update fields
            user.Username = userUpdateDTO.Username;
            user.Email = userUpdateDTO.Email;
            user.Password = userUpdateDTO.Password; // Add this line

            await _userDAL.UpdateUserAsync(user);
        }
    }
}
