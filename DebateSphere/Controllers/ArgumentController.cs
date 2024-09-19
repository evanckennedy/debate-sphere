using DebateSphere.BLL;
using DebateSphere.BLL.Interfaces;
using DebateSphere.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateSphere.Controllers
{
    [Route("api/arguments")]
    [ApiController]
    public class ArgumentController : ControllerBase
    {
        private readonly IArgumentService _argumentService;

        public ArgumentController(IArgumentService argumentService)
        {
            _argumentService = argumentService;
        }

        [HttpPost("/api/debates/{debateId}/arguments")]
        public async Task<IActionResult> CreateArgument(int debateId, ArgumentCreateDTO argumentCreateDTO)
        {
            argumentCreateDTO.DebateID = debateId;
            var argument = await _argumentService.CreateArgumentAsync(argumentCreateDTO);
            return CreatedAtAction(nameof(GetArgumentById), new { argumentId = argument.ArgumentID }, argument);
        }

        [HttpGet("/api/debates/{debateId}/arguments")]
        public async Task<IActionResult> GetArgumentsByDebateId(int debateId)
        {
            var arguments = await _argumentService.GetArgumentsByDebateIdAsync(debateId);
            return Ok(arguments);
        }

        [HttpGet("{argumentId}")]
        public async Task<IActionResult> GetArgumentById(int argumentId)
        {
            var argument = await _argumentService.GetArgumentByIdAsync(argumentId);
            if (argument == null)
            {
                return NotFound();
            }
            return Ok(argument);
        }

        [HttpPut("{argumentId}")]
        public async Task<IActionResult> UpdateArgument(int argumentId, ArgumentUpdateDTO argumentUpdateDTO)
        {
            var argument = await _argumentService.UpdateArgumentAsync(argumentId, argumentUpdateDTO);
            if (argument == null)
            {
                return NotFound();
            }
            return Ok(argument);
        }

        [HttpDelete("{argumentId}")]
        public async Task<IActionResult> DeleteArgument(int argumentId)
        {
            var result = await _argumentService.DeleteArgumentAsync(argumentId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
