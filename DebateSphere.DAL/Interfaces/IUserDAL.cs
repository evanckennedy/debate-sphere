using DebateSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.DAL.Interfaces
{
    public interface IUserDAL
    {
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User> AuthenticateUserAsync(string email, string password);
    }
}
