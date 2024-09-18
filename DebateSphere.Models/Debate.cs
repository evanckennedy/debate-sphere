using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models
{
    public class Debate
    {
        public int DebateID { get; set; } // primary key
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; } // foreign key referencing UserID
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User User { get; set; } // Many Debates are created by one User (Many-to-1)
        public ICollection<Argument> Arguments { get; set; } // One Debate can have many Arguments (1-to-Many)
        public ICollection<Vote> Votes { get; set; } // One Debate can have many Votes (1-to-Many)
    }
}
