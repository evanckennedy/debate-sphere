using DebateSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.DAL.Interfaces
{
    public interface IDebateDAL
    {
        Task<Debate> CreateDebateAsync(Debate debate);
        Task<IEnumerable<Debate>> GetAllDebatesAsync();
        Task<Debate> GetDebateByIdAsync(int debateId);
        Task<Debate> UpdateDebateAsync(Debate debate);
        Task<bool> DeleteDebateAsync(int debateId);
    }
}
