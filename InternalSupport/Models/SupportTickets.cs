using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalSupport.Models
{
    public class SupportTickets
    {
       
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString ="{0:MMm dd}")]
        public DateTime created { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMm dd}")]
        public DateTime Updated { get; set; }
        public string Status { get; set; }
        
        public string Assigned { get; set; }
        
    }
    
}
