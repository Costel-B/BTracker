using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTracker.Data;
using BTracker.Models;
using Microsoft.AspNetCore.Identity;
using BTracker.Models.Views;
using Microsoft.AspNetCore.Authorization;

namespace BTracker.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProjectsController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index(IdentityUser user)
        {
            var currentUserId = _userManager.GetUserId(User);
            ViewBag.currentUserId = currentUserId;

            // Gets all the projects ids that I have access from ProjectAccesses
            List<int> projectsThatIHaveAccess = (from pA in _context.ProjectAccesses
                                                 where pA.UserId == currentUserId
                                                 select pA.ProjectId).ToList();

            // With the id of the projects that I have access, use the id and show the project with that id
            var getTheProjects = await (from getP in _context.Projects
                                  where projectsThatIHaveAccess.Contains(getP.ProjectId)
                                  select getP).Include(x => x.User).ToListAsync();

            var projectsAndUser = new ProjectsAndUser()
            {
                UserId = currentUserId,
                Projects = getTheProjects
            };

            return View(projectsAndUser);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.currentUserId = _userManager.GetUserId(User);

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectId == id);

            var sections = _context.Sections.Where(x => x.ProjectId == id).ToList();

            var taskesFromSection = _context.Sections.Where(x => x.ProjectId == id.Value).SelectMany(x => x.Taskes).OrderBy(x => x.Section).ToList();

            var projectSectionAndTaskes = new ProjectSectionAndTaskesViewModel()
            {
                Project = project,
                Sections = sections,
                Taskes = taskesFromSection
            };

            if (project == null)
            {
                return NotFound();
            }

            return View(projectSectionAndTaskes);
        }

        // Partial to see the sections of the current project
        public IActionResult _SeeSectionProject()
        {
            return PartialView("_SeeSectionProject");
        }

        // Partial to see the tasks of the sections of the current project
        public IActionResult _SeeTaskeSection()
        {
            return PartialView("_SeeTaskeSection");
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            var currentUserId = _userManager.GetUserId(User);
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.Id == currentUserId), "Id", "Email");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,UserId")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();

                var projectAccess = new ProjectAccess()
                {
                    ProjectId = project.ProjectId,
                    UserId = project.UserId,
                    AccessLevelId = 1
                };
                _context.ProjectAccesses.Add(projectAccess);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", project.UserId);
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.currentUserId = _userManager.GetUserId(User);

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", project.UserId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,UserId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", project.UserId);
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.currentUserId = _userManager.GetUserId(User);

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
