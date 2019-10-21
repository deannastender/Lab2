using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1B.Data;
using Lab1B.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// I, Deanna Stender, student number 000732962, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

namespace Lab1B.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _roleManager = RoleManager;
        }

        public async Task<IActionResult> SeedRoles()
        {
            ApplicationUser user1 = new ApplicationUser
            {
                Email = "deanna.stender@mohawkcollege.ca",
                UserName = "deanna.stender@mohawkcollege.ca",
                FirstName = "Deanna",
                LastName= "Stender",
                BirthDate = "1997-01-06"
            };
            ApplicationUser user2 = new ApplicationUser
            {
                Email = "julia.stender@live.com",
                UserName = "julia.stender@live.com",
                FirstName = "Julia",
                LastName = "Stender",
                BirthDate = "1995-07-25"
            };
            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk1!");

            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _userManager.CreateAsync(user2, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _roleManager.CreateAsync(new IdentityRole("Staff"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });

            result = await _roleManager.CreateAsync(new IdentityRole("Manager"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });


            result = await _userManager.AddToRoleAsync(user1, "Staff");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });

            result = await _userManager.AddToRoleAsync(user2, "Manager");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });

            return RedirectToAction("Index", "Home");
        }
    }
}