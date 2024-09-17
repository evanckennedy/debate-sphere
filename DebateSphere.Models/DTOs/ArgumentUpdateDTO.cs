using DebateSphere.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models.DTOs
{
    public class ArgumentUpdateDTO
    {
        public Side Side { get; set; }
        public string Content { get; set; }
    }
}
