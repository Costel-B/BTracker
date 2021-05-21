using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTracker.Data;
using BTracker.Models;

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
            var applicationDbContext = _context.Sections.Include(s => s.Project).Include(s => s.ToUser);
            return View(await applicationDbContext.ToListAsync());
        }






        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id, int? sectionId, string place)
        {
            ViewBag.projectId = id;
            ViewBag.place = place;

            if (id == null && sectionId == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Project)
                .Include(s => s.ToUser)
                .FirstOrDefaultAsync(m => m.SectionId == sectionId);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }







        // GET: Sections/Create
        public IActionResult Create(int? id, string place)
        {
            ViewBag.projectId = id;
            ViewBag.place = place;

            /*            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");*/
            List<string> usersInProject = (from uInP in _context.ProjectAccesses
                                           where uInP.ProjectId == id
                                           select uInP.UserId).ToList();

            var toUser = from tUser in _context.Users
                         where usersInProject.Contains(tUser.Id)
                         select tUser;

            ViewData["ToUserId"] = new SelectList(toUser, "Id", "Email");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, string place, [Bind("SectionId,SectionName,ToUserId,ProjectId")] Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();

                var nullTaske = new Ticket()
                {
                    TicketName = "EmptyTicketNullTicket1.2.3.4.5",
                    TicketPriorityId = 1,
                    TicketStateId = 1,
                    SectionId = section.SectionId,
                    Date = DateTime.Now
                };
                _context.Tickets.Add(nullTaske);
                await _context.SaveChangesAsync();

                return RedirectToAction(place, "Projects", new { id });
            }
            ViewData["ToUserId"] = new SelectList(_context.Users, "Id", "Email", section.ToUserId);
            return View(section);
        }







        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id, int? sectionId, string place)
        {
            ViewBag.place = place;
            ViewBag.projectId = id;

            if (id == null && sectionId == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FindAsync(sectionId);
            if (section == null)
            {
                return NotFound();
            }
            /*            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", section.ProjectId);*/
            ViewData["ToUserId"] = new SelectList(_context.Users, "Id", "Email", section.ToUserId);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionId,SectionName,ToUserId,ProjectId")] Section section)
        {
            if (id != section.SectionId)
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
                return RedirectToAction(nameof(Index));
            }
            /*            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", section.ProjectId);*/
            ViewData["ToUserId"] = new SelectList(_context.Users, "Id", "Id", section.ToUserId);
            return View(section);
        }






        public async Task<IActionResult> UserToSection(int? id, int? sectionId, string place)
        {
            ViewBag.place = place;
            ViewBag.projectId = id;

            if (id == null && sectionId == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FindAsync(sectionId);
            if (section == null)
            {
                return NotFound();
            }

            List<string> usersInProject = (from uInP in _context.ProjectAccesses
                                           where uInP.ProjectId == id
                                           select uInP.UserId).ToList();

            var toUser = from tUser in _context.Users
                         where usersInProject.Contains(tUser.Id)
                         select tUser;


            ViewData["ToUserId"] = new SelectList(toUser, "Id", "Email");
            return View(section);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserToSection(int id, int sectionId, string place, [Bind("SectionId,SectionName,ProjectId,ToUserId")] Section section)
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
                return RedirectToAction(place, "Projects", new { id });
            }
            return View(section);
        }






        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id, int? sectionId, string place)
        {
            ViewBag.place = place;
            ViewBag.projectId = id;

            if (id == null && sectionId == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Project)
                .Include(s => s.ToUser)
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
        public async Task<IActionResult> DeleteConfirmed(int id, int sectionId, string place)
        {
            var section = await _context.Sections.FindAsync(sectionId);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return RedirectToAction(place, "Projects", new { id });
        }







        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.SectionId == id);
        }
    }
}
