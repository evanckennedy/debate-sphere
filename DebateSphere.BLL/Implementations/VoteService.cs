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
    public class VoteService : IVoteService
    {
        private readonly IVoteDAL _voteDAL;
        private readonly IMapper _mapper;

        public VoteService(IVoteDAL voteDAL, IMapper mapper)
        {
            _voteDAL = voteDAL;
            _mapper = mapper;
        }

        public async Task<VoteListDTO> CreateVoteAsync(VoteCreateDTO voteCreateDTO)
        {
            var vote = _mapper.Map<Vote>(voteCreateDTO);
            vote.CreatedAt = DateTime.UtcNow;
            var createdVote = await _voteDAL.CreateVoteAsync(vote);
            return _mapper.Map<VoteListDTO>(createdVote);
        }

        public async Task<IEnumerable<VoteListDTO>> GetVotesByDebateIdAsync(int debateId)
        {
            var votes = await _voteDAL.GetVotesByDebateIdAsync(debateId);
            return _mapper.Map<IEnumerable<VoteListDTO>>(votes);
        }
    }
}
