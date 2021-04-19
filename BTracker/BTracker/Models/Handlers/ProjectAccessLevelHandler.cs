using BTracker.Models.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BTracker.Models.Handlers
{
    public class ProjectAccessLevelHandler : AuthorizationHandler<ProjectAccessLevelRequirement>
    {
        private readonly IProjectAccessLevel _projectAccessLevel;
        private readonly IHttpContextAccessor _accessor;

        public ProjectAccessLevelHandler(IProjectAccessLevel projectAccessLevel,
            IHttpContextAccessor accessor)
        {
            _projectAccessLevel = projectAccessLevel;
            _accessor = accessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProjectAccessLevelRequirement requirement)
        {
            var currentUserId = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Request id from url. The project id
            var projectId = _accessor.HttpContext.Request.RouteValues["Id"].ToString();
            var getAccessLevel = _projectAccessLevel.Get(currentUserId, projectId);

            if (getAccessLevel == requirement.ProjectAccessLevel)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
