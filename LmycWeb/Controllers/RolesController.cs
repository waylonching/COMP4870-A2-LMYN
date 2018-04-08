//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using LmycWeb.Data;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc;

//namespace LmycWeb.Controllers
//{
//    public class RolesController : Controller
//    {
//        private readonly ApplicationDbContext context;

//        // GET: Roles
//        public ActionResult Index()
//        {
            

//            if (User.Identity.IsAuthenticated)
//            {
//                if (User.IsInRole("Admin"))
//                {
//                    var Roles = context.Roles.ToList();
//                    return View(Roles);
//                }
//            }
//            return RedirectToAction("Index", "Home");            
//        }

//        // GET: Roles/Create
//        [Authorize(Roles = "Admin")]
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Roles/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [Authorize(Roles = "Admin")]
//        public ActionResult Create(Role newRole)
//        {
//            if (ModelState.IsValid)
//            {
//                ApplicationDbContext context = new ApplicationDbContext();

//                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

//                if (!roleManager.RoleExists(newRole.Name))
//                {
//                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
//                    role.Name = newRole.Name;
//                    roleManager.Create(role);
//                }

//                return RedirectToAction("Index");
//            }

//            return View();
//        }

//        // GET: Roles/Delete/<roleId>
//        [Authorize(Roles = "Admin")]
//        public ActionResult Delete(string roleId)
//        {
//            ApplicationDbContext context = new ApplicationDbContext();

//            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
//            var role = roleManager.FindById(roleId);

//            if (role != null)
//            {
//                roleManager.Delete(role);
//            }

//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}