﻿using DebateSphere.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.Models.DTOs
{
    public class ArgumentCreateDTO
    {
        public int DebateID { get; set; }
        public int PostedBy { get; set; }
        public Side Side { get; set; }
        public string Content { get; set; }
    }
}
