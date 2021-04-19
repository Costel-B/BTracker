using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Requirements
{
    public class ProjectAccessLevelRequirement : IAuthorizationRequirement
    {
        public int ProjectAccessLevel { get; set; }

        public ProjectAccessLevelRequirement(int projectAccessLevel)
        {
            ProjectAccessLevel = projectAccessLevel;
        }
    }
}
