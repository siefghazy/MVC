﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compant.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public bool? isActive { get; set; }


    }
}
