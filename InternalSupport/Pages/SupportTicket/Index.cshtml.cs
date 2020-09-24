using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternalSupport.Data;
using InternalSupport.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace InternalSupport.Pages.SupportTicket
{
    public class IndexModel : PageModel
    {
        private readonly InternalSupport.Data.InternalSupportContext _context;

        public IndexModel(InternalSupport.Data.InternalSupportContext context)
        {
            _context = context;
        }
      
        //  public IList<SupportTickets> SupportTickets { get;set; }
        public PaginatedList<SupportTickets> SupportTickets { get; set; }

        public async Task OnGetAsync(int? PageIndex)
        {

            IQueryable<SupportTickets> SupportTicketsIQ = from s in _context.SupportTickets
                                                          select s;

            int pageSize = 10;
            SupportTickets = await PaginatedList<SupportTickets>.CreateAsync(
                SupportTicketsIQ, PageIndex ?? 1, pageSize);
        }
       



    }
}
