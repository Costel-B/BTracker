using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        [Required]
        public string TicketName { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        // It will be possible to assign a final date until the project needs to be done
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public int SectionId { get; set; }
        public Section Section { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public int TicketStateId { get; set; }
        public TicketState TicketState { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public int TicketPriorityId { get; set; }
        public TicketPriority TicketPriority { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        // Assign a user to a certain project
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public bool IsDone { get; set; }
    }
}
