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
    public class DebateDAL : IDebateDAL
    {
        private readonly AppDbContext _context;

        public DebateDAL (AppDbContext context)
        {
            _context = context;
        }

        public async Task<Debate> CreateDebateAsync(Debate debate)
        {
            _context.Debates.Add(debate);
            await _context.SaveChangesAsync();
            return debate;
        }

        public async Task<IEnumerable<Debate>> GetAllDebatesAsync()
        {
            return await _context.Debates.ToListAsync();
        }

        public async Task<Debate> GetDebateByIdAsync(int debateId)
        {
            return await _context.Debates
                .Include(d => d.Arguments)
                .Include(d => d.Votes)
                .FirstOrDefaultAsync(d => d.DebateID == debateId);
        }

        public async Task<Debate> UpdateDebateAsync(Debate debate)
        {
            _context.Debates.Update(debate);
            await _context.SaveChangesAsync();
            return debate;
        }

        public async Task<bool> DeleteDebateAsync(int DebateId)
        {
            var debate = await _context.Debates.FindAsync(DebateId);
            if (debate == null)
            {
                return false;
            }
            _context.Debates.Remove(debate);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
