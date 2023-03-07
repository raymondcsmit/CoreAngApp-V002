﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Data.Model
{
    public abstract class BaseEntity 
    {
        public int TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
