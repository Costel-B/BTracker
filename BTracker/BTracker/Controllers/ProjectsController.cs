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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BTracker.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProjectsController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }







        // GET: Projects
        public async Task<IActionResult> Index()
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

            if (getTheProjects.Count == 0)
            {
                return RedirectToAction("Create", "Projects");
            }

            return View(getTheProjects);
        }






        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var currentUserId = _userManager.GetUserId(User);
            ViewBag.currentUserId = currentUserId;

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectId == id);

/*            var sections = _context.Sections.Where(x => x.ProjectId == id).ToList();

            var ticketsFromSection = _context.Sections.Where(x => x.ProjectId == id.Value).SelectMany(x => x.Tickets).OrderBy(x => x.Section).ToList();*/

            var projectAccess = _context.ProjectAccesses.Where(x => x.ProjectId == id).Include(p => p.AccessLevel).Include(p => p.User).ToList();

            var projectAccessLevel = (from t in _context.ProjectAccesses
                       where t.ProjectId == id && t.UserId == currentUserId
                       select t.AccessLevelId).Single();

            switch (projectAccessLevel)
            {
                case 1:
                    ViewBag.projectAccessLevel = 1;
                    break;
                case 2:
                    ViewBag.projectAccessLevel = 2;
                    break;
                default:
                    ViewBag.projectAccessLevel = 3;
                    break;
            }

            var projectSectionAndTickets = new ProjectSectionAndTicketsViewModel()
            {
                Project = project,
/*                UserId = currentUserId,
                Sections = sections,
                Tickets = ticketsFromSection,*/
                ProjectAccesses = projectAccess
            };

            if (project == null)
            {
                return NotFound();
            }
            
            return View(projectSectionAndTickets);
        }

        public async Task<IActionResult> List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.Include(x => x.User).FirstOrDefaultAsync(x => x.ProjectId == id);

            var sections = _context.Sections.Where(x => x.ProjectId == id).ToList();

            var ticketsFromSection = _context.Sections.Where(x => x.ProjectId == id).SelectMany(x => x.Tickets).OrderBy(x => x.Section).Include(x => x.Section).Include(x => x.TicketPriority).Include(x => x.TicketState).Include(x => x.User).ToList();

            ProjectSectionAndTicketsViewModel projectSectionAndTickets = new()
            {
                Project = project,
                Sections = sections,
                Tickets = ticketsFromSection
            };

            if (project == null)
            {
                return NotFound();
            }

            return View(projectSectionAndTickets);
        }

        public async Task<IActionResult> Board(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.Include(x => x.User).FirstOrDefaultAsync(x => x.ProjectId == id);

            var sections = _context.Sections.Where(x => x.ProjectId == id).ToList();

            var ticketsFromSection = _context.Sections.Where(x => x.ProjectId == id).SelectMany(x => x.Tickets).OrderBy(x => x.Section).Include(x => x.Section).Include(x => x.TicketPriority).Include(x => x.TicketState).Include(x => x.User).ToList();

            ProjectSectionAndTicketsViewModel projectSectionAndTickets = new()
            {
                Project = project,
                Sections = sections,
                Tickets = ticketsFromSection
            };

            return View(projectSectionAndTickets);
        }

        // Partial to see the sections of the current project
        public IActionResult _SeeSectionProject()
        {
            return PartialView("_SeeSectionProject");
        }

        // Partial to see the tasks of the sections of the current project
        public IActionResult _SeeTicketSection()
        {
            return PartialView("_SeeTicketSection");
        }

        public IActionResult _SeeUsersInProject()
        {
            return PartialView("_SeeUsersInProject");
        }

        public IActionResult _ProjectHeader()
        {
            return PartialView("_ProjectHeader");
        }

        public IActionResult _ProjectFooter()
        {
            return PartialView("_ProjectFooter");
        }






        // GET: Projects/Create
        public IActionResult Create()
        {
            var currentUserId = _userManager.GetUserId(User);
            ViewBag.currentUserId = currentUserId;
            var projectsIHaveAccess = (from pIA in _context.ProjectAccesses
                                       where pIA.UserId == currentUserId
                                       select pIA.ProjectId).ToList();
            ViewBag.countProjects = projectsIHaveAccess.Count();
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectSmallBrief,UserId")] Project project)
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

/*                var sectionAdded = new Section()
                {
                    ProjectId = project.ProjectId,
                    SectionName = "EmptySectionNullSection1.2.3.4.5"
                };
                _context.Sections.Add(sectionAdded);
                await _context.SaveChangesAsync();*/

                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }






        public IActionResult DownloadFile(int? id, string filePath)
        {
            var project = _context.Projects.FirstOrDefault(x => x.ProjectId == id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string fileName = $"{project.ProjectName}_Brief.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }






        // GET: Projects/AddSmallBrief
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> AddFile(int? id)
        {
            ViewBag.currentUserId = _userManager.GetUserId(User);
            ViewBag.projectId = id;

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            ViewBag.projectName = project.ProjectName;
            if (project == null)
            {
                return NotFound();
            }

            ProjectViewModel projectViewModel = new()
            {
                Project = project
            };

            return View(projectViewModel);
        }
        // POST: Projects/AddSmallBrief/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFile(int id, ProjectViewModel projectViewModel)
        {
            if (projectViewModel.File != null)
            {
                // upload files to wwwroot
                var fileName = Path.GetFileName(projectViewModel.File.FileName);
                // judge if it is a pdf file
                string ext = Path.GetExtension(projectViewModel.File.FileName);
                if (ext.ToLower() != ".pdf")
                {
                    return View();
                }
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await projectViewModel.File.CopyToAsync(fileSteam);
                }

                var project = _context.Projects.FirstOrDefault(x => x.ProjectId == id);
                project.FilePath = filePath;

                _context.Projects.Update(project);
                await _context.SaveChangesAsync();

                // see what files every project has
                // remove the files that have different urls
                string[] files = Directory.GetFiles(Path.Combine(webHostEnvironment.WebRootPath, "images"));

                var existingFiles = _context.Projects.Select(x => x.FilePath).ToList();

                foreach (string file in files)
                {
                    foreach (string existingFile in existingFiles)
                    {
                        if (existingFile != file)
                        {
                            System.IO.File.Delete(file);
                        };
                    };
                };

                return RedirectToAction("Details", "Projects", new { id });
            }

            return View();
        }






        // GET: Projects/AddSmallBrief
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> AddSmallBrief(int? id)
        {
            ViewBag.currentUserId = _userManager.GetUserId(User);
            ViewBag.projectId = id;

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/AddSmallBrief/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSmallBrief(int id, [Bind("ProjectId,ProjectName,ProjectSmallBrief,UserId")] Project project)
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
                return RedirectToAction("Details", "Projects", new { id });
            }
            return View(project);
        }






        // GET: Projects/AddBrief
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> AddBrief(int? id)
        {
            ViewBag.currentUserId = _userManager.GetUserId(User);
            ViewBag.projectId = id;

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/AddBrief/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBrief(int id, [Bind("ProjectId,ProjectName,ProjectBrief,UserId")] Project project)
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
                return RedirectToAction("Details", "Projects", new { id });
            }
            return View(project);
        }






        // GET: Projects/Edit/5
        [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Edit(int? id, string place)
        {
            ViewBag.currentUserId = _userManager.GetUserId(User);
            ViewBag.projectId = id;
            ViewBag.place = place;

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



            // List of all project access of the project
            var projectAccessList = _context.ProjectAccesses.Where(x => x.ProjectId == id);
            // delete the list
            foreach (var item in projectAccessList)
            {
                _context.ProjectAccesses.Remove(item);
            }



            var projectAccess = await _context.ProjectAccesses.FindAsync(id);
            _context.ProjectAccesses.Remove(projectAccess);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
