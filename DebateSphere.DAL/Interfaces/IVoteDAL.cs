using DebateSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.DAL.Interfaces
{
    public interface IVoteDAL
    {
        Task<Vote> CreateVoteAsync(Vote vote);
        Task<IEnumerable<Vote>> GetVotesByDebateIdAsync(int debateId);
    }
}
