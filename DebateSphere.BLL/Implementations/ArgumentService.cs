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
    public class ArgumentService : IArgumentService
    {
        private readonly IArgumentDAL _argumentDAL;
        private readonly IMapper _mapper;

        public ArgumentService(IArgumentDAL argumentDAL, IMapper mapper)
        {
            _argumentDAL = argumentDAL;
            _mapper = mapper;
        }

        public async Task<ArgumentReadDTO> CreateArgumentAsync(ArgumentCreateDTO argumentCreateDTO)
        {
            var argument = _mapper.Map<Argument>(argumentCreateDTO);
            argument.CreatedAt = DateTime.UtcNow;
            var createdArgument = await _argumentDAL.CreateArgumentAsync(argument);
            return _mapper.Map<ArgumentReadDTO>(argument);
        }

        public async Task<IEnumerable<ArgumentListDTO>> GetArgumentsByDebateIdAsync(int debateId)
        {
            var arguments = await _argumentDAL.GetArgumentsByDebateIdAsync(debateId);
            return _mapper.Map<IEnumerable<ArgumentListDTO>>(arguments);
        }

        public async Task<ArgumentReadDTO> GetArgumentByIdAsync(int argumentId)
        {
            var argument = await _argumentDAL.GetArgumentByIdAsync(argumentId);
            return _mapper.Map<ArgumentReadDTO>(argument);
        }

        public async Task<ArgumentReadDTO> UpdateArgumentAsync(int argumentId, ArgumentUpdateDTO argumentUpdateDTO)
        {
            var existingArgument = await _argumentDAL.GetArgumentByIdAsync(argumentId);
            if (existingArgument == null)
            {
                return null;
            }

            // Map the updated properties
            existingArgument.DebateID = argumentUpdateDTO.DebateID;
            existingArgument.PostedBy = argumentUpdateDTO.PostedBy;
            existingArgument.Side = argumentUpdateDTO.Side;
            existingArgument.Content = argumentUpdateDTO.Content;

            var updatedArgument = await _argumentDAL.UpdateArgumentAsync(existingArgument);
            return _mapper.Map<ArgumentReadDTO>(updatedArgument);
        }

        public async Task<bool> DeleteArgumentAsync(int argumentId)
        {
            return await _argumentDAL.DeleteArgumentAsync(argumentId);
        }
    }
}