using BTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Project related models
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAccess> ProjectAccesses { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }

        // Section related models
        public DbSet<Section> Sections { get; set; }

        // Taske related models
        public DbSet<TaskePriority> TaskePriorities { get; set; }
        public DbSet<TaskeState> TaskeStates { get; set; }
        public DbSet<Taske> Taskes { get; set; }
    }
}
