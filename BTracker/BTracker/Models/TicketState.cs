using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models
{
    public class TicketState
    {
        [Key]
        public int TicketStateId { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        [Required]
        public string TicketStateName { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public ICollection<Ticket> Tickets { get; set; }
    }
}