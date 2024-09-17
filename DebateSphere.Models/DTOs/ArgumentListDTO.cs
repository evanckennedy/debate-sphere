using DebateSphere.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models.DTOs
{
    public class ArgumentListDTO
    {
        public int ArgumentID { get; set; }
        public int DebateID { get; set; }
        public Side Side { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
