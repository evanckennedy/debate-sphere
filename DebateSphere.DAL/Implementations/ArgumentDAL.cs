using DebateSphere.DAL.Interfaces;
using DebateSphere.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.DAL.Implementations
{
    public class ArgumentDAL : IArgumentDAL
    {
        private readonly AppDbContext _context;

        public ArgumentDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Argument> CreateArgumentAsync(Argument argument)
        {
            _context.Arguments.Add(argument);
            await _context.SaveChangesAsync();
            return argument;
        }

        public async Task<IEnumerable<Argument>> GetArgumentsByDebateIdAsync(int debateId)
        {
            return await _context.Arguments
                .Where(a => a.DebateID == debateId)
                .ToListAsync();
        }

        public async Task<Argument> GetArgumentByIdAsync(int argumentId)
        {
            return await _context.Arguments
                .FirstOrDefaultAsync(a => a.ArgumentID == argumentId);
        }

        public async Task<Argument> UpdateArgumentAsync(Argument argument)
        {
            _context.Arguments.Update(argument);
            await _context.SaveChangesAsync();
            return argument;
        }

        public async Task<bool> DeleteArgumentAsync(int argumentId)
        {
            var argument = await _context.Arguments.FindAsync(argumentId);
            if (argument == null)
            {
                return false;
            }
            _context.Arguments.Remove(argument);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
