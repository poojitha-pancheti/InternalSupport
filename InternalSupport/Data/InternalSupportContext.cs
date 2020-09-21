﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternalSupport.Models;

namespace InternalSupport.Data
{
    public class InternalSupportContext : DbContext
    {
        public InternalSupportContext (DbContextOptions<InternalSupportContext> options)
            : base(options)
        {
        }

        public DbSet<InternalSupport.Models.SupportTickets> SupportTickets { get; set; }
    }
}