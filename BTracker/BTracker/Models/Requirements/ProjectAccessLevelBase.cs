using BTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Requirements
{
    public class ProjectAccessLevelBase : IProjectAccessLevel
    {
        private readonly ApplicationDbContext _context;

        public ProjectAccessLevelBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Get(string userId, string projectId)
        {
            int getProjectAccess = _context.ProjectAccesses.FirstOrDefault(x => x.UserId == userId && x.ProjectId.ToString() == projectId).AccessLevelId;

            return getProjectAccess;
        }
    }
}
