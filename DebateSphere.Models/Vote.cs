using DebateSphere.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models
{
    public class Vote
    {
        public int VoteID { get; set; } // primary key
        public int DebateID { get; set; } // foreign key referencing DebateID
        public int VoterID { get; set; } // foreign key referencing UserID
        public Side VotedSide { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Debate Debate { get; set; } // Many Votes belong to one Debate (Many-to-1)
        public User User { get; set; } // Many Votes are cast by one User (Many-to-1)
    }
}
