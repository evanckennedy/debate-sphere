using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models.DTOs
{
    public class DebateReadDTO
    {
        public int DebateID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public List<ArgumentReadDTO> Arguments { get; set; }
        public List<VoteReadDTO> Votes { get; set; }
    }
}
