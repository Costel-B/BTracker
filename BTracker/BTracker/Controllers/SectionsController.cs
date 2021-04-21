using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTracker.Data;
using BTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace BTracker.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sections.Include(s => s.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Project)
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        [Authorize(Policy = "AdminAccess")]
        public IActionResult Create(int? id, string place)
        {
            ViewBag.projectId = id;
            ViewBag.place = place;
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("SectionId,SectionName,ProjectId")] Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();

                var nullTaske = new Taske()
                {
                    TaskeName = "EmptyTaskeNullTaske1.2.3.4.5",
                    TaskePriorityId = 1,
                    TaskeStateId = 1,
                    SectionId = section.SectionId,
                    Date = DateTime.Now
                };
                _context.Taskes.Add(nullTaske);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Projects", new { id = id });
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects.Where(x => x.ProjectId == id), "ProjectId", "ProjectName", section.ProjectId);
            return View(section);
        }

        // GET: Sections/Edit/5
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Edit(int? id, int? sectionId)
        {
            if (sectionId == null && id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FindAsync(sectionId);
            if (section == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects.Where(x => x.ProjectId == id), "ProjectId", "ProjectName", section.ProjectId);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int sectionId, [Bind("SectionId,SectionName,ProjectId")] Section section)
        {
            if (sectionId != section.SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(section);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.SectionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Project", new { id = id });
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects.Where(x => x.ProjectId == id), "ProjectId", "ProjectName", section.ProjectId);
            return View(section);
        }

        // GET: Sections/Delete/5
        [Authorize (Policy = "AdminAccess, UserAccess")]
        public async Task<IActionResult> Delete(int? id, int? sectionId)
        {
            if (id == null && sectionId == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Project)
                .FirstOrDefaultAsync(m => m.SectionId == sectionId);

            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int sectionId)
        {
            var section = await _context.Sections.FindAsync(sectionId);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Projects", new { id = id });
        }

        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.SectionId == id);
        }
    }
}
