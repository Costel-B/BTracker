using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Views
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public IFormFile File { get; set; }
    }
}
