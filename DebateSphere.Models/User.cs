using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models
{
    public class User
    {
        public int UserID { get; set; } // primary key
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<Debate> Debates { get; set; } // One User can create many Debates (1-to-Many)
        public ICollection<Argument> Arguments { get; set; } // One User can post many Arguments (1-to-Many
        public ICollection<Vote> Votes { get; set; } // One User can vote many times (1-to-Many)

    }
}
