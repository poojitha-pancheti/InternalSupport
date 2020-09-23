using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternalSupport.Data;
using InternalSupport.Models;

namespace InternalSupport.Pages.SupportTicket
{
    public class IndexModel : PageModel
    {
        private readonly InternalSupport.Data.InternalSupportContext _context;

        public IndexModel(InternalSupport.Data.InternalSupportContext context)
        {
            _context = context;
        }

        public IList<SupportTickets> SupportTickets { get;set; }

        public async Task OnGetAsync()
        {
            
            SupportTickets = await _context.SupportTickets.ToListAsync();
            //TicketStatus = await _context.TicketStatus.ToListAsync();
        }
    }
}
