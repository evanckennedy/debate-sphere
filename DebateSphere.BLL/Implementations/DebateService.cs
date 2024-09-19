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
    public class DebateService : IDebateService
    {
        private readonly IDebateDAL _debateDAL;
        private readonly IMapper _mapper;

        public DebateService(IDebateDAL debateDAL, IMapper mapper)
        {
            _debateDAL = debateDAL;
            _mapper = mapper;
        }

        public async Task<DebateReadDTO> CreateDebateAsync(DebateCreateDTO debateCreateDTO)
        {
            var debate = _mapper.Map<Debate>(debateCreateDTO);
            debate.CreatedAt = DateTime.UtcNow;
            var createdDebate = await _debateDAL.CreateDebateAsync(debate);
            return _mapper.Map<DebateReadDTO>(createdDebate);
        }

        public async Task<IEnumerable<DebateListDTO>> GetAllDebatesAsync()
        {
            var debates = await _debateDAL.GetAllDebatesAsync();
            return _mapper.Map<IEnumerable<DebateListDTO>>(debates);
        }

        public async Task<DebateReadDTO> GetDebateByIdAsync(int debateId)
        {
            var debate = await _debateDAL.GetDebateByIdAsync(debateId);
            return _mapper.Map<DebateReadDTO>(debate);
        }

        public async Task<DebateReadDTO> UpdateDebateAsync(int debateId, DebateUpdateDTO debateUpdateDTO)
        {
            var debate = _mapper.Map<Debate>(debateUpdateDTO);
            debate.DebateID = debateId;
            var updatedDebate = await _debateDAL.UpdateDebateAsync(debate);
            return _mapper.Map<DebateReadDTO>(updatedDebate);
        }

        public async Task<bool> DeleteDebateAsync(int debateId)
        {
            return await _debateDAL.DeleteDebateAsync(debateId);
        }
    }
}
