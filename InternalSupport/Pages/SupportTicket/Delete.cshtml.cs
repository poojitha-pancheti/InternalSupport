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
    public class DeleteModel : PageModel
    {
        private readonly InternalSupport.Data.InternalSupportContext _context;

        public DeleteModel(InternalSupport.Data.InternalSupportContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupportTickets = await _context.SupportTickets.FindAsync(id);

            if (SupportTickets != null)
            {
                _context.SupportTickets.Remove(SupportTickets);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
