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
    public class DetailsModel : PageModel
    {
        private readonly InternalSupport.Data.InternalSupportContext _context;

        public DetailsModel(InternalSupport.Data.InternalSupportContext context)
        {
            _context = context;
        }

        public SupportTickets SupportTickets { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupportTickets = await _context.SupportTickets.AsNoTracking().FirstOrDefaultAsync(m => m.id == id);

            if (SupportTickets == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
