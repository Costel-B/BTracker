using BTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTracker.ViewComponents
{
    public class DisplayCommentVIewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public DisplayCommentVIewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int ticketId)
        {
            var comments = await _context.Comments.Include(x => x.User).Include(x => x.Ticket).Where(x => x.TicketId == ticketId).ToListAsync();

            return View(comments);
        }
    }
}
