using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InternalSupport.Data;
using InternalSupport.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace InternalSupport.Pages.SupportTicket
{
    public class CreateModel : PageModel
    {
        private readonly InternalSupport.Data.InternalSupportContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CreateModel(InternalSupport.Data.InternalSupportContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (filee != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "files");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + filee.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    filee.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [BindProperty]
        public SupportTickets SupportTickets { get; set; }
        public IFormFile filee { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            SupportTickets.created = DateTime.Now;
            SupportTickets.Updated = null;
            SupportTickets.Status = "Pending";
            SupportTickets.pathFile = ProcessUploadedFile();


            _context.SupportTickets.Add(SupportTickets);
            await _context.SaveChangesAsync();



            return RedirectToPage("./Response");
        }

    }
   
}
