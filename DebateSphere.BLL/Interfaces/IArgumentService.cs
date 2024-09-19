using DebateSphere.Models;
using DebateSphere.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.BLL.Interfaces
{
    public interface IArgumentService
    {
        Task<ArgumentReadDTO> CreateArgumentAsync(ArgumentCreateDTO argumentCreateDTO);
        Task<IEnumerable<ArgumentListDTO>> GetArgumentsByDebateIdAsync(int debateId);
        Task<ArgumentReadDTO> GetArgumentByIdAsync(int argumentId);
        Task<ArgumentReadDTO> UpdateArgumentAsync(int argumentId, ArgumentUpdateDTO argumentUpdateDTO);
        Task<bool> DeleteArgumentAsync(int argumentId);
    }
}
