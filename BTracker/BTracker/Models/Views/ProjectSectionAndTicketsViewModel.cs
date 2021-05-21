using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Views
{
    public class ProjectSectionAndTicketsViewModel
    {
        public Project Project { get; set; }
        public string UserId { get; set; }
        public List<ProjectAccess> ProjectAccesses { get; set; }
        public List<Section> Sections { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
