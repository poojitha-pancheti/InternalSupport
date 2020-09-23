using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternalSupport.Data;
using InternalSupport.Models;

namespace InternalSupport.Pages.SupportTicket
{
    public class EditModel : StatusPageModel
    {
        
        private readonly InternalSupport.Data.InternalSupportContext _context;

        public EditModel(InternalSupport.Data.InternalSupportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupportTickets SupportTickets { get; set; }
        public List<TicketStatus> TicketStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            
            SupportTickets = await _context.SupportTickets.FirstOrDefaultAsync(m => m.id== id);
            TicketStatus = await _context.TicketStatus.ToListAsync();
            var ticket = new SelectList(TicketStatus, "Id", "Status");
            ViewData["StatusList"] = ticket;
  
            if (SupportTickets == null)
            {
                return NotFound();
            }
            
         
            return Page();
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SupportTickets.Updated = DateTime.Now;
            SupportTickets.Status = Request.Form["StatusData"].ToString();
            _context.Attach(SupportTickets).State = EntityState.Modified;
            //_context.Attach(TicketStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketsExists(SupportTickets.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("./Index");
        }

        private bool SupportTicketsExists(int id)
        {
            return _context.SupportTickets.Any(e => e.id == id);
        }
        private bool TicketStatusExists(int id)
        {
            return _context.TicketStatus.Any(e => e.Id == id);

        }

    }
}
