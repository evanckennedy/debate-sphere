using DebateSphere.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.BLL.Interfaces
{
    public interface IDebateService
    {
        Task<DebateReadDTO> CreateDebateAsync(DebateCreateDTO debateCreateDTO);
        Task<IEnumerable<DebateListDTO>> GetAllDebatesAsync();
        Task<DebateReadDTO> GetDebateByIdAsync(int debateId);
        Task<DebateReadDTO> UpdateDebateAsync(int debateId, DebateUpdateDTO debateUpdateDTO);
        Task<bool> DeleteDebateAsync(int debateId);
    }
}
