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
    public class TaskesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TaskesController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Taskes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Taskes.Include(t => t.Section).Include(t => t.TaskePriority).Include(t => t.TaskeState).Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Taskes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taske = await _context.Taskes
                .Include(t => t.Section)
                .Include(t => t.TaskePriority)
                .Include(t => t.TaskeState)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskeId == id);
            if (taske == null)
            {
                return NotFound();
            }

            return View(taske);
        }

        // GET: Taskes/Create
        [Authorize (Policy = "AdminAccess")]
        public IActionResult Create(int? id, int? sectionId)
        {
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.SectionId == sectionId), "SectionId", "SectionName");
            ViewData["TaskePriorityId"] = new SelectList(_context.TaskePriorities, "TaskePriorityId", "TaskePriorityName");
            ViewData["TaskeStateId"] = new SelectList(_context.TaskeStates, "TaskeStateId", "TaskeStateName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Taskes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, int sectionId, [Bind("TaskeId,TaskeName,Date,SectionId,TaskeStateId,TaskePriorityId,UserId")] Taske taske)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taske);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Projects", new { id = id });
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.SectionId == sectionId), "SectionId", "SectionName", taske.SectionId);
            ViewData["TaskePriorityId"] = new SelectList(_context.TaskePriorities, "TaskePriorityId", "TaskePriorityName", taske.TaskePriorityId);
            ViewData["TaskeStateId"] = new SelectList(_context.TaskeStates, "TaskeStateId", "TaskeStateName", taske.TaskeStateId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", taske.UserId);
            return View(taske);
        }

        // GET: Taskes/Edit/5
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Edit(int? id, int? sectionId, int? taskeId)
        {
            if (id == null && sectionId == null && taskeId == null)
            {
                return NotFound();
            }

            var taske = await _context.Taskes.FindAsync(taskeId);
            if (taske == null)
            {
                return NotFound();
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.SectionId == sectionId), "SectionId", "SectionName", taske.SectionId);
            ViewData["TaskePriorityId"] = new SelectList(_context.TaskePriorities, "TaskePriorityId", "TaskePriorityName", taske.TaskePriorityId);
            ViewData["TaskeStateId"] = new SelectList(_context.TaskeStates, "TaskeStateId", "TaskeStateName", taske.TaskeStateId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", taske.UserId);
            return View(taske);
        }

        // POST: Taskes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int sectionId, int taskeId, [Bind("TaskeId,TaskeName,Date,SectionId,TaskeStateId,TaskePriorityId,UserId")] Taske taske)
        {
            if (taskeId != taske.TaskeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taske);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskeExists(taske.TaskeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Projects", new { id = id });
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.SectionId == sectionId), "SectionId", "SectionName", taske.SectionId);
            ViewData["TaskePriorityId"] = new SelectList(_context.TaskePriorities, "TaskePriorityId", "TaskePriorityName", taske.TaskePriorityId);
            ViewData["TaskeStateId"] = new SelectList(_context.TaskeStates, "TaskeStateId", "TaskeStateName", taske.TaskeStateId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", taske.UserId);
            return View(taske);
        }

        // GET: Taskes/Delete/5
        [Authorize(Policy = "AdminAccess, UserAccess")]
        public async Task<IActionResult> Delete(int? id, int? sectionId, int? taskeId)
        {
            if (id == null && sectionId == null && taskeId == null)
            {
                return NotFound();
            }

            var taske = await _context.Taskes
                .Include(t => t.Section)
                .Include(t => t.TaskePriority)
                .Include(t => t.TaskeState)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskeId == taskeId);
            if (taske == null)
            {
                return NotFound();
            }

            return View(taske);
        }

        // POST: Taskes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int sectionId, int taskeId)
        {
            var taske = await _context.Taskes.FindAsync(taskeId);
            _context.Taskes.Remove(taske);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Projects", new { id = id });
        }

        private bool TaskeExists(int id)
        {
            return _context.Taskes.Any(e => e.TaskeId == id);
        }
    }
}
