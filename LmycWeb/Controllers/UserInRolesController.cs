using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LmycWeb.Data;
using LmycWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LmycWeb.Controllers
{
    public class UserInRolesController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserInRolesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserInRoles
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();

            List<UserInRoleViewModel> userList = new List<UserInRoleViewModel>();
            foreach (ApplicationUser user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserInRoleViewModel
                {
                    Username = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserRoles = (await _userManager.GetRolesAsync(user)) as List<string>
                });
            }
                                
            return View(userList);
        }
        
        // GET: UserInRoles/Edit/5
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == id);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserInRoleViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserRoles = (await _userManager.GetRolesAsync(user)) as List<string>
            };

            ViewBag.Roles = await _context.Roles.Select(r => r.Name).ToListAsync();
            return View(viewModel);
        }

        // POST: UserInRoles/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Username, UserRoles")]UserInRoleViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.Username);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            // remove old roles
            await _userManager.RemoveFromRolesAsync(user, roles);

            // add new roles
            await _userManager.AddToRolesAsync(user, model.UserRoles);

            // special case - always have a in admin
            if (user.UserName == "a")
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return View(model);
        }
    }
}