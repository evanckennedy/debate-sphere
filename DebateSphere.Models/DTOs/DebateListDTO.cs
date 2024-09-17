using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models.DTOs
{
    public class DebateListDTO
    {
        public int DebateID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
