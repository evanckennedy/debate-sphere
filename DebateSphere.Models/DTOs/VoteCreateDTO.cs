using DebateSphere.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models.DTOs
{
    public class VoteCreateDTO
    {
        public int DebateID { get; set; }
        public int VoterID { get; set; }
        public Side VotedSide { get; set; }
    }
}
