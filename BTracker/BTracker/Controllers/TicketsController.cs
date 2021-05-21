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
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TicketsController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tickets.Include(t => t.Section).Include(t => t.TicketPriority).Include(t => t.TicketState).Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Section)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketState)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        [Authorize (Policy = "AdminAccess")]
        public IActionResult Create(int? id, int? sectionId, string place)
        {
            List<string> usersInProject = (from uInP in _context.ProjectAccesses
                                 where uInP.ProjectId == id
                                 select uInP.UserId).ToList();

            var getTheUsersId = (from getUId in _context.Users
                                 where usersInProject.Contains(getUId.Id)
                                 select getUId);

            ViewBag.place = place;
            ViewBag.projectId = id;
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.SectionId == sectionId), "SectionId", "SectionName");
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "TicketPriorityId", "TicketPriorityName");
            ViewData["TicketStateId"] = new SelectList(_context.TicketStates, "TicketStateId", "TicketStateName");
            ViewData["UserId"] = new SelectList(getTheUsersId, "Id", "Email");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, int sectionId, [Bind("TicketId,TicketName,Date,SectionId,TicketStateId,TicketPriorityId,UserId,IsDone")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Projects", new { id = id });
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.SectionId == sectionId), "SectionId", "SectionName", ticket.SectionId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "TicketPriorityId", "TicketPriorityName", ticket.TicketPriorityId);
            ViewData["TicketStateId"] = new SelectList(_context.TicketStates, "TicketStateId", "TicketStateName", ticket.TicketStateId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", ticket.UserId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Edit(int? id, int? sectionId, int? ticketId)
        {
            if (id == null && sectionId == null && ticketId == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.ProjectId == id), "SectionId", "SectionName", ticket.SectionId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "TicketPriorityId", "TicketPriorityName", ticket.TicketPriorityId);
            ViewData["TicketStateId"] = new SelectList(_context.TicketStates, "TicketStateId", "TicketStateName", ticket.TicketStateId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", ticket.UserId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int sectionId, int ticketId, [Bind("TicketId,TicketName,Date,SectionId,TicketStateId,TicketPriorityId,UserId")] Ticket ticket)
        {
            if (ticketId != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
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
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(x => x.SectionId == sectionId), "SectionId", "SectionName", ticket.SectionId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "TicketPriorityId", "TicketPriorityName", ticket.TicketPriorityId);
            ViewData["TicketStateId"] = new SelectList(_context.TicketStates, "TicketStateId", "TicketStateName", ticket.TicketStateId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", ticket.UserId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize(Policy = "AdminAccess, UserAccess")]
        public async Task<IActionResult> Delete(int? id, int? sectionId, int? ticketId)
        {
            if (id == null && sectionId == null && ticketId == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Section)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketState)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TicketId == ticketId);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int sectionId, int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Projects", new { id = id });
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
