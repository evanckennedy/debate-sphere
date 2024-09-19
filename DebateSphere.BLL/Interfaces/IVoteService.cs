using DebateSphere.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.BLL.Interfaces
{
    public interface IVoteService
    {
        Task<VoteListDTO> CreateVoteAsync(VoteCreateDTO voteCreateDTO);
        Task<IEnumerable<VoteListDTO>> GetVotesByDebateIdAsync(int debateId);
    }
}
