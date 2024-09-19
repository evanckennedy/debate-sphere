using DebateSphere.BLL.Interfaces;
using DebateSphere.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateSphere.Controllers
{
    [Route("api/debates")]
    [ApiController]
    public class DebateController : ControllerBase
    {
        private readonly IDebateService _debateService;

        public DebateController (IDebateService debateService)
        {
            _debateService = debateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDebate(DebateCreateDTO debateCreateDTO)
        {
            var debate = await _debateService.CreateDebateAsync(debateCreateDTO);
            return CreatedAtAction(nameof(GetDebateById), new { debateId = debate.DebateID }, debate);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDebates()
        {
            var debates = await _debateService.GetAllDebatesAsync();
            return Ok(debates);
        }

        [HttpGet("{debateId}")]
        public async Task<IActionResult> GetDebateById(int debateId)
        {
            var debate = await _debateService.GetDebateByIdAsync(debateId);
            if (debate == null)
            {
                return NotFound();
            }
            return Ok(debate);
        }

        [HttpPut("{debateId}")]
        public async Task<IActionResult> UpdateDebate(int debateId, DebateUpdateDTO debateUpdateDTO)
        {
            var debate = await _debateService.UpdateDebateAsync(debateId, debateUpdateDTO);
            if (debate == null)
            {
                return NotFound();
            }
            return Ok(debate);
        }

        [HttpDelete("{debateId}")]
        public async Task<IActionResult> DeleteDebate(int debateId)
        {
            var result = await _debateService.DeleteDebateAsync(debateId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
