using LmycWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Data
{
    public class DBInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
                                            UserManager<ApplicationUser> userManager,
                                            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            Debug.WriteLine("In Initializer");

            // Initializing Roles
            string role1 = "Admin";
            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role1));
            }

            string role2 = "Member";
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role2));
            }

            // Initializing Users
            string password = "P@$$w0rd";

            string user1 = "a@a.a"; // Admin
            if (await userManager.FindByNameAsync(user1) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = user1,
                    FirstName = "A",
                    LastName = "A",
                    Street = "3700 Willingdon Ave",
                    City = "Burnaby",
                    Province = "BC",
                    PostalCode = "V5G 3H2",
                    Country = "Canada",
                    MobileNumber = 6049000001,
                    SailingExperience = "4123 days",
                    Email = user1
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            string user2 = "m@m.m"; // Member
            if (await userManager.FindByNameAsync(user2) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = user2,
                    FirstName = "M",
                    LastName = "M",
                    Street = "3700 Willingdon Ave",
                    City = "Burnaby",
                    Province = "BC",
                    PostalCode = "V5G 3H2",
                    Country = "Canada",
                    MobileNumber = 6049000002,
                    SailingExperience = "43 months",
                    Email = user2
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Member");
                }
            }

            // Initializing Boats
            if (!context.Boats.Any())
            {
                List<Boat> Boats = GetBoats();

                context.Boats.AddRange(Boats);
                context.SaveChanges();
            }

        }

        private static List<Boat> GetBoats()
        {
            List<Boat> Boats = new List<Boat>()
            {
                new Boat
                {
                    BoatName = "Sharqui",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/sharqui%20photo.jpg",
                    LengthInFeet = 27,
                    Make = "C&C",
                    Year = 1981,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = "a@a.a"
                },

                new Boat
                {
                    BoatName = "Pegasus",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/Small%20pegasus.jpg",
                    LengthInFeet = 27,
                    Make = "C&C",
                    Year = 1979,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = "a@a.a"
                },

                new Boat
                {
                    BoatName = "Lightcure",
                    Picture = "http://www.lmyc.ca/sites/default/files/Lightcurefleetpic.jpg",
                    LengthInFeet = 27,
                    Make = "C&C",
                    Year = 1979,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = "a@a.a"
                },

                new Boat
                {
                    BoatName = "Frankie",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/frankie.jpg",
                    LengthInFeet = 25,
                    Make = "Cal",
                    Year = 1983,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = "a@a.a"
                },

                new Boat
                {
                    BoatName = "White Swan",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/white%20swan.jpg",
                    LengthInFeet = 28,
                    Make = "Catalina",
                    Year = 1996,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = "a@a.a"
                },

                new Boat
                {
                    BoatName = "Peak Time",
                    Picture = "http://www.lmyc.ca/sites/default/files/PeakTimefleetpic.jpg",
                    LengthInFeet = 27,
                    Make = "C&C",
                    Year = 1985,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = "a@a.a"
                },

                new Boat
                {
                    BoatName = "Y-Knot",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/IMG_0291%20%282%29_0.JPG",
                    LengthInFeet = 30,
                    Make = "Hunter",
                    Year = 1980,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = "a@a.a"
                }
            };

            return Boats;
        }
    }
}
