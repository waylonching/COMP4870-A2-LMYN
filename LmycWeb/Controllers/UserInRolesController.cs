using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LmycWeb.Data;
using LmycWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            //var userList = await 
            //return View(userList);
            return View();
        }

        // GET: UserInRoles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }
        
        // GET: UserInRoles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: UserInRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}