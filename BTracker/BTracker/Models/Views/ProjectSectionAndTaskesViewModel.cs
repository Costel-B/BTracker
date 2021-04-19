using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Views
{
    public class ProjectSectionAndTaskesViewModel
    {
        public Project Project { get; set; }
        public List<Section> Sections { get; set; }
        public List<Taske> Taskes { get; set; }
    }
}
