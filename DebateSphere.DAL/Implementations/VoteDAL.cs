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
    public class VoteDAL: IVoteDAL
    {
        private readonly AppDbContext _context;

        public VoteDAL (AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vote> CreateVoteAsync(Vote vote)
        {
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return vote;
        }

        public async Task<IEnumerable<Vote>> GetVotesByDebateIdAsync(int debateId)
        {
            return await _context.Votes
                .Where(v => v.DebateID == debateId)
                .ToListAsync();
        }
    }
}
