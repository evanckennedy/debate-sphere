using DebateSphere.BLL.Interfaces;
using DebateSphere.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateSphere.Controllers
{
    [Route("api/votes")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost("/api/debates/{debateId}/vote")]
        public async Task<IActionResult> CreateVote(int debateId, VoteCreateDTO voteCreateDTO)
        {
            voteCreateDTO.DebateID = debateId;
            var vote = await _voteService.CreateVoteAsync(voteCreateDTO);
            return CreatedAtAction(nameof(GetVotesByDebateId), new { debateId = vote.DebateID }, vote);
        }

        [HttpGet("/api/debates/{debateId}/votes")]
        public async Task<IActionResult> GetVotesByDebateId(int debateId)
        {
            var votes = await _voteService.GetVotesByDebateIdAsync(debateId);
            return Ok(votes);
        }
    }
}
