using DebateSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.DAL.Interfaces
{
    public interface IArgumentDAL
    {
        Task<Argument> CreateArgumentAsync(Argument argument);
        Task<IEnumerable<Argument>> GetArgumentsByDebateIdAsync(int debateId);
        Task<Argument> GetArgumentByIdAsync(int argumentId);
        Task<Argument> UpdateArgumentAsync(Argument argument);
        Task<bool> DeleteArgumentAsync(int argumentId);
    }
}
