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
}
