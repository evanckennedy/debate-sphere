using DebateSphere.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserReadDTO> RegisterUserAsync(UserCreateDTO userCreateDTO);
        Task<UserReadDTO> LoginUserAsync(UserLoginDTO userLoginDTO);
        Task<UserReadDTO> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserUpdateDTO userUpdateDTO);
    }
}
