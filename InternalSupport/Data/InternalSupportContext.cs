using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternalSupport.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalSupport.Data
{
    public class InternalSupportContext : DbContext
    {
        public InternalSupportContext(DbContextOptions<InternalSupportContext> options)
            : base(options)
        {
        }

        public DbSet<InternalSupport.Models.SupportTickets> SupportTickets { get; set; }
        public DbSet<InternalSupport.Models.TicketStatus> TicketStatus { get; set; }
        public DbSet<InternalSupport.Models.TicketAssigned> TicketAssigned { get; set; }

    }
}