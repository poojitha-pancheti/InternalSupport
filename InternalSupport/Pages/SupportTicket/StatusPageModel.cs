using InternalSupport.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalSupport.Pages.SupportTicket
{
    public class StatusPageModel:PageModel
    {
        public SelectList StatusSL { get; set; }

        public void PopulateStatusDropDownList(InternalSupportContext _context,
            object selectedStatus = null)
        {
            var StatusQuery = from d in _context.SupportTickets
                              orderby d.id // Sort by name.
                              select d;

            StatusSL = new SelectList(StatusQuery.AsNoTracking(),
                         "StatusID", "Status", selectedStatus);
        }

    }
}
