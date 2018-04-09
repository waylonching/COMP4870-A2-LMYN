using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LmycWeb.Data;
using LmycWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LmycWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public RolesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var roles = await _context.Roles.OrderBy(r => r.Name).ToListAsync();
            return View(roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(role.Name))
                {
                    ViewBag.Message = "Failed to create new role: Invalid name";
                    return View(role);
                }

                if (await _roleManager.RoleExistsAsync(role.Name))
                {
                    ViewBag.Message = "Failed to create new role: Duplicate name";
                    return View(role);
                }

                await _roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // GET: Roles/Edit/<roleId>
        public async Task<IActionResult> Edit(string roleId)
        {
            if (roleId == null)
            {
                return BadRequest();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            if (role == null)
            {
                return NotFound();
            }

            if (role.Name == "Admin" || role.Name == "Member")
            {
                ViewBag.Message = "Failed to delete role: Do not edit Admin or Member.";
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // POST: Roles/Edit/<roleId>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityRole role)
        {
            if (ModelState.IsValid)
            {

                if (role.Name == "Admin" || role.Name == "Member")
                {
                    ViewBag.Message = "Failed to delete role: Do not edit Admin or Member.";
                    return RedirectToAction(nameof(Index));
                }

                var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.Id == role.Id);

                existingRole.Name = role.Name;

                _context.Entry(existingRole).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // GET: Roles/Delete/<roleId>
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                return NotFound();
            }

            if (role.Name == "Admin" || role.Name == "Member")
            {
                ViewBag.Message = "Failed to delete role: Do not delete Admin or Member.";
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }


        // POST: Roles/Delete/<roleId>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                ViewBag.Message = "Failed to delete role: role not found.";
                return RedirectToAction(nameof(Index));
            }

            if (role.Name == "Admin" || role.Name == "Member")
            {
                ViewBag.Message = "Failed to delete role: Do not delete Admin or Member.";
                return RedirectToAction(nameof(Index));
            }

            var users = await _userManager.GetUsersInRoleAsync(role.Name);

            // remove users from roles
            foreach (ApplicationUser user in users)
            {
                await _userManager.RemoveFromRoleAsync(user, role.Name);
            }

            // remove role from Roles table
            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                return View(role);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}