using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models.DTOs
{
    public class DebateCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
    }

    public class DebateListDTO
    {
        public int DebateID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class DebateReadDTO
    {
        public int DebateID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<ArgumentListDTO> Arguments { get; set; }
        public ICollection<VoteListDTO> Votes { get; set; }
    }

    public class DebateUpdateDTO
    {
        public int DebateID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
