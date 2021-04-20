using BTracker.Data;
using BTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.ViewComponents
{
    public class ListProjectsViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext context;
        public ListProjectsViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            // Gets list of all the projects ids that I have access from ProjectAccess
            List<int> projectsThatIHaveAccess = (from pA in context.ProjectAccesses
                                                 where pA.UserId == userId
                                                 select pA.ProjectId).ToList();

            // With the id of the projects that I have access, use the id and show the project with that id
            var getTheProject = (from getP in context.Projects
                                 where projectsThatIHaveAccess.Contains(getP.ProjectId)
                                 select getP).Include(x => x.User).OrderBy(x => x.ProjectName).ToList();

            return await Task.FromResult((IViewComponentResult)View("ListProjects", getTheProject));
        }
    }
}
