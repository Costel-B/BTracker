using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.Models.Requirements
{
    public interface IProjectAccessLevel
    {
        int Get(string userId, string projectId);
    }
}
