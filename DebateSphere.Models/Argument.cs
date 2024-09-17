using DebateSphere.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models
{
    public class Argument
    {
        public int ArgumentID { get; set; } // primary key
        public int DebateID { get; set; } // foreign key referencing DebateID
        public int PostedBy { get; set; } // foreign key referencing UserID
        public Side Side { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Debate Debate { get; set; } // Many Arguments belong to one Debate (Many-to-1)
        public User User { get; set; } // Many Arguments are posted by one User (Many-to-1)
    }
}
