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
using Microsoft.AspNetCore.Authorization;

namespace BTracker.Controllers
{
    public class ProjectAccessesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProjectAccessesController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: ProjectAccesses
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.currentProjectId = id;
            var applicationDbContext = _context.ProjectAccesses.Where(x => x.ProjectId == id).Include(p => p.AccessLevel).Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectAccesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAccess = await _context.ProjectAccesses
                .Include(p => p.AccessLevel)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectAccessId == id);
            if (projectAccess == null)
            {
                return NotFound();
            }

            return View(projectAccess);
        }

        // GET: ProjectAccesses/Create
        [Authorize(Policy = "AdminAccess")]
        public IActionResult Create(int? id)
        {
            var currentUserId = _userManager.GetUserId(User);

            ViewBag.projectId = id;
            ViewData["AccessLevelId"] = new SelectList(_context.AccessLevels, "AccessLevelId", "AccessName");
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.Id != currentUserId), "Id", "Email");
            return View();
        }

        // POST: ProjectAccesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("ProjectAccessId,UserId,ProjectId,AccessLevelId")] ProjectAccess projectAccess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectAccess);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Projects", new { id = id });
            }
            ViewData["AccessLevelId"] = new SelectList(_context.AccessLevels, "AccessLevelId", "AccessName", projectAccess.AccessLevelId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", projectAccess.UserId);
            return View(projectAccess);
        }

        // GET: ProjectAccesses/Edit/5
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAccess = await _context.ProjectAccesses.FindAsync(id);
            if (projectAccess == null)
            {
                return NotFound();
            }
            ViewData["AccessLevelId"] = new SelectList(_context.AccessLevels, "AccessLevelId", "AccessName", projectAccess.AccessLevelId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", projectAccess.UserId);
            return View(projectAccess);
        }

        // POST: ProjectAccesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectAccessId,UserId,ProjectId,AccessLevelId")] ProjectAccess projectAccess)
        {
            if (id != projectAccess.ProjectAccessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectAccess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectAccessExists(projectAccess.ProjectAccessId))
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
            ViewData["AccessLevelId"] = new SelectList(_context.AccessLevels, "AccessLevelId", "AccessName", projectAccess.AccessLevelId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", projectAccess.UserId);
            return View(projectAccess);
        }

        // GET: ProjectAccesses/Delete/5
        [Authorize (Policy = "AdminAccess")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAccess = await _context.ProjectAccesses
                .Include(p => p.AccessLevel)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectAccessId == id);
            if (projectAccess == null)
            {
                return NotFound();
            }

            return View(projectAccess);
        }

        // POST: ProjectAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectAccess = await _context.ProjectAccesses.FindAsync(id);
            _context.ProjectAccesses.Remove(projectAccess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectAccessExists(int id)
        {
            return _context.ProjectAccesses.Any(e => e.ProjectAccessId == id);
        }
    }
}
