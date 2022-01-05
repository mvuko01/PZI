﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reView.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Review> Review { get; set; }
    }
}
