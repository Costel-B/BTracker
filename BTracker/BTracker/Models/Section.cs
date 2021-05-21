using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        [Required]
        public string SectionName { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public string ToUserId { get; set; }
        public IdentityUser ToUser { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public ICollection<Ticket> Tickets { get; set; }
    }
}
