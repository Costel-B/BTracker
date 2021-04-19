using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models
{
    /*
        Three access levels: Admin(1), User(2) and Guest(3)
    */
    public class AccessLevel
    {
        [Key]
        public int AccessLevelId { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        [Required]
        public string AccessName { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        // When creating a new ProjectAccess, is possible to see the already created accesses
        public ICollection<ProjectAccess> ProjectAccesses { get; set; }
    }
}
