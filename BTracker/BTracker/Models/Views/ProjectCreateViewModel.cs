using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Views
{
    public class ProjectCreateViewModel
    {
        [Key]
        public int ProjectId { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        [Required]
        public string ProjectName { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public string ProjectSmallBrief { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public string ProjectBrief { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public IFormFile File { get; set; }
        public string FileUrl { get; set; }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        // When is created a new project, the current user is the owner
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
