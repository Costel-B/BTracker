﻿using System;
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
        private readonly IHostingEnvironment hostingEnvironment;

        public ProjectsController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
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

            if (getTheProjects.Count() == 0)
            {
                return RedirectToAction("Create", "Projects");
            }

            return View(projectsAndUser);
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

            var sections = _context.Sections.Where(x => x.ProjectId == id).ToList();

            var taskesFromSection = _context.Sections.Where(x => x.ProjectId == id.Value).SelectMany(x => x.Taskes).OrderBy(x => x.Section).ToList();

            var projectAccess = _context.ProjectAccesses.Where(x => x.ProjectId == id).Include(p => p.AccessLevel).Include(p => p.User).ToList();

            var projectSectionAndTaskes = new ProjectSectionAndTaskesViewModel()
            {
                Project = project,
                UserId = currentUserId,
                Sections = sections,
                Taskes = taskesFromSection,
                ProjectAccesses = projectAccess
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

        public IActionResult _SeeUsersInProject()
        {
            return PartialView("_SeeUsersInProject");
        }

        public IActionResult _ProjectHeader()
        {
            return PartialView("_ProjectHeader");
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
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectSmallBrief,File,UserId")] ProjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                string filePathView = null;
                if(model.File != null)
                {
                    // uploads folder in the images foldoer of wwwroot folder
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // to have unique file names
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    // combine the path to upleads folder and the file name itself
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                    filePathView = filePath;
                }

                Project newProject = new Project
                {
                    ProjectId = model.ProjectId,
                    ProjectName = model.ProjectName,
                    ProjectSmallBrief = model.ProjectSmallBrief,
                    UserId = model.UserId,
                    User = model.User,
                    FilePath = uniqueFileName,
                    FileUrl = filePathView
                };

                _context.Add(newProject);
                await _context.SaveChangesAsync();

                var projectAccess = new ProjectAccess()
                {
                    ProjectId = newProject.ProjectId,
                    UserId = newProject.UserId,
                    AccessLevelId = 1
                };
                _context.ProjectAccesses.Add(projectAccess);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", model.UserId);
            return View(model);
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
