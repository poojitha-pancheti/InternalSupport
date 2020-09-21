using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InternalSupport.Data;
using InternalSupport.Models;

namespace InternalSupport.Pages.SupportTicket
{
    public class CreateModel : PageModel
    {
        private readonly InternalSupport.Data.InternalSupportContext _context;

        public CreateModel(InternalSupport.Data.InternalSupportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        [BindProperty]
        public SupportTickets SupportTickets { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           

            SupportTickets.created = DateTime.Now;



            _context.SupportTickets.Add(SupportTickets);
            await _context.SaveChangesAsync();



            return RedirectToPage("./Response");
        }
        
    }
}
