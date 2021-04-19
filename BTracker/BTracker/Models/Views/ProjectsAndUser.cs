using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Views
{
    public class ProjectsAndUser
    {
        public List<Project> Projects { get; set; }
        public string UserId { get; set; }
    }
}
