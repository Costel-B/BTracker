using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models
{
    public class TicketPriority
    {
        [Key]
        public int TicketPriorityId { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        [Required]
        public string TicketPriorityName { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public ICollection<Ticket> Tickets { get; set; }
    }
}
